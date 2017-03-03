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

	public const string NAME = "OverpoweringFlavour"
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

	// Contains any effects that will happen when play is over
	// TODO: If this is the only type of mechanic that works on game over it may behoove us
	// to simply return the byte array from this method.
	public override void onGameOver() {
		byte modifiers[];
		modifiers = geneateModifiers();
		// Somehow deliver this to the packet
	}

	// Generates the Modifiers 
	private byte[] generateModifiers(){
		byte cardStats[] = getParent().getStats();	// Obtaining reference to the card's stats
		byte modifiers[] = {0, 0, 0, 0, 0, 0};
		int statsToModify[] = biggestTwoIndices(cardStats);
		// Adjust the stats
		foreach(int stat : statsToModify) {
			modifiers[stat] -= cardStats[stat];		// Naive approach. Gives the player double advantage in their best stat (MAY DIV 2)
		}
		return modifiers;
	}

	/*
	 * Returns the index of an array of bytes with the largest value. 
	 * Takes a naive approach as it will only be called with small arrays
	 */
	private int biggestTwoIndices(byte[] anArray) {
		int indexMax[] = {0, 0}		// Position Zero is largest. Position One is second largest
		int i;
		for (i = 0; i < anArray.Length ; i++) {
			if (anArray[i] > anArray[indexMax]) {
				indexMax[1] = indexMax[0];		// Update second largest
				indexMax[0] = i;				// Update largest
			}
		}
		return indexMax;
	}


}
