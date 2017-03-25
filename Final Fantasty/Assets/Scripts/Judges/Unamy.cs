using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unamy : Judge {
		public CookTimer timer;


		public static string NAME = "Unami";
		private static float[] STAT_MODS = {1.0f, 1.05f, 1.25f, 1.0f, 1.0f, 2.0f};	// Stat modifiers for the judge
		
		// Passes some values up to the judge constructor
		public void init() {
			base.init(STAT_MODS, NAME); 	// Pass up the food chain
		}

		public void talk(){
			nameJudge = "Unami";

		}
		

		// Use this for initialization
		void Start () {
			
		}

		
		// Update is called once per frame
		void Update () {
			
		}
	}
