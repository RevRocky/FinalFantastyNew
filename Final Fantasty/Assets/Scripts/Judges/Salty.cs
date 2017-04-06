using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salty : Judge {

	public CookTimer timer;

	public static string IMAGE_NAME = "Salty_Sprite";
	public static string NAME = "Tuzlu";
	private static float[] STAT_MODS = {1.0f, 1.0f, .25f, 1.0f, 2.0f, 1.0f};	// Stat modifiers for the judge
	private static int JUDGE_ID = 0;
		
	// Passes some values up to the judge constructor
	public override void init() {
		base.init(STAT_MODS, NAME, IMAGE_NAME,JUDGE_ID); 	// Pass up the food chain
	}

	// This is the judges pregame talk. The idea here is to take a phrase randomly from a phrasebook
	public override string preGameTalk(){
		string[] phraseBook = {"Salt brings out the flavours. So really, I'm the flavour judge, ya feel?",
								"*Inaudible over the screams of fangirls*"};
		return phraseBook [Random.Range (0, phraseBook.Length)];
	}

	// This method handles the judge giving comments while they evaluate each meal.
	public override string judgeComments (float mealScore, string mealName) {
		if (mealScore < 18f) {
			return "Bland. Pfft. What are you, British?";
		}
		else if (mealScore <= 18f && mealScore <= 30f) {
			return string.Format("I'd say you've done decently with {0}. It's good but... it needs some work for sure.", mealName);
		}
		else {
			return "That explosion you heard... was my tastebuds (and the throbbing hearts of my many fans!";
		}
	}

	// This method handles the dialogue the judge gives once they have decided whom they will award points to
	public override string andTheWinnerIs(string chefName, string mealName, float mealScore) {
		if (mealScore > 30.0f) {
			return string.Format ("{0},You know a thing or two! I like your style.", chefName);
		}
		return string.Format("It's tough but I think I'll have to give the edge to {1} with their {0}!", mealName, chefName);
	}
}