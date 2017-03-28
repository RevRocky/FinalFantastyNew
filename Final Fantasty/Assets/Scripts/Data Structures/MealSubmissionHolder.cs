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

	void Start() {
		DontDestroyOnLoad (this.gameObject);
	}

	// Simply assigning the submissions to the attributes
	void init(PlayerSubmission playerSub, PlayerSubmission aiSub) {
		player = playerSub;
		ai = aiSub;
	}
}

