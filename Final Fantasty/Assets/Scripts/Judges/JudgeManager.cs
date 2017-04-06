using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Think of this class as being somewhat of the...
 * stable for our judges. Ensuring that they operate in
 * an orderly fashion. This class is intended to be loaded
 * when the loading screen is shown and will persist to almost
 * the end of the game
 *
 * Note Judge Categories follow the same Sweet, Sour, Bitter, Spicy, Salty, Umami Ordering
 * Authors: Rocky Raccoon, Katherine Le
 * Version: 2
 */
public class JudgeManager : MonoBehaviour {

	private const int NUM_JUDGES = 3;
	private static JudgeManager _instance;											// Private copy of instance	
	public static JudgeManager instance												// Tracks present instance of the JudgeManager
	{
		get    
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<JudgeManager>();
			return _instance;
		}
	}

	private Judge[] judgeList;
	SpriteRenderer spriteRender;	// TODO: Should this be in the judge manager or it's own script

	// Upon Initialisation, Load up the judges... then sit and wait
	// NOTE: Sprite will be loaded in the OnGameOver method
	public void Start() {
		DontDestroyOnLoad (this.gameObject);
		Sprite sprite = Resources.Load<Sprite>("chief") as Sprite;	// TODO depreciate with better art
		judgeList = new Judge[3];
		selectJudges();
	}

	// Generates two judges with informed pallette and one which is a wildcard!
	private void selectJudges() {
		int i;
		int randJudge;
		Judge newJudge;

		// We only generate the first two judges in the following manner
		for (i = 0; i < NUM_JUDGES - 1; i++) {
			do {
				randJudge = (int) Random.Range(0, 5);	// TODO: Change to 6 once the final judge is implemented
			} while (i == 1 && judgeList[0].judgeID == randJudge);			//judge already exists
			switch (randJudge) {
				case(0):
					newJudge = gameObject.AddComponent<Sweet> () as Sweet;
					newJudge.init ();
					judgeList [i] = (Judge)newJudge;
					break;
				case(1):
					newJudge = gameObject.AddComponent<Sour> () as Sour;
					newJudge.init ();
					judgeList [i] = (Judge)newJudge;
					break;
				case(2):
					newJudge = gameObject.AddComponent<Spicy> () as Spicy;
					newJudge.init ();
					judgeList [i] = (Judge)newJudge;
					break;
				case(3):
					newJudge = gameObject.AddComponent<Salty> () as Salty;
					newJudge.init ();
					judgeList [i] = (Judge)newJudge;
					break;
				case(4):
					newJudge = gameObject.AddComponent<Umami> () as Umami;
					newJudge.init ();
					judgeList [i] = (Judge)newJudge;
					break;
			}
		}
		judgeList[i] = MysteryJudge.generateMysteryJudge(this.gameObject);
	}

	// Returns a reference to the two judges who have publicly known tastes!
	public Judge[] getPublicJudges() {
		Judge[] publicJudges = new Judge[2];	// Creating the empty array
		publicJudges[0] = judgeList[0];
		publicJudges[1] = judgeList[1];
		return publicJudges;
	}

	// Please dont call anywhere inappropriate.
	// This gets reference to all of the judges
	public Judge[] getAllJudges() {
		return judgeList;
	}
}