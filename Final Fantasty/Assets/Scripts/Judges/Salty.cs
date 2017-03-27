using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salty : Judge {

	public CookTimer timer;


	public static string NAME = "Cap'n Blondemane";
	private static float[] STAT_MODS = {1.0f, 1.0f, .25f, 1.0f, 2.0f, 1.0f};	// Stat modifiers for the judge
		
	// Passes some values up to the judge constructor
	public override void init() {
		base.init(STAT_MODS, NAME); 	// Pass up the food chain
	}

	// This is the judges pregame talk. The idea here is to take a phrase randomly from a phrasebook
	public override string preGameTalk(){
		string[] phraseBook = {"I've sailed the seaven seas. My home is out there, among the fish and the waves. Please, chefs, take me home!"};
		return phraseBook [(int)Random.Range (0, (float)(phraseBook.Length + 1))];
	}

	// This method handles the judge giving comments while they evaluate each meal.
	public override string judgeComments (float mealScore, string mealName) {
		if (mealScore < 10f) {
			return "I've definately had better food in the galleys. *spits it out*";
		}
		else if (mealScore <= 15f && mealScore <= 20f) {
			return string.Format("I'd say you've done decently with {0}. It's good but... it needs some work for sure.", mealName);
		}
		else {
			return "*Appears lost in thought for a moment*\n" +
				"This takes me back to my days as a young scalliwag in the ports around the Mediterranean. Truely remarkable. Thank you!";
		}
	}

	// This method handles the dialogue the judge gives once they have decided whom they will award points to
	public override string andTheWinnerIs(string chefName, string mealName, float mealScore) {
		if (mealScore > 30.0f) {
			return string.Format ("{0}, I think I know the name of a few ships who would love to put you on board. Sure, you will sometimes be cooking with\n" +
				"old fish but, with your skills I don't think that'll be much of a hinderence. Anyway, let me know if you want me to put in a good word!", chefName);
		}
		return string.Format("It's tough but I think I'll have to give the edge to {0} with their {1}!", mealName, chefName);
	}
}