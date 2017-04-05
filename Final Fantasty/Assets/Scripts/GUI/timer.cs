using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	public double timeRemaining = 5;
	public Text timeZone;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0.0f) {
			this.gameObject.AddComponent<GameOver> ();	// Trigger game over!
			Destroy(this);	// And go away!
		}
	}


	void OnGUI(){
		if (timeRemaining > 0) {
			// Displaying time neatly
			int seconds = ((int) timeRemaining) % 60;
			int minutes = ((int) timeRemaining) / 60;
			timeZone.text = string.Format ("{1}:{0}", seconds, minutes);
		} else {
			timeZone.text = "Times Up";
		}
	}
	/*
	IEnumerator ShowMessage(string text, float delay){
		time.text = text;
		prepText.enabled = true;
		yield return new WaitForSeconds (delay);
		prepText.enabled = false;
	}
	*/
}
