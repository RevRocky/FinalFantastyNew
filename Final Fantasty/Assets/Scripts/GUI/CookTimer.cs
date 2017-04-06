using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This is a specialised timer for the Al Dente
 * and burn mechanics. 
 * 
 * At a later time I will look into merging 
 * with the Timer class which is for the
 * game as a whole.
 *
 * Author: Rocky
 */
public class CookTimer : MonoBehaviour {

	public const double START_TIME = 30;		// The time each clock will start with
	private double timeRemaining;				// The time remaining
	private bool activated;						// Tracks whether the timer is activated

	public Text timeZone;					// The text box with the countdown\
 

	// Use this for initialization
	void Start () {
		activated = true;						// Start the timer
	}

	// Where do I write to?
	public void init(Text timeZone) {
		this.timeZone = timeZone;
		timeRemaining = START_TIME;
	}

	// If the timer is activated, decrement it!
	void Update () {
		if (activated){
			timeRemaining -= Time.deltaTime;	// If activated decrement the timer		
		}
		if (activated && timeRemaining <= 0) {
			activated = false;					// Stop conting down if we're below zero
		}

	}

	// This will be sent by the governing mechanic to stop the timer!
	public void stop() {
		activated = false;						// Do not continue to decrement the timer
	}


	// Look into putting this into more relative code
	void OnGUI(){
		if (timeRemaining > 0) {
			// Displaying time neatly
			int seconds = ((int) timeRemaining) % 60;
			int minutes = ((int) timeRemaining) / 60;
			timeZone.text = string.Format ("{1}:{0}", seconds, minutes);
		} else {
			timeZone.text = "";
		}
	}

	// Returns the time remaining to the outside world!
	public double getTimeRemaining() {
		return timeRemaining;
	}

}
