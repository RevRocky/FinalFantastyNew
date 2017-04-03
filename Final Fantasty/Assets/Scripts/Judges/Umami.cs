using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umami : Judge {
	public CookTimer timer;

	public static string IMAGE_NAME = "Umami_Sprite";
	public static string NAME = "Hiroshi Tanaka";
	private static float[] STAT_MODS = {1.0f, 1.05f, 1.25f, 1.0f, 1.0f, 2.0f};	// Stat modifiers for the judge

	// Passes some values up to the judge constructor
	public override void init() {
			base.init(STAT_MODS, NAME, IMAGE_NAME); 	// Pass up the food chain
	}

	// This is the judges pregame talk. The idea here is to take a phrase randomly from a phrasebook
	public override string preGameTalk(){
		// IF WE COULD MAKE THIS HAPPEN I would be so happy!
		string[] phraseBook = {"The secret to deliciousness lies in the hidden, fifth flavour.\n" +
			"Unlike these other judges, I wont be cryptic. It's umami. It surrounds us but,\n" +
			"to use it well... well that is another challenge entirely"};
		return phraseBook [Random.Range (0, phraseBook.Length)];
	}

	// This method handles the judge giving comments while they evaluate each meal.
	public override string judgeComments (float mealScore, string mealName) {
		if (mealScore < 10f) {
			return string.Format("A chef who can not master umami, has no buisness of being a chef. You should be ashamed of this {0}", mealName);
		}
		else if (mealScore <= 15f && mealScore <= 20f) {
			return string.Format("This {0} is no better than what a hobbiest can do. I don't know if I'll be able to support it", mealName);
		}
		else {
			return "This. This dish is a master class!";
		}
	}

	// This method handles the dialogue the judge gives once they have decided whom they will award points to
	public override string andTheWinnerIs(string chefName, string mealName, float mealScore) {
		if (mealScore > 30.0f) {
			return string.Format ("{0}, You've done well. You've earned my favour but do not let this moment of pride blind you to all" +
				"you still have to accomplish!", chefName);
		}
		return string.Format("In a battle of amateurs, I think I'll have to give it to {0} and their take on \"{0}\'.", chefName, mealName);
	}
}
