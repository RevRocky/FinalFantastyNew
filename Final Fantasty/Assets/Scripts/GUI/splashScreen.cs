using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashScreen : MonoBehaviour {

	public float timer = 4f;
	public string levelToLoad = "Main Menu";
	// Use this for initialization
	void Start () {
		StartCoroutine ("DisplayScene");
	}


	IEnumerator DisplayScene(){
		yield return new WaitForSeconds (timer);
		Application.LoadLevel (levelToLoad);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
