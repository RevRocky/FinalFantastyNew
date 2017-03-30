using UnityEngine;
using System.Collections;
using System.IO;
using System.Drawing;

public class IMG2Sprite : MonoBehaviour {

	// This script loads a PNG or JPEG image from disk and returns it as a Sprite
	// Drop it on any GameObject/Camera in your scene (singleton implementation)
	//
	// Usage from any other script:
	// MySprite = IMG2Sprite.instance.LoadNewSprite(FilePath, [PixelsPerUnit (optional)])
	// This code is shamelessly lifted from the internet but it does EXACTLY what we want!

	private static IMG2Sprite _instance;

	public static IMG2Sprite instance
	{
		get    
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.

			if(_instance == null)
				_instance = GameObject.FindObjectOfType<IMG2Sprite>();
			return _instance;
		}
	}

	public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f) {

		// Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference

		Sprite NewSprite = new Sprite();
		Texture2D SpriteTexture = LoadTexture(FilePath);
		NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height),new Vector2(0,0), PixelsPerUnit);

		return NewSprite;
	}

	public Texture2D LoadTexture(string FilePath) {

		// Load a PNG or JPG file from disk to a Texture2D
		// Returns null if load fails

		Texture2D Tex2D;
		Tex2D = (Texture2D) Resources.Load (FilePath) ;

		// What if we can't load it from resources? Let's load it the regular way
		if (Tex2D == null) {
			Bitmap bmp = (Bitmap) Bitmap.FromFile(FilePath);		// File path is an absolute file path
			Tex2D = new Texture2D(2, 2);
			Tex2D.LoadImage(imageToByte(bmp));						// Load the byte array of our image
		}
		return Tex2D;                  // Return null if load failed
	}

	// This little block of code graciiusly lifted from Stack Overflow!
	public byte[] imageToByte(Bitmap bitmap){
		using (var stream = new MemoryStream())
		{
			bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
			return stream.ToArray();
		}
	}
}