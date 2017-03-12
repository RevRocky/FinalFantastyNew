using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unamy : Judge {

	private int CalStats()
	{
		
		int sum;
		int i;
		float[] favorites = {1.5, 1, 1, 1, 2};
			for(i = 0; i < 6; i++){
				sum = (stats[i] + overpoweringMods[i])*favorites[i];
			}
		return sum;
	}


	// Use this for initialization
	public void Talk() {
		Console.WriteLine(sum);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
