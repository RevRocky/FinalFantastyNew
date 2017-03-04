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


	// Use this for initialization
	void Start () {
		activated = true;						// Start the timer
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
			GUI.Label (new Rect (100,100,100,30), "Time Remaining: " + (int)timeRemaining);

		} else {
			// When time is out we don't want to 
			GUI.Label (new Rect (50,25,100,30), "Time's up");
		}
	}

	// Returns the time remaining to the outside world!
	public double getTimeRemaining() {
		return timeRemaining;
	}

}
