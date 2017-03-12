using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;


/* 
 * This class contains all methods
 * pertaining to on demand image processing
 * needed by Final Fantasty.
 *
 * For the time being it contains some 
 * stub methods so we can get to testing A LOT sooner
 * 
 * Author: Rocky Petkov
 * Version: Stubby
 */
public class ImageProcessing{

	private static int NUM_STATS = 6;

	private static string TEMP_DIRECTORY = "Resources" + Path.DirectorySeparatorChar + "Art" + Path.DirectorySeparatorChar + "PlaceHolder" + Path.DirectorySeparatorChar;	// A relative file path
	private static string CARD_BASE_DIRECTORY = "Resources" + Path.DirectorySeparatorChar + "Art" + Path.DirectorySeparatorChar + "Templates" + Path.DirectorySeparatorChar;
	private static string CARD_IMAGE_DRECTORY = "Resources" + Path.DirectorySeparatorChar + "Art" + Path.DirectorySeparatorChar + "Meal" + Path.DirectorySeparatorChar;
	private static string STAT_IMAGE_DIRECTORY = "Resources" + Path.DirectorySeparatorChar + "Art" + Path.DirectorySeparatorChar + "Stats" + Path.DirectorySeparatorChar;

	private static string[] STAT_IMAGES = { "Sweet.png", "Sour.png", "Bitter.png", "Spicy.png", "Salty.png", "Umami.png" };

	// Key points on each card
	private static Rectangle PICTURE_RECTANGLE = new Rectangle (new Point (80, 77), new Size(576, 577));
	private static Point PICTURE_SIZE = new Point ( 576, 577 );
	private static Point NAME_CENTRE = new Point ( 368, 675 );
	private static Rectangle NAME_RECT = new Rectangle (new Point (115, 679), new Size (505, 66));
	private static Point NAME_BOUNDARIES = new Point (515, 70);
	private static Point MECHANICS_TOP_LEFT = new Point (87, 812);
	private static Point FLAVOUR_CENTRE = new Point (339, 913);
	private static Point PICTOGRAMME_CENTRE = new Point ( 368, 738 );
	private static Point PICTOGRAMME_SIZE = new Point ( 49, 49 );


	// Some stuff that will mainly be used on OS based branching
	private static bool WINDOWS = Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer;

	/*
	 * Combines various card arts into one hybrid image.
	 * saves image to disk and returns the location of the
	 * saved image.
	 */
	public static string hybridCardArt(List<Card> cardList) {
		return ("Ramsay.png"); 			// Stub implementation
	}

	/*
	 * Creates a fully fleged card image in a similar manner
	 * to the Python Scripts. Saves image to disk and returns
	 * the location of the file on DISK
	 */
	 public static string createMealCard(DatabaseEntry cardInfo) {
		Bitmap cardBase;		// The template card image
		Bitmap cardArt;			// The card art!

		System.Drawing.Font Bitter = new System.Drawing.Font ("Bitter", 32);
		System.Drawing.Font Bitter_Bold = new System.Drawing.Font ("Bitter", 50, System.Drawing.FontStyle.Bold);
		System.Drawing.Font Bitter_Italic = new System.Drawing.Font ("Bitter", 30, System.Drawing.FontStyle.Italic);

		SolidBrush blackBrush = new SolidBrush (System.Drawing.Color.Black);	// Black like my... erm... python. Rex.

		if (WINDOWS) {
			string properWindowsPath = Application.dataPath.Replace ('/', '\\');		// Correct operator!
			cardBase = (Bitmap)Bitmap.FromFile (properWindowsPath + Path.DirectorySeparatorChar + CARD_BASE_DIRECTORY + "CardBase.png");
			cardArt = (Bitmap)Bitmap.FromFile (properWindowsPath + Path.DirectorySeparatorChar + CARD_IMAGE_DRECTORY + cardInfo.artLocation);
		}
		else {		// Running on OSX or Linux
			cardBase = (Bitmap)Bitmap.FromFile (Application.dataPath + Path.DirectorySeparatorChar + CARD_BASE_DIRECTORY + "CardBase.png");
			cardArt = (Bitmap)Bitmap.FromFile (Application.dataPath + Path.DirectorySeparatorChar + CARD_IMAGE_DRECTORY + "CardBase.png");
		}

		// Ensure the card art is the correct size
		cardArt = resizeImage (cardArt, PICTURE_SIZE.X, PICTURE_SIZE.Y);

		// Pasting the card art on top of the base of the card.
		Bitmap overlayedImage = pasteCardArt(cardBase, cardArt);
		overlayedImage = drawStats (overlayedImage, cardInfo.stats);


		// Adjusting and centring messages
		Bitter_Bold = fitText(cardInfo.name, Bitter_Bold);				// Adjust font
		Point titleTopLeft = centreText(cardInfo.name, Bitter_Bold, NAME_CENTRE);	// Find a centred point
		Point flavourTopLeft = centreText(cardInfo.description, Bitter_Italic, FLAVOUR_CENTRE);

		// Actually Writing text
		// TODO: Write mechanics text
		var overlayedGraphics = System.Drawing.Graphics.FromImage(overlayedImage);
		overlayedGraphics.DrawString (cardInfo.name, Bitter_Bold, blackBrush, titleTopLeft);		// Write title
		overlayedGraphics.DrawString (cardInfo.description, Bitter_Italic, blackBrush, flavourTopLeft); 	// Writing flavour text

		overlayedImage.Save("C:\\Users\\Mafia_000\\Pictures\\TestImg.png");
		return (TEMP_DIRECTORY + "Timewizard");
	 }

	// This function resizes an image to have a width and height equal to the supplied
	//parameters. Note: This code is graciously lifted from the web!
	private static Bitmap resizeImage(Bitmap baseImage, int newWidth, int newHeight) {
		Rectangle someRectangle = new Rectangle (0, 0, newWidth, newHeight);
		Bitmap newImage = new Bitmap (newWidth, newHeight);										// Creating a new, blank bitmap!
		newImage.SetResolution(baseImage.HorizontalResolution, baseImage.VerticalResolution);	// Setting the resolution

		// I use the long form of almost EVERYTHING so it is clear I want to deal with C#.net code not unity.
		using (var graphics = System.Drawing.Graphics.FromImage (newImage)) {
			graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
			graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
			graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
		
			// Ignoring wrap mode... Seems to not play well with Unity
			graphics.DrawImage (baseImage, someRectangle, 0, 0, baseImage.Width, baseImage.Height, GraphicsUnit.Pixel);
		}
		return newImage;																		// All this to rescale an image. Jeez!
	}

	// Pastes the image "cardArt" on top of cardStock.
	private static Bitmap pasteCardArt(Bitmap cardStock, Bitmap cardArt) {
		var baseImage = System.Drawing.Graphics.FromImage (cardStock);							// Converting the base to be something I can write on
		baseImage.DrawImage(cardArt, PICTURE_RECTANGLE);
		return cardStock;																		// Should be the new version of the image.
	}

	// Draws each stat pictogramme correctly formatted on the card!
	private static Bitmap drawStats(Bitmap cardImage, byte[] stats) {
		Point pictogrammeTopLeft = new Point((int) (PICTOGRAMME_CENTRE.X - ((arraySum(stats) * PICTOGRAMME_SIZE.X)/2)), PICTOGRAMME_CENTRE.Y);
		int stat;	// Tracking the current stat
		Bitmap statImage;
		var drawer = System.Drawing.Graphics.FromImage (cardImage);		// Allows us to draw on the image
		byte statPoint;													// Tracks the cu

		// Loop through each stat, open and paste on it's picture
		for (stat = 0; stat < NUM_STATS; stat++){
			if (WINDOWS) {
				string properWindowsPath = Application.dataPath.Replace ('/', '\\');		// Correct operator!
				statImage = (Bitmap)Bitmap.FromFile (properWindowsPath + Path.DirectorySeparatorChar
				+ STAT_IMAGE_DIRECTORY + STAT_IMAGES [stat]);
			}
			else {		// We don't need windows file pathing!
				statImage = (Bitmap)Bitmap.FromFile (Application.dataPath + Path.DirectorySeparatorChar
					+ STAT_IMAGE_DIRECTORY + STAT_IMAGES [stat]);
			}
			// Loop through each stat point and paste its picture!
			for (statPoint = 0; statPoint < stats[stat]; statPoint ++) {
				drawer.DrawImage (statImage, pictogrammeTopLeft);	// Draw the pictogramme
				pictogrammeTopLeft.X += PICTOGRAMME_SIZE.X;			// Move to where we draw the next pictogramme
			}
		}
		return cardImage;

				
	}

	// This really should be genericised
	private static byte arraySum(byte[] array){
		byte sum = 0;
		for (int i = 0; i<NUM_STATS; i++) {
			sum += array [i];
		}
		return sum;
	}
				
	// Scales down a font to fit a given text to a certain area
	private static System.Drawing.Font fitText(string message, System.Drawing.Font font) {
		// Due to the non static nature of the Measure string method, I need to do this work on a dummy image. WEW!
		using (var image = new Bitmap (1, 1)) {
			using (var temp_gfx = System.Drawing.Graphics.FromImage (image)) {
				SizeF messageSize = temp_gfx.MeasureString (message, font);					// Computing the size of our message
				while (messageSize.Height > NAME_RECT.Height || messageSize.Width > NAME_RECT.Width) {
					font = new System.Drawing.Font ("Bitter-Bold", font.Size - 1.0f);		// Scale down our font until we have something acceptable!
					messageSize = temp_gfx.MeasureString (message, font);
				}
			}
		}
		return font;
	}

	// Returns an XY coordinate pair such that a message written in the Font font will
	// be centred around the provided centre point
	private static Point centreText(string message, System.Drawing.Font font, Point centrePoint) {
		Point messageTopLeft;
		using (var image = new Bitmap(1,1)) {
			using (var temp_gfx = System.Drawing.Graphics.FromImage (image)) {
				SizeF messageSize = temp_gfx.MeasureString (message, font);					// Computing the size of our message
				messageTopLeft = new Point((int)(centrePoint.X - (messageSize.Width / 2)), centrePoint.Y);
			}
		}
		return messageTopLeft;
	}
}