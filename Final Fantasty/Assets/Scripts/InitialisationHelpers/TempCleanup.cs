using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// This is a small little script that will clean up the temp folder at the start
// of a new game. Author: Rocky Raccoon
public class TempCleanup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string TEMP_DIR = Application.dataPath + Path.DirectorySeparatorChar + "Resources" + Path.DirectorySeparatorChar + "Temp";
		bool WINDOWS = Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer;
		// Accounting for different filepath on windows!
		if (WINDOWS) {
			TEMP_DIR = TEMP_DIR.Replace ('/', '\\');
		}
			
		// Again with having to use System.Array
		System.Array.ForEach(Directory.GetFiles (TEMP_DIR),
			delegate(string path) {
				File.Delete (path);
			});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
