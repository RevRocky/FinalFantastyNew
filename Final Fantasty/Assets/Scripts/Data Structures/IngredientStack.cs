using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;												// TODO find System.Drawing alternative or set up unity to work with it!
using System.IO;


/* This is a class that contains some static methods that will permit the
 * generation of meal card images based upon the stats of the generated card.
*/
public class IngredientStack {

	private List<Card> theCards;
	public const int NUM_STATS=6;
	public const string MEAL_IMAGE_DIRECTORY =  "..";

	public IngredientStack() {
		theCards = new List<Card>();
	}

	// Adds a card to our stack
	public void addCard(Card newCard) {
		theCards.Add(newCard);
		executeMechanics (newCard);
	}

	// Small method that will call the mechanics of the card added to the stack
	private void executeMechanics(Card newCard) {
		foreach (Mechanic mechanic in newCard.getMechanics()) {
			// Mechanics will only do anything if they have not been activated
			mechanic.onStack ();
			mechanic.onPlayEnter ();
		}
	}

	// Removes a card from our list of cards
	public void removeCard(Card oldCard) {
		bool theBest = theCards.Remove(oldCard);				// Removing a card object that matches the one we've passed in!
		return;
	}

	/*
	 * Dynamically combines the stack of cards in to one meal card and delivers that object to where
	 * it needs to go.
	 * Presently assumes that card stats are in a 6-tuple and that tags of meal cards are listed in sorted order.
	 */
	public void combineCards() {
		int j;
		string artLocation;												// Obtained either through DB retrieval or combination of images
																		// Contains a database entry pertaining to the meal being generated
		DatabaseEntry mealEntry = null;									// This will always be instantiated!
		string searchTag = "";
		byte[] sumStats = new byte[NUM_STATS]  {0, 0, 0, 0, 0, 0};
		string[] tags = new string [theCards.Count];					// The tags for each card
		List<string> mechanicList = new List<string> ();

		// Loop over cumulating mechanics, stats and tags for each of our cards
		int i = 0;
		foreach (Card card in theCards) {
			byte[] cardStats = card.getStats();
			for (j = 0; j < NUM_STATS; j++) {
				sumStats [j] += cardStats[j];							// Taking the sum of each stat
			}
			tags[i] = card.ingredientTag;											// Adding the tag to the list
			foreach (Mechanic mechanic in card.getMechanics()) {
				if (! mechanic.inheritable) {
					mechanicList.Add(mechanic.getName());				// If the mechanic can be inherited add the name!			
				}
			}
			i++;
		}
		Array.Sort(tags, StringComparer.InvariantCulture);				// Sort dem tags
		foreach (string tag in tags) {
			searchTag += tag; 											// Combine those tags
		}
		try {
			mealEntry = Database.instance.searchByTag(searchTag);		// Returns a clone of the database entry
			mealEntry.stats = combineStatsGood(mealEntry.stats, sumStats);
			mealEntry.mechanics = combineMechanicsGood(mealEntry.mechanics, mechanicList);
		}
		catch (ItemNotFound e) {
			artLocation = ImageProcessing.hybridCardArt(theCards);		// A static method which will create a hybrid card art quickly and efficiently!
			byte[] mealStats = combineStatsBad(sumStats);				// Combines the stats and adds heavy penalty to the stats
			mechanicList = addBadMechanic(mechanicList);				// Adding a negative side effect to our cards
			string type = "Meal";										// Don't want it being passed in as a "Magic number"
			string name = searchTag;									// TODO Think of a better way to procedrually name this!
			mealEntry = new DatabaseEntry(name, type, artLocation,
							mechanicList, mealStats);					// Create a database entry for this card					
		}	
		finally {
			Card.instantiateCard(mealEntry);							// Instantiate the card prefab (or what ever it is called)
			int loopMax = theCards.Count;
			for (i = 0; i < loopMax; i++) {
				Card card = theCards[0];
				theCards.RemoveAt (0);
				GameObject.Destroy (card.gameObject);
			}
		}
	}

	// Combines stats of the ingredients with the bonuses bestowed by the meal card
	private byte[] combineStatsGood(byte[] baseStats, byte[] ingredientStats) {
		int j;
		for (j = 0; j < NUM_STATS; j++) {
			baseStats[j] += ingredientStats[j];			// Taking the sum of each stat
		}
		return baseStats;								// I want to make the assignment explicit above											
	}

	// Adds some hefty negative stats to the meals created by the ingredients
	private byte[] combineStatsBad(byte[] baseStats) {
		return baseStats; 								// TODO What stat penalties should be applied
	}

	// Combines any mechanics the ingredients have with the list of mechanics of the meal.
	// TODO implement instantiateMechanics
	private List<string> combineMechanicsGood(List<string> baseMechanics, List<string> ingredientMechanics) {					
		List<string> newMechanics = new List<string>(baseMechanics.Count + ingredientMechanics.Count);			// Creating a static sized buffer
		newMechanics.AddRange(baseMechanics);
		newMechanics.AddRange(ingredientMechanics);
		return newMechanics;
	}


	// Randomly adds a negative side-effect to
	private List<string> addBadMechanic(List<string> ingredientMechanics) {
		return ingredientMechanics;		// TODO Come up with negative side-effects
	}

	// Returns how many cards are in the stack!
	public int getCount () {
		return theCards.Count;
	}
}
