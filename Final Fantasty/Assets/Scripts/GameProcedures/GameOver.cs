using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

/*
 * A Script Containing a Series of Methods which are intended
 * to run once the game is over. This script will be responsible
 * for everything up until the Judges get involved
 */

public class GameOver : MonoBehaviour {

	private static string cardArtLocation = "Art" + Path.DirectorySeparatorChar + "Meals" + Path.DirectorySeparatorChar;

	private PlayerSubmission AISubmission;		// AI's card
	private PlayerSubmission userSubmission;	// Player's Card

	// The script will "Start" once the Game is Over.
	void Start () {
		userSubmission = collectPlayersCard ();	// This will also call any on Game Over Attributes on mechanics
		AISubmission = Friend.instance.getSubmission();	// Look at the AI. He just has his shit together. You, you human do not.
		var submissions = GameObject.FindWithTag("GameOver").AddComponent<MealSubmissionHolder>();	// Create our submissions holder
		submissions.init (userSubmission, AISubmission);	// Add the player's submissions
		SceneManager.LoadScene("FinalJudgement");	// Load the next scene
	}

	/*
	 * Collects a reference to the Player's Card Objects. Fires off any onGameOver mechanics
	 * and constructs a player submission of their card as well as any Overpowering Flavour
	 * Modifications
	 */
	private PlayerSubmission collectPlayersCard() {
		Card userMeal = SubmissionZone.instance.getCard();	// Getting reference to the card
		string artLocation;
		Sprite artSprite;

		// Getting a reference to the "Food Porn" shot!
		try {
			artLocation = Database.instance.searchByTag(userMeal.getTag()).artLocation;
		}
		catch (ItemNotFound e) {
			artLocation = "Ramsay.png";
		}
		artLocation = artLocation.Split ('.') [0];
		artSprite = null;

		// Fire the ongame over mechanics
		foreach (Mechanic mechanic in userMeal.getMechanics()) {
			mechanic.onGameOver();		// Fire the Game Over mechanics
		}
		return new PlayerSubmission("User", userMeal.getName(), userMeal.getStats(), userMeal.getOverpoweringMods(), artSprite);	// Return a player submission!
	}
		
}
