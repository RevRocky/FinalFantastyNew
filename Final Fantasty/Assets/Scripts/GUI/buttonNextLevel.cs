using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonNextLevel : MonoBehaviour {

	// Use this for initialization
	public void NextLevelButton(int index){
		Application.LoadLevel (index);
	}
	
	// Update is called once per frame
	public void NextLevelButton (string levelName) {
		Application.LoadLevel (levelName);
	}
}
