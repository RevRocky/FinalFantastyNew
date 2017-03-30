using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The Overpowering Flavour mechanic will cause the judges to undervalue
 * certain stats on an opponents card. The thinking here is that meals using
 * quality ingredients are so good that it kinda floods the taste receptors.
 *
 * This mechanic will operate by attaching an additional array to the packet
 * sent from Player A to Player B which will detail the stat modifiers given as
 * a result of this mechanic being in a meal.
 *
 * Author: Rocky Petkov
 * Version: Pre Network (This File was written before networked code has been written)
 */
public class OverpoweringFlavour : Mechanic {

	public const string NAME = "OverpoweringFlavour";
	public const string DESCRIPTION = "The flavour is strong with this one";		// Rewrite!
	public const bool INHERITABLE = true;											// An inheritable mechanic is one that is meant to act on a meal card


	/*
	 * Constructs a "NAME" mechanic
	 * ParentCard, description are both passed to
	 * the constructor of the parent class
	 */
	public void init(Card parentCard) {
		base.init(NAME, parentCard, DESCRIPTION, INHERITABLE);		// Call the initialisation function of the parent class
	}

	// This method will contain any effects that happen when a card is drawn into a player's hand
	public override void onDraw () {
		;	// Code Here
	}

	// Any effects that happen when this card leaves play. Generally unpacking the impact of the 
	// on play enter method
	public override void onPlayExit(){
		;	// Code Here
	}


	// When we enter play we want to activate the effect as well as create a timer near the card
	public override void onPlayEnter () {
		; // Code Here
	}

	// If there is still time left when the card is combined, we augment the stats of the parent
	public override void onCombine () {
		;	// Code Here
	}


	// Contains any effects that are triggered when a card is "stacked" upon another
	public override void onStack () {
		;	// Code Here
	}

	/*
	 * Sets the card's overpowering flavour modifiers to a 
	 * Set of modifiers based upon the card's strongest
	 * stats
	 */
	public override void onGameOver() {
		getParent().setOverpoweringMods(generateModifiers());	// Set the modifiers of the parent to be those generated

	}

	// Generates the Modifiers 
	private byte[] generateModifiers(){
		byte[] cardStats = getParent().getStats();	// Obtaining reference to the card's stats
		byte[] modifiers = {0, 0, 0, 0, 0, 0};
		int[] statsToModify = OverpoweringFlavour.biggestTwoIndices(cardStats);

		// Adjust the stats
		foreach(int stat in statsToModify) {
			modifiers[stat] -= cardStats[stat];		// Naive approach. Gives the player double advantage in their best stat (MAY DIV 2)
		}
		return modifiers;
	}

	// Static Version of Modifier Generation for the AI
	public static byte[] generateModifiers(byte [] cardStats){
		byte[] modifiers = {0, 0, 0, 0, 0, 0};
		int[] statsToModify = OverpoweringFlavour.biggestTwoIndices(cardStats);

		// Adjust the stats
		foreach(int stat in statsToModify) {
			modifiers[stat] -= cardStats[stat];		// Naive approach. Gives the player double advantage in their best stat (MAY DIV 2)
		}
		return modifiers;
	}

	/*
	 * Returns the index of an array of bytes with the largest value. 
	 * Takes a naive approach as it will only be called with small arrays
	 */
	private static int[] biggestTwoIndices(byte[] anArray) {
		int[] indexMax = { 0, 0 };		// Position Zero is largest. Position One is second largest
		int i;
		for (i = 0; i < anArray.Length ; i++) {
			if (anArray[i] > anArray[indexMax[0]]) {
				indexMax[1] = indexMax[0];		// Update second largest
				indexMax[0] = i;				// Update largest
			}
			else if (anArray[i]  > anArray[indexMax[1]]) {
				indexMax[1] = i;				// Update just the second largest!
			}
		}
		return indexMax;
	}
}
