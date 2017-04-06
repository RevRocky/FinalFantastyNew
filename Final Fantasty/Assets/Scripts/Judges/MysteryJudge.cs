using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryJudge : Judge {

	// Some paramaters for the mystery judges
	// TODO: Ensure these parameters are fair!
	private static float MYSTERY_STAT_MIN = 0.66f;
	private static float MYSTERY_STAT_MAX = 1.75f;
	public static float[] STAT_MODS = { 0, 0, 0, 0, 0, 0 };	//
	private static int JUDGE_ID = -1;

	public static string IMAGE_NAME = "Mystery_Sprite";
	public static string NAME = "???";

	// Passes some values up to the judge constructor
	// This constructor will never be called
	public override void init() {
		base.init(STAT_MODS, NAME, IMAGE_NAME, JUDGE_ID); 	// Pass up the food chain
	}

	// An init function that passes up the supplied stat modifiers
	public void init(float[] statMods){
		base.init (statMods, NAME, IMAGE_NAME, JUDGE_ID);
	}
		

	// Generate's a mystery judge with randomised stats and attaches it to the supplied parent
	public static Judge generateMysteryJudge(GameObject parent) {
		MysteryJudge magicMysteryJudge = parent.AddComponent<MysteryJudge>() as MysteryJudge;
		float[] randomStatMods = new float[6];

		// Generate some random stats
		for (int i = 0; i < NUM_STATS; i++) {
				randomStatMods[i] = Random.Range(MYSTERY_STAT_MIN, MYSTERY_STAT_MAX);
		}
		magicMysteryJudge.init (randomStatMods);	// Initialise the judge
		return (Judge) magicMysteryJudge;			// Cast to judge and return
			
	}

	// This is the judges pregame talk. The idea here is to take a phrase randomly from a phrasebook
	public override string preGameTalk(){

		// IF WE COULD MAKE THIS HAPPEN I would be so happy!
		string[] phraseBook = {"Hit me with your best shot!", "A true chef can have all flavours blend into a symphony", "..."};
		return phraseBook [Random.Range (0, phraseBook.Length)];
	}

	// This method handles the judge giving comments while they evaluate each meal.
	public override string judgeComments(float mealScore, string mealName) {
		if (mealScore < 20f) {
			return string.Format("I did not intend to be surprised in this fashion. For shame!", mealName);
		}
		else if (mealScore <= 20f && mealScore <= 45f) {
			return string.Format("This {0} is decent. Nothing special. I've had better. Thoug, I've also had worse", mealName);
		}
		else {
			return "Good. Excellent! Marvelous!";
		}
	}

	// This method handles the dialogue the judge gives once they have decided whom they will award points to
	public override string andTheWinnerIs(string chefName, string mealName, float mealScore) {
		if (mealScore > 35f) {
			return string.Format ("I normally hate this part of the process, but your {0} have made giving you my favour" +
				"quite easy!", mealName);
		}
		return string.Format("I suppose, I'll give {0} the nod... though, I can't say I'm terribly impressed", chefName);
	}
}
