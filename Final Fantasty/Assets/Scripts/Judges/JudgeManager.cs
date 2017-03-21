using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeManager : MonoBehaviour {

	public static JudgeManager instance = null;
	public GameObject[] judges = {Sweet, Sour, Spicy, Salty, Unamy};
	private int currentIndex = 0;


	// Use this for initialization
	void Awake () {
		if(instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

	
		
	}
	//Choose a random judge script---not complete
	void RandomJudge(){
		int newIndex = Random.Range(0, judges.Length);
		// Deactive old gameobject
		judges[currentIndex].SetActive(false);
		//Active new gameObject
		currentIndex = newIndex;
		judges[currentIndex].SetActive(true);

	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
