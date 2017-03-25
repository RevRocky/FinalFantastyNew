using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateJudges : MonoBehaviour {
	SpriteRenderer sprite;
	public string[] judgeCats = {"sweet", "sour", "spicy", "salty", "unamy"};
	public Judge[] judges;		// Judges one and two known to the player
	private int currentIndex = 0;

	// Use this for initialization
	void Start () {
		//Get the sprite
		Sprite sprite = Resources.Load<Sprite>("chief") as Sprite;

		//create judge 1
		GameObject judgeOne = RandomJudge("Generate judge 1");
		judgeOne.name = "judgeOne";
		judgeOne.transform.parent = this.gameObject.transform;
		judgeOne.AddComponent<SpriteRenderer>();
		SpriteRenderer SR1 = judgeOne.GetComponent<SpriteRenderer>();
        	SR1.sprite = sprite;
		judgeOne.transform.position = new Vector2(-350,-188);//change vector later

		//create judge 2
		GameObject judgeTwo = RandomJudge("Generate judge 2");
		judgeTwo.name = "judgeTwo";
		judgeTwo.transform.parent = this.gameObject.transform;
		judgeTwo.AddComponent<SpriteRenderer>();
		SpriteRenderer SR2 = judgeTwo.GetComponent<SpriteRenderer>();
        	SR2.sprite = sprite;
		judgeTwo.transform.position = new Vector2(-14,14);//chang vector later

		//create judge 3
		GameObject judgeThree = RandomJudge("Generate judge 3");
		judgeThree.name = "judgeThree";
		judgeThree.transform.parent = this.gameObject.transform;
		judgeThree.AddComponent<SpriteRenderer>();
		SpriteRenderer SR3 = judgeThree.GetComponent<SpriteRenderer>();
        	SR3.sprite = sprite;
		judgeThree.transform.position = new Vector2(0,14);//change vector later


		
	}
		//Error
		//This script meant to attach random script to each of the object above
		GameObject RandomJudge(string NJ){
			GameObject judge;
			judge = new GameObject();
			int randJudge;

			for (int i = 0; i < 3; i++) {
				randJudge = 0;		// Should be random. For testing purposes! 
				switch (randJudge) {
					case(0):
						judge = new GameObject("sweet");
						Sweet sweet = judge.AddComponent<Sweet> as Sweet;
						return judge;

					case(1):
						judge = new GameObject("sour");
						Sour sour = judge.AddComponent<Sour> as Sour;
						return judge;
					case(2):
						judge = new GameObject("spicy");
						Spicy spicy = judge.AddComponent<Spicy> as Spicy;
						return judge;
					case(3):
						judge = new GameObject("salty");
						Salty salty = judge.AddComponent<Salty> as Salty;
						return judge;
					case(4):
						judge = new GameObject("unamy");
						Unamy unamy = judge.AddComponent<Unamy> as Unamy;
						return judge; 

				}
			}

		}
	
	// Update is called once per frame
	void Update () {
		
	}
}
