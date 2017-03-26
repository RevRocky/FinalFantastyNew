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
	
	public const int NUM_STATS = 6;
	public string name;
	private float[] statModifiers;
	private DialogueHolder dHolder;
	public float sumStats;

	// Some paramaters for the mystery judges
	// TODO: Ensure these parameters are fair!
	private static float MYSTERY_STAT_MIN = 0.66f;
	private static float MYSTERY_STAT_MAX = 1.75f;

	void Start(){
		dHolder = FindObjectOfType<DialogueHolder>();
	}

	// Needed so the override works properly in the child classes.
	public abstract void init();
	
	// Initialisation Function
	public void init(float[] statModifiers, string name, float sumStats) {
		this.statModifiers = statModifiers;	// Assigning a judges stat mods
		this.name = name;
		this.sumStats = sumStats;
	}

	// Generate's a mystery judge with randomised stats and attaches it to the supplied parent
	// TODO Move to it's own class
	public static Judge generateMysteryJudge(GameObject parent) {
		Judge magicMysteryJudge = parent.AddComponent<Judge>() as Judge;
		magicMysteryJudge.name = "Mysterious Man";
		magicMysteryJudge.statModifiers = new float[6];
		
		// Generate some random stats
		for (int i = 0; i < NUM_STATS; i++) {
			magicMysteryJudge.statModifiers[i] = Random.Range(MYSTERY_STAT_MIN, MYSTERY_STAT_MAX);
		}

		return magicMysteryJudge;	
	}

	// This handles a judges dialogue before the game
	public abstract string preGameTalk();

	// Handles judge dialogue as they are evaluating food
	public abstract string judgeComments(float mealscore, string mealName);

	// Handles the judge giving a point to their favoured meal (the dialogue side of it anyway
	public abstract string andTheWinnerIs(string chefName, string mealName, float mealScore);


	
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
