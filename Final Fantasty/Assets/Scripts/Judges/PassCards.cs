using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCards : MonoBehaviour {
	//Pass card to scene
	void Awake() {
		DontDestroyOnLoad(transform.Card);
	}
}
