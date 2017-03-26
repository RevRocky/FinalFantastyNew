using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweet : Judge {

		public CookTimer timer;

		public static string NAME = "Sweetums";
		private static float[] STAT_MODS = {2.0f, 1.25f, .25f, 1.0f, 1.0f, .9f};	// Stat modifiers for the judge
		private static float SUM;
		// Passes some values up to the judge constructor
	public override void init() {
			base.init(STAT_MODS, NAME,SUM); 	// Pass up the food chain
		}
		
	/*	// This is the judges pregame talk
	public override string preGameTalk(){
		string[] phraseBook = {"Oh... Hi *giggle*. I'm Sugar Belle *tee hee*. I LOOOOOOOOVE a good cake! Oh... I do hope one of you makes me something... delectible",
			"*annoyed* I'm Sugar Belle. I think you know what I want."
		};
		return phraseBook (phraseBook [(int)Random.Range (0, (float)(phraseBook.Length + 1))]);
		}


	public override string judgeComments (int mealScore) {
		if (mealScore < 10f) {
			return "chokes a bit* I doooooon't LIIIIKE it.";
		}
		else if (mealScore <= 15f && mealScore <= 20f) {
			return "*Eyes Water + Sparkle*";
		}
	}

	public override string andTheWinnerIs(string chefName, int mealScore, string mealName) {
		if (mealName == "tiramisu") {
			return string.Format ("I LOOOOOOOOVE TIRAMISU. HOW COULD I NOT VOTE FOR IT!!! :3");
		}
		return string.Format ("I thinnnnk I like [0] and their lovely [1]", chefName, mealName);
	}
	*/

		// Use this for initialization
		void Start () {
			
		}

		
		// Update is called once per frame
		void Update () {
			
		}
	}
