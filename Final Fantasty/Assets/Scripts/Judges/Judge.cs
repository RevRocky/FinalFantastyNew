using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Judge : MonoBehaviour {
	
	
	public NavMeshAgent agent;
	public ThirdPersonCharacter character;
	public CookTimer timer;

	public enum State {
		CALCULATE,
		TALK
	}
	
	public const int NUM_STATS = 6;
	public string name;
	public float[] statModifiers;
	
	// Initialisation Function
	public void init(byte[] statModifiers, string name) {
		this.statModifiers = statModifiers;	// Assigning a judges stat mods
		this.name = name;
	}
	
	// Computes a weighted sum of stats. Card stats is the a given players'
	// card while modifiers is the overpowering flavour modifiers from
	// their opponents submission;
	public float CalculateStats(byte[] cardStats, byte[] modifiers){
		// Initialise i and sum
		int i = 0;
		float sum = 0;
		
		for(; i < NUM_STATS; i++) {
			sum += statModifiers[i] * (cardStats[i] + modifiers[i]);
		}
	}

	public abstract void Talk() {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
