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
		
		public void talk(){
			nameJudge = "Sweet";

		}

		// Use this for initialization
		void Start () {
			
		}

		
		// Update is called once per frame
		void Update () {
			
		}
	}
