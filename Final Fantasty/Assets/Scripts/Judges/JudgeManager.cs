using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeManager : MonoBehaviour {

	public static JudgeManager instance = null;
	private GenerateJudges genJ;


	// Use this for initialization
	void Awake () {
		if(instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
		genJ = FindObjectOfType<GenerateJudges>();


	
		
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
