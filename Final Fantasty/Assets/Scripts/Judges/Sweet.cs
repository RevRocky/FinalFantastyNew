using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweet : Judge {

		public NavMeshAgent agent;
		public ThirdPersonCharacter character;
		public CookTimer timer;

		public enum State {
			CALCULATE,
			TALK
		}

		public State state;
		public static string NAME = "Sweetums";
		private static float[] STAT_MODS = {2.0f, 1.25f, .25f, 1.0f, 1.0f, .9f};	// Stat modifiers for the judge
		
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
