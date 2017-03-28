using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;

/*
 * Perhaps a bit dirty and quick but this script will
 * call the shots for the final judging scene! This script
 * will assume the existence of the judge manager, the two
 * player submissions as well as the three judges.
 * Author: Rocky Petkov
 */
public class FinalJudgingSceneManager : MonoBehaviour {


	public Image judgeSprite;	// Handles the rendering of the judge images
	public Text nameBox;				// The name box.
	public Text mainTextBox;			// This is where the talking goes!

	private string SPRITE_DIR = Path.DirectorySeparatorChar + "Art" + Path.DirectorySeparatorChar + "Judge" + Path.DirectorySeparatorChar;
	private Announcer announcerDude;
	private JudgeManager judgeStable;	// Reference to our stable of judges.
	private MealSubmissionHolder submissions;	// Our submissions. For safekeeping!
	private Vector2 points;						// X value for player, Y value for AI
	private const int NUM_JUDGES = 3;

	// The start method will act as the brains for the entire operation!
	void Start () {
		judgeStable = judgeManager.instance;	// Grabbing reference to our Judge Manager
		submissions = MealSubmissionHolder.instance;
		announcerDude = AnnouncerDude.instance;
		points = new Vector2 (0, 0);
		preJudging (); // Handles the procedrual announcements away from judging
		mainJudging ();
		postJudging ();
	}

	// Displays the announcer with a few pre judging announcements
	void preJudging() {
		judgeSprite = IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + announcerDude.spriteLocation);
		nameBox.text = announcerDude.name;
		mainTextBox.text = announcerDude.preJudgingText ();
		// TODO WAIT FOR INPUT;
	}


	// Handles all of the judging!
	void mainJudging() {
		int i;
		Judge[] judgeList = judgeStable.getAllJudges();
		Judge currentJudge;
		float playerScore;
		float aiScore;

		for (i = 0; i < 3; i++) {
			judgeSprite = IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + announcerDude.spriteLocation);
			nameBox.text = announcerDude.name;
			mainTextBox.text = announcerDude.midJudgingText (points);

			// Display name and judge
			judgeSprite = IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + judge.getSpriteLocation ());	// Load Sprite		

			playerScore = currentJudge.evaluateCard (submissions.player.stats, submissions.ai.overpoweringMods);	// Score player's dish
			mainTextBox.text = currentJudge.judgeComments(playerScore, submissions.player.cardTitle);	// Give comment

			// TODO WAIT FOR PLAYER INPUT
			aiscore = currentJudge.evaluateCard (submissions.ai.stats, submissions.player.overpoweringMods);	// Score friend's dish
			mainTextBox.text = currentJudge.judgeComments(aiScore, submissions.ai.cardTitle);					// Give comment on friend's dish

			// TODO WAIT FOR PLAYER INPUT
			if (playerScore > aiScore) {
				points.x += 1;	// Add a point
				mainTextBox.text = currentJudge.andTheWinnerIs (submissions.player.owner, submissions.player.cardTitle, playerScore); // Let the player know
			}
			else {
				// AI has earned the point
				points.y += 1;	// Add a point
				mainTextBox.text = currentJudge.andTheWinnerIs (submissions.ai.owner, submissions.ai.cardTitle, aiScore); // Let the player know
			}
			// TODO WAIT FOR PLAYER INPUT
		}
	}

	// Handles the sprites and everything after judging is complete!
	void postJudging() {
		judgeSprite = IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + announcerDude.spriteLocation);
		nameBox.text = announcerDude.name;
		mainTextBox.text = announcerDude.postJudgingText (points);
		// TEAR DOWN AND GO TO NEW SCENE
		Debug.Log ("Need to go to new scene");
	}
}
