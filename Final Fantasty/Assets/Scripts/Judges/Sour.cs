﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sour : Judge {

		public CookTimer timer;

		public enum State {
			CALCULATE,
			TALK
		}

		public State state;
		public static string NAME = "SourMood";
		private static float[] STAT_MODS = {1.0f, 2.0f, .25f, 1.0f, 1.0f, 1.0f};	// Stat modifiers for the judge, sour is the second index
		
		// Passes some values up to the judge constructor
		public void init() {
			base.init(STAT_MODS, NAME); 	// Pass up the food chain
		}
		
		

		// Use this for initialization
		void Start () {
			
		}

		
		// Update is called once per frame
		void Update () {
			
		}
	}