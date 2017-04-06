using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweet : Judge {

	public CookTimer timer;

	public static string IMAGE_NAME = "Sweet_Sprite";
	public static string NAME = "Gustavo's Hermano";
	private static float[] STAT_MODS = {2.0f, 1.25f, .25f, 0.0f, 1.0f, .9f};	// Stat modifiers for the judge
	private static int JUDGE_ID = 3;

	// Passes some values up to the judge constructor
	public override void init() {
		base.init(STAT_MODS, NAME, IMAGE_NAME,JUDGE_ID); 	// Pass up the food chain
	}
		
	// This is the judges pregame talk. The idea here is to take a phrase randomly from a phrasebook
	public override string preGameTalk(){
		string[] phraseBook = {"*A spanish guitar riff plays* GOD DAMN IT I'M NOT MY BROTHER!"
		, "Ever since I was young Gustavo always got more candy than me. You could say I'm making up for lost time!"};
		return phraseBook [Random.Range (0, phraseBook.Length)];
		}

	// This method handles the judge giving comments while they evaluate each meal.
	public override string judgeComments (float mealScore, string mealName) {
		if (mealScore < 12f) {
			return "*I am not my brother, this is HIS type of food";
		} else if (mealScore <= 12f && mealScore <= 20f) {
			return "*Eyes Water + Sparkle*";
		} else {
			return "*squees loudly* SOOOO GOOOOD!!!!!!";
		}
	}

	// This method handles the dialogue the judge gives once they have decided whom they will award points to
	public override string andTheWinnerIs(string chefName, string mealName, float mealScore) {
		if (mealName == "tiramisu") {
			return string.Format ("I LOOOOOOOOVE TIRAMISU. HOW COULD I NOT VOTE FOR IT!!! :3");
		}
		return string.Format ("I... I think I will go for {0} and their delictable {1}!", chefName, mealName);
	}

}
