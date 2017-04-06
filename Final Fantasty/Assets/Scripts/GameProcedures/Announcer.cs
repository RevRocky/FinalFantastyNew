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

	// Returns the text when the judge is revealed!
	public string judgeRevealText() {
		return "Contestants, welcome to Final Fantasty, the lightning-fast cookoff where each contestant will have three minutes and " +
			"only a limited ingredient pool to come up a meal that will wow our judges. First, let us meet our two contestants..."; //need revision
	}

	// The text that will display before any judging begins
	public string preJudgingText() {
		return "Long has man pondered who would come out on top in a battle of culinary wits. Would it be man... or machine? Today we find out!";
	}

	// This is some text injected in the middle of each judge to keep the flow feeling right
	public string judgeRevealBridgeText(int judgeID, int i){
		string ordinal = numberToOrdinal(i);	// I want proper ordinal values
		switch(judgeID){
			case 0: 
				return string.Format ("Our {0} judge, the international heartthrob, everyone's bae, Tuzlu! ", ordinal);
			case 1:
				return string.Format ("The {0} judge on the panel, the French puzzle master Enigmelle", ordinal);
			case 2:
				return string.Format ("The {0} judge on our panel, the Spanish wonder, Chef Gustavo!", ordinal);
			case 3:
				return string.Format ("The {0} judge today, erm... it says here... Sweet Gustavo?", ordinal);
			case 4:	
				return string.Format ("The {0} judge today, having just flown in from 'the north' it's Jane!", ordinal);
			case -1:
				return string.Format ("And finally, the Master Chef! With 39 Michelin Stars, he is the ultimate taste maker!");
			default:
				return string.Format ("We goofed!");
		}

	}

	/* Converts a number into a nice... ordinal value. So 1 becomes First!
	 * Numbers above three will just append the correct suffix onto the
	 * string representation of the number
	 */
	private string numberToOrdinal(int i) {
		if (i == 1) {
			return "first";
		}
		else if (i == 2) {
			return "second";
		}
		else if(i == 3) {
			return "third";
		}
		else if (i > 20 && (i % 10 == 1)) {
			return i.ToString() + "st";
		}
		else if (i > 20 && (i % 10 == 2)) {
			return i.ToString() + "nd";
		}
		else {
			return i.ToString() + "th";
		}
	}

	// A string which will provide a clear transition 
	public string transition(string player, string meal) {
		return string.Format ("The judges will now taste {0}'s {1}", player, meal);
	}

	// Kind of gross but I have to make it respond to ALL OF the scenarios
	public string midJudgingText(Vector2 points) {
		// The text that plays depends on points
		if (points.x == 0 && points.y == 0) {
			return "And now, the judges will weigh in!!";
		} else if (points.x == 1 && points.y == 0) {
			return "It looks like an early lead for man. Perhaps the second of our two judges will see it differently?";
		} else if (points.x == 1 && points.y == 1) {
			return "Going into the mystery judge deadlocked. It could NOT be more exciting than this!";
		} else if (points.x == 0 && points.y == 1) {
			return "The machine looks to be out to an early lead here but will it stay that way? Perhaps the next judge will take to the human's dish a bit more";
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

