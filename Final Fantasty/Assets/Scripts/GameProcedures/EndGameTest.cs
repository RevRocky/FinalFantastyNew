using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTest : MonoBehaviour {

	// This will put the end game scene through it's paces!
	void Start () {
		byte[] playerStats = { 0, 2, 3, 1, 2, 3 };
		byte[] playerOverpower = { 1, 0, 2, 0, 0, 0 };
		byte[] aiStats = { 0, 1, 2, 1, 2, 1 };
		byte[] aiOverpower = { 0, 0, 0, 1, 0, 0 };

		JudgeManager jManage = this.gameObject.AddComponent<JudgeManager>();
		jManage.init ();
		PlayerSubmission playerSub = new PlayerSubmission("User", "Spaghetti Marinara", playerStats, playerOverpower, null);
		PlayerSubmission aiSub = new PlayerSubmission("Friend", "Rigatoni alla Vodka", aiStats, aiOverpower, null);
		MealSubmissionHolder holder = this.gameObject.AddComponent<MealSubmissionHolder>();
		holder.init (playerSub, aiSub);

		// Announcer is attached to this object too
		FinalJudgingSceneManager manage = this.gameObject.GetComponent<FinalJudgingSceneManager>();
		manage.init ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
