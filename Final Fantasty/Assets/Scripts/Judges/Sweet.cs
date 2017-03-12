using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class Sweet : MonoBehaviour {

		public NavMeshAgent agent;
		public ThirdPersonCharacter character;
		public CookTimer timer;

		public enum State {
			CALCULATE,
			TALK
		}

		public State state;

		//Variables for Calculating
		int Sweet 


		//Variables for Talking

		private byte[] boostStats() {
		byte[] newStats = getParent().getStats();				
		int maxStatIndex = maxIndex(newStats);				
		int i = 2;												
		if (i == maxStatIndex) {
				newStats[i] += 2;							
		}
			else {
				newStats[i] += 1;					
			}
		}
		return newStats;
	}

		// Use this for initialization
		void Start () {
			
		}

		
		// Update is called once per frame
		void Update () {
			
		}
	}
}
