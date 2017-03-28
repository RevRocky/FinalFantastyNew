using UnityEngine;
using System.Collections;

public class Announcer : MonoBehaviour
{

	public string spriteLocation = "Announcer.png";
	public string name = "Emcee";

	private static Announcer _instance;											// Private copy of instance	
	public static Announcer instance											// Tracks present instance of the Announcer
	{
		get    
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<Announcer>();
			return _instance;
		}
	}

	// The text that will display before any judging begins
	public string preJudgingText() {
		return "Long has man pondered who would come out on top in a battle of culinary wits. Would it be man... or machine. Today we find out!";
	}

	// Kind of gross but I have to make it respond to ALL OF the scenarios
	public string midJudgingText(Vector2 points) {
		// The text that plays depends on points
		if (points.x == 0 && points.y == 0) {
		} else if (points.x == 1 && points.y == 0) {
		} else if (points.x == 1 && points.y == 1) {
		} else if (points.x == 0 && points.y == 1) {
		} else if (points.x == 2 && points.y == 0) {
		} else {
			// AI enroute to a blow out
		}
	}

	// Handles the text that plays after the judging has been completed
	public string postJudgingText(Vector2 points) {
		// If a blow out comment on it
		if (points.x == 3 || points.y == 3_ {
			return "Looks Like we has a blow out here!";
		}



}

