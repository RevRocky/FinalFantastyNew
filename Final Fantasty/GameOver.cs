using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A Script Containing a Series of Methods which are intended
 * to run once the game is over. This script will be responsible
 * for everything up until the Judges get involved
 */

public class GameOver : MonoBehaviour {

	PlayerSubmission AISubmission;		// AI's card
	PlayerSubmission userSubmission;	// Player's Card

	// The script will "Start" once the Game is Over.
	void Start () {
		userSubmission = collectPlayersCard ();	// This will also call any on Game Over Attributes on mechanics
		AISubmission = Friend.instance.getSubmission();	// Look at the AI. He just has his shit together. You, you human do not.
		//TODO  Pass this information to the judge manager
		// This means I need a fully implemented Judge manager
	}

	/*
	 * Collects a reference to the Player's Card Objects. Fires off any onGameOver mechanics
	 * and constructs a player submission of their card as well as any Overpowering Flavour
	 * Modifications
	 */
	private PlayerSubmission collectPlayersCard() {
		
	}
		
}
