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

	private static string TEMP_DIRECTORY = "Resources" + Path.DirectorySeparatorChar + "Art" + Path.DirectorySeparatorChar + "PlaceHolder" + Path.DirectorySeparatorChar;	// A relative file path
	private static string CARD_BASE_DIRECTORY = "Resources" + Path.DirectorySeparatorChar + "Art" + Path.DirectorySeparatorChar + "Templates" + Path.DirectorySeparatorChar;
	private static string CARD_IMAGE_DRECTORY = "Resources" + Path.DirectorySeparatorChar + "Art" + Path.DirectorySeparatorChar + "Meal" + Path.DirectorySeparatorChar;
	private static string STAT_IMAGE_DIRECTORY = "Resources" + "Art" + Path.DirectorySeparatorChar + "Stats" + Path.DirectorySeparatorChar;

	private static string[] STAT_IMAGES = { "Sweet.png", "Sour.png", "Bitter.png", "Spicy.png", "Salty.png", "Umami.png" };

	// Key points on each card
	private static Rectangle PICTURE_RECTANGLE = new Rectangle (new Point (80, 77), new Size(576, 577));
	private static Point PICTURE_SIZE = new Point ( 576, 577 );
	private static Point NAME_LOCATION = new Point ( 368, 675 );
	private static Point NAME_BOUNDARIES = new Point (515, 70);
	private static Point MECHANICS_TOP_LEFT = new Point (87, 812);
	private static Point FLAVOUR_TEXT_LOCATION = new Point (332, 738);
	private static Point PICTOGRAMME_CENTRE = new Point ( 368, 738 );
	private static Point PICTOGRAMME_SIZE = new Point ( 41, 41 );

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

		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) {
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

		// Writing title and flavour text

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

	// Scales down a font to fit a given text to a certain area
	private System.Drawing.Font fitText(string message, System.Drawing.Font font, Rectangle constraints) {
		SizeF messageSize = System.Drawing.Graphics.MeasureString (message, font);		// Computing the size of our message

		while (messageSize.Height > constraints.Height || messageSize.Width > constraints.Width) {
			font = new System.Drawing.Font ("Bitter-Bold", font.Size - 1.0f);
			messageSize = System.Drawing.Graphics.MeasureString (message, font);
		}
		return font;
	}
}