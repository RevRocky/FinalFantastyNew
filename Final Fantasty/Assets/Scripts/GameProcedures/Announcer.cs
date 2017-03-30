using UnityEngine;
using System.Collections;

public class Announcer : MonoBehaviour
{

	public string spriteLocation = "Announcer";
	public string name = "EMCEE";

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

	public string judgeRevealText() {
		return "Welcome to Final Fantasty."; //need revision
	}

	// The text that will display before any judging begins
	public string preJudgingText() {
		return "Long has man pondered who would come out on top in a battle of culinary wits. Would it be man... or machine. Today we find out!";
	}

	// Kind of gross but I have to make it respond to ALL OF the scenarios
	public string midJudgingText(Vector2 points) {
		// The text that plays depends on points
		if (points.x == 0 && points.y == 0) {
			return "And now, the judges will weigh in!!";
		} else if (points.x == 1 && points.y == 0) {
			return "It looks like an early lead for man.";
		} else if (points.x == 1 && points.y == 1) {
			return "Going into the mystery judge deadlocked. It could NOT be more exciting than this!";
		} else if (points.x == 0 && points.y == 1) {
			return "The machine looks to be out to an early lead here but will it stay that way?";
		} else if (points.x == 2 && points.y == 0) {
			return "We know the winner here but, will our human chef beable to pull out the 3-0 victory?";
		} else {
			// AI enroute to a blow out
			return "We know the winner here but, perhaps the mystery judge will see man's creation as a bit more" +
			"palatable than his colleagues";
		}
	}

	// Handles the text that plays after the judging has been completed
	public string postJudgingText(Vector2 points) {
		// If the player wins
		if (points.x == 3) {
			return "Well folks, it looks like man has managed to hold on to their title of culinary champion. For now..." +
			"Will it change? Find out next time on Final Fantasty!";
		}
		else {
			// AI Has won!
			return "Deep Blue, Alpha Go and now Friend. A list of machines that will go down in history. But with cooking, unlike chess," +
				"taste is subjective... so perhpaps, next time man will emerge on top!";
		}
	}
}

