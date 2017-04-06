using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umami : Judge {
	public CookTimer timer;

	public static string IMAGE_NAME = "Umami_Sprite";
	public static string NAME = "Lumberjane";
	private static float[] STAT_MODS = {1.0f, 1.05f, 1.25f, 1.0f, 1.0f, 2.0f};	// Stat modifiers for the judge
	private static int JUDGE_ID = 4;

	// Passes some values up to the judge constructor
	public override void init() {
		base.init(STAT_MODS, NAME, IMAGE_NAME,JUDGE_ID); 	// Pass up the food chain
	}

	// This is the judges pregame talk. The idea here is to take a phrase randomly from a phrasebook
	public override string preGameTalk(){
		// IF WE COULD MAKE THIS HAPPEN I would be so happy!
		string[] phraseBook = {"*grunts loudly before taking a bite of their kebab*, Oh, I'm supposed to speak?"};
		return phraseBook [Random.Range (0, phraseBook.Length)];
	}

	// This method handles the judge giving comments while they evaluate each meal.
	public override string judgeComments (float mealScore, string mealName) {
		if (mealScore < 25f) {
			return string.Format("I can't complain. Better than squrrel meat", mealName);
		}
		else if (mealScore <= 25f && mealScore <= 35f) {
			return string.Format("Who knew I would like {0} so much?", mealName);
		}
		else {
			return "Oh, my, god. I've missed food like this ever since I've gone up to the Yukon.";
		}
	}

	// This method handles the dialogue the judge gives once they have decided whom they will award points to
	public override string andTheWinnerIs(string chefName, string mealName, float mealScore) {
		if (mealScore > 30.0f) {
			return string.Format ("{0}, come north with me, we could use a cook like you in our camp", chefName);
		}
		return string.Format("Two good meals, I really cant be choosy, but I'm being asked to so I'll give the nod to {0} and their {1}", chefName, mealName);
	}
}
