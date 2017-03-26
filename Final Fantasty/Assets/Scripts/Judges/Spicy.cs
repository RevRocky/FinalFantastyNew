using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spicy : Judge {
		public CookTimer timer;

		public static string NAME = "Spicy";
		private static float[] STAT_MODS = {2.0f, 1.05f, 2.25f, 1.0f, 1.0f, 1.0f};	// Stat modifiers for the judge
		private static float SUM;
		// Passes some values up to the judge constructor
		public override void init() {
			base.init(STAT_MODS, NAME,SUM); 	// Pass up the food chain
		}
		
		
		public void talk(){
			nameJudge = "Spicy";

		}
		// Use this for initialization
		void Start () {
			
		}

		
		// Update is called once per frame
		void Update () {
			
		}
	}

