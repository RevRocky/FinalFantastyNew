using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spicy : Judge {
	public CookTimer timer;

	public static string NAME = "Gustavo Fernando Montoya";
	private static float[] STAT_MODS = {2.0f, 1.05f, 2.25f, 1.0f, 1.0f, 1.0f};	// Stat modifiers for the judge

	// Passes some values up to the judge constructor
	public override void init() {
			base.init(STAT_MODS, NAME); 	// Pass up the food chain
		}
		

	// This is the judges pregame talk. The idea here is to take a phrase randomly from a phrasebook
	public override string preGameTalk(){

		// If I could make this happen, I'd be so happy!
		string[] phraseBook = {"*A faint Spanish guitar riff plays.* Hola. Me nombre es Gustavo. I... I like my food like I like my romance. Hot! Passionate!",
			"*Guitar Riff Plays* The only thing I expect to see today hotter than me... is your food"
		};
		return phraseBook [(int)Random.Range (0, (float)(phraseBook.Length + 1))];
	}

	// This method handles the judge giving comments while they evaluate each meal.
	public override string judgeComments (float mealScore, string mealName) {
		if (mealScore < 10f) {
			return "No good! This food couldn't even make a bambino cry!";
		}
		else if (mealScore <= 15f && mealScore <= 20f) {
			return "*Eyes Water + Sparkle but... in a different way than Sugar Belle's*";
		}
		else {
			return "*Breathes Fire and smiles approvingly*";
			}
	}

	// This method handles the dialogue the judge gives once they have decided whom they will award points to
	public override string andTheWinnerIs(string chefName, string mealName, float mealScore) {
		if (chefName != "Friend") {
			return string.Format ("You all know that I like passion. Chef {0} really won me over with their version" +
			"of {1}. An absolutely marvelous job. *He then winks toward the you... You melt a bit", chefName, mealName);
		}
		else {
			return string.Format ("You all know that I'm no friend of the robots. I really don't like it when they win" +
			"I mean there is no passion in the purely mechanical and deterministic nature of what he does... but " +
			"I also can not ignore my taste buds. They sang for Friend's meal while I could not say that about " +
			"the other one. I'll, reluctantly, give him the point");
		}
	}
}

