using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;
	public GUIStyle Random1;
	public Texture logo;
	public Rect windowRect = new Rect(20, 20, 120, 50);
	void OnGUI(){
		//display background textture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), backgroundTexture);


	
		//display logo

		windowRect = GUI.Window(0, windowRect, DoMyWindow, logo);

		//display buttons 
		if(GUI.Button (new Rect (Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "Play Game")){
			Application.LoadLevel (1);
		}

		GUI.Button (new Rect (Screen.width * .25f, Screen.height * .69f, Screen.width * .5f, Screen.height * .1f), "Option");

/*
		GUI.Button (new Rect (Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "Play Game",Random1);

		GUI.Button (new Rect (Screen.width * .25f, Screen.height * .69f, Screen.width * .5f, Screen.height * .1f), "Option");
*/
 	}

	void DoMyWindow(int windowID) {
		if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
			print("Got a click");

	}
}
