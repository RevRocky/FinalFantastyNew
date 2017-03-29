using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Judge : MonoBehaviour {
	public string nameJudge;
	
	public enum State {
		CALCULATE,
		TALK
	}
		
	private string spriteLocation;
	public const int NUM_STATS = 6;
	public string name;
	private float[] statModifiers;
	public float sumStats = 0;

	void Start(){
	}

	// Needed so the override works properly in the child classes.
	public abstract void init();
	
	// Initialisation Function
	public void init(float[] statModifiers, string name, string spriteLocation) {
		this.statModifiers = statModifiers;	// Assigning a judges stat mods
		this.name = name;
		this.spriteLocation = spriteLocation;
	}

	// This handles a judges dialogue before the game
	public abstract string preGameTalk();

	// Handles judge dialogue as they are evaluating food
	public abstract string judgeComments(float mealScore, string mealName);

	// Handles the judge giving a point to their favoured meal (the dialogue side of it anyway
	public abstract string andTheWinnerIs(string chefName, string mealName, float mealScore);



	// Computes a weighted sum of stats. Card stats is the a given players'
	// card while modifiers is the overpowering flavour modifiers from
	// their opponents submission;
	public float evaluateCard(byte[] cardStats, byte[] modifiers){
		// Initialise i and sum
		int i = 0;
		float sum = 0;
		for(; i < NUM_STATS; i++) {
			sum += statModifiers[i] * (cardStats[i] + modifiers[i]);
		}
		sumStats = sum;
		return sumStats;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// Returns a copy of the judges stat modifiers. Needed by the AI
	// <3 Rocky
	public float[] getStatModifiers(){
		return statModifiers;
	}

	// Returns the locaion of the card's sprite
	public string getSpriteLocation() {return spriteLocation;}
}
