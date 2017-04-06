using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sour : Judge {

	public CookTimer timer;

	public static string IMAGE_NAME = "Sour_Sprite";
	public static string NAME = "Enigmelle";	// TODO We need a better name
	private static float[] STAT_MODS  = {1.5f, 2.5f, 1.0f, 1.0f, .750f, .50f};	// Stat modifiers for the judge, sour is the second index
	private static int JUDGE_ID = 1;

	// Passes some values up to the judge constructor
	public override void init() {
		base.init(STAT_MODS, NAME, IMAGE_NAME,JUDGE_ID); 	// Pass up the food chain
	}

	// This is the judges pregame talk. The idea here is to take a phrase randomly from a phrasebook
	public override string preGameTalk(){
		string[] phraseBook = {"Finish this: Your knowledge, I hope you will scour\n" +
			"For a meal that I will wish to devour.\nIf you don't use lemon or lime,\nYou'll be wasting your time.\n" +
			"For the food I like is rather..."};
		return phraseBook [Random.Range(0, phraseBook.Length)];
	}

	// This method handles the judge giving comments while they evaluate each meal.
	public override string judgeComments (float mealScore, string mealName) {
		if (mealScore < 15f) {
			return "You imbicile. Do you not understand Limericks?";
		}
		else if (mealScore <= 15f && mealScore <= 30f) {
			return "... It's okay I suppose.";
		}
		else {
			return "Good at cooking... AND LIMERICKS *Eyes water with glee*";
		}
	}

	// This method handles the dialogue the judge gives once they have decided whom they will award points to
	public override string andTheWinnerIs(string chefName, string mealName, float mealScore) {
		if (mealScore > 30.0f) {
			return string.Format ("{0}, You have brought a joy to my life and tounge that I had not felt for a while. So I'll give you the my favour", chefName);
		}
		return string.Format("I think I like the {0} just a little bit more!", mealName);
	}
}