using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomControl : MonoBehaviour {

	public float zoomSize = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Mouse Scroll") > 0) {

			if(zoomSize > 2)
			zoomSize -= 1;
		}

		if (Input.GetAxis ("Mouse Scroll") < 0) {
			if(zoomSize < 4)
			zoomSize += 1;
		}
		GetComponent<Camera> ().orthographicSize = zoomSize;
	}
}
