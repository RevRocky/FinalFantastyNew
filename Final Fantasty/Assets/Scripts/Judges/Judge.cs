using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Judge : MonoBehaviour {
	public string nameJudge;
	
	public CookTimer timer;

	public enum State {
		CALCULATE,
		TALK
	}
	
	public const int NUM_STATS = 6;
	public string name;
	public float[] statModifiers;
	private DialogueHolder dHolder;
	public float sumStats;

	void Start(){
		dHolder = FindObjectOfType<DialogueHolder>();
	}
	// Initialisation Function
	public void init(float[] statModifiers, string name, float sumStats) {
		this.statModifiers = statModifiers;	// Assigning a judges stat mods
		this.name = name;
		this.sumStats = sumStats;
	}
	
	// Computes a weighted sum of stats. Card stats is the a given players'
	// card while modifiers is the overpowering flavour modifiers from
	// their opponents submission;
	public float CalculateStats(byte[] cardStats, float[] modifiers){
		// Initialise i and sum
		int i = 0;
		float sum = 0;

		
		for(; i < NUM_STATS; i++) {
			sum += statModifiers[i] * (cardStats[i] + modifiers[i]);
		}

		sumStats = sum;
		return sumStats;
	}

	public void Talk() {
		nameJudge = "Sweet";
		dHolder.theName = nameJudge;
		dHolder.theSum = sumStats;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Returns a copy of the judges stat modifiers. Needed by the AI
	// <3 Rocky
	public float[] getStatModifiers(){
		return statModifiers;
	}
}
