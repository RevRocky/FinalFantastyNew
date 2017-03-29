using UnityEngine;
using System.Collections;

/*
 * Simple little class that allows us to conveniently
 * bring forth two player submissions to final judging
 * Author: Rocky Petkov
 */
public class MealSubmissionHolder : MonoBehaviour
{

	public PlayerSubmission player;	// Player's submission
	public PlayerSubmission ai;		// AI's submission

	private static MealSubmissionHolder _instance;											// Private copy of instance	
	public static MealSubmissionHolder instance												// Tracks present instance of the Mealsubmission holder!
	{
		get    
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<MealSubmissionHolder>();
			return _instance;
		}
	}

	void Start() {
		DontDestroyOnLoad (this.gameObject);
	}

	// Simply assigning the submissions to the attributes
	public void init(PlayerSubmission playerSub, PlayerSubmission aiSub) {
		player = playerSub;
		ai = aiSub;
	}
}

