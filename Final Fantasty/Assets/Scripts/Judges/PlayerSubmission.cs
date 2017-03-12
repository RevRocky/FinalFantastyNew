using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
 * A simple struct containing the information necessary
 * for a player's submission to the judges. This will be
 * created at the completion of a player's turn.
 */
public struct PlayerSubmission {
	public string owner;				// Whose card is this
	public string cardTitle;			// Name of submitted card
	public byte[] stats;				// Card stats
	public byte[] overpoweringMods;		// Modifiers for overpowering flavour
	public Sprite cardImage;			// Incase you want a picture

	// Fairly Straight Forward Constructor
	public PlayerSubmission(string owner, string cardTitle, byte[] stats, byte[] overpoweringMods, Sprite image) {
		this.owner = owner;
		this.cardTitle = cardTitle;
		this.stats = stats;
		this.overpoweringMods = overpoweringMods;
		this.cardImage = image;
	}
}