using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeManager : MonoBehaviour {

	public static JudgeManager instance = null;
	public string[] judgeCats = {"sweet", "sour", "spicy", "salty", "unamy"};
	public Judge[] judges;		// Judges one and two known to the player
	Judge judgeTwo;
	private int currentIndex = 0;


	// Use this for initialization
	void Awake () {
		if(instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
		RandomJudge();

	
		
	}
	//Choose a random judge script---not complete
	private void RandomJudge(){
		judges = new Judge[3];
		int randJudge;
		for (int i = 0; i < 3; i++) {
			randJudge = 0;		// Should be random. For testing purposes! 
			switch (randJudge) {
				case(0):
					Sweet newSweet = gameObject.AddComponent<Sweet>() as Sweet;
					newSweet.init();
					judges[i] = (Judge) newSweet;
				break;
				case(1):
					Sour newSour = gameObject.AddComponent<Sour>() as Sour;
					newSour.init();
					judges[i] = (Judge) newSour;
					break;
				case(2):
					Spicy newSpicy = gameObject.AddComponent<Spicy>() as Spicy;
					newSpicy.init();
					judges[i] = (Judge) newSpicy;
					break;
				case(3):
					Salty newSalty = gameObject.AddComponent<Salty>() as Salty;
					newSalty.init();
					judges[i] = (Judge) newSalty;
					break;
				case(4):
					Unamy newJudge = gameObject.AddComponent<Unamy>() as Unamy;
					newJudge.init();
					judges[i] = (Judge) newJudge;
					break;

			}
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
