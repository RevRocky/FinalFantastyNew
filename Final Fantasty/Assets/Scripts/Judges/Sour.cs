using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sour : Judge {

		public CookTimer timer;


		public static string NAME = "SourMood";
		private static float[] STAT_MODS = {1.0f, 2.0f, .25f, 1.0f, 1.0f, 1.0f};	// Stat modifiers for the judge, sour is the second index
		private static float SUM;
		// Passes some values up to the judge constructor
		public override void init() {
			base.init(STAT_MODS, NAME,SUM); 	// Pass up the food chain
		}
		
		
		public void talk(){
			nameJudge = "Sour";

		}
		// Use this for initialization
		void Start () {
			
		}

		
		// Update is called once per frame
		void Update () {
			
		}
	}