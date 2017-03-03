using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Implements the AlDente functionality
 * On activate it will have a timer tick down.
 * Should the card containing this be combined before the timer
 * reaches zero, it will cause a positive effect on the resulting meal
 * 
 * Version: 0.1
 * Author: Rocky Petkov 
 */
public class AlDente : Mechanic {

	public const int NUM_STATS = 6;

	public const string NAME = "AlDente";
	public const string DESCRIPTION = "Combine this card into a meal before time is up for Great Rewards";
	public const bool INHERITABLE = false;
	
	private CookTimer timer; 


	/*
	 * Constructs an AlDente mechanic
	 * ParentCard, description are both passed to
	 * the constructor of the parent class
	 */
	public void init(Card parentCard) {
		base.init(NAME, parentCard, DESCRIPTION, INHERITABLE);		// Call the initialisation function of the parent class
	}

	// This method will contain any effects that happen when a card is drawn into a player's hand
	public override void onDraw () {
		;															// It does nothing when drawn in to one's hand
	}

	//	Nothing is called when the card simply enters play (into a holding zone)
	public override void onPlayEnter () {
		;
	}

	// Contains any effects that are triggered when a card is "stacked" upon another
	public override void onStack () {
		if (!getActivated()){
			activate();															// Mechanic will activate the first time it is added to stack
		}
		timer = getParent().gameObject.AddComponent<CookTimer>() as CookTimer;	// Adding the timer.														// Nothing happens if we stack a card!
	}

	// If there is still time left when the card is combined, we augment the stats of the parent
	public override void onCombine () {
		timer.stop();											// Stop the timer
		if (timer.getTimeRemaining() > 0.0) {
			getParent().setStats(boostStats());					// Replace card stats with boosted ones
		}		
	}
	// Boosts the stats of the parent card by 1 each. 2 for the highest stat
	// Accurate only for a test implementation
	private byte[] boostStats() {
		byte[] newStats = getParent().getStats();				// Getting the parent's stats
		int maxStatIndex = maxIndex(newStats);					// Index of the highest stat!
		int i;													// A loop counter
		for (i = 0; i < NUM_STATS; i++) {
			if (i == maxStatIndex) {
				newStats[i] += 2;								// Increment biggest stat by 2
			}
			else {
				newStats[i] += 1;								// Increment other stats by 1
			}
		}
		return newStats;
	}

	/*
	 * Returns the index of an array of bytes with the largest value. 
	 * Takes a naive approach as it will only be called with small arrays
	 */
	private int maxIndex(byte[] anArray) {
		int indexMax = 0;
		int i;
		for (i = 0; i < anArray.Length ; i++) {
			if (anArray[i] > anArray[indexMax]) {
				indexMax = i;
			}
		}
		return indexMax;
	}
}
