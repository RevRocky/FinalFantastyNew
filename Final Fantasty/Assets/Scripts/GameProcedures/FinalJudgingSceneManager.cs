using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine;

/*
 * Perhaps a bit dirty and quick but this script will
 * call the shots for the final judging scene! This script
 * will assume the existence of the judge manager, the two
 * player submissions as well as the three judges.
 * Author: Rocky Petkov
 */
public class FinalJudgingSceneManager : DialogueManager {

	private MealSubmissionHolder submissions;	// Our submissions. For safekeeping!
	private Vector2 points;						// X value for player, Y value for AI
	private const int NUM_JUDGES = 3;
	bool waiting = false;								// Waiting for something?

	// The start method will act as the brains for the entire operation!
	// Not actually... an init. Only for testing
	public override void init () {
		base.init ();
		submissions = MealSubmissionHolder.instance;
		points = new Vector2 (0, 0);
		preJudging (); // Handles the procedrual announcements away from judging
		mainJudging ();
		postJudging ();
	}

	// Displays the announcer with a few pre judging announcements
	void preJudging() {
 		dialogueQueue.Enqueue (new DialogueTriple (IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + announcerDude.spriteLocation), announcerDude.name, announcerDude.preJudgingText()));
	}


	// Handles all of the judging!
	void mainJudging() {
		Judge[] judgeList = judgeStable.getAllJudges();
		float playerScore;
		float aiScore;
		string playerResponseText;
		string aiResponseText;
		string winnerText;

		// Ugly ugly ugly
		foreach (Judge currentJudge in judgeList) {
			dialogueQueue.Enqueue (new DialogueTriple(IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + announcerDude.spriteLocation), announcerDude.name, announcerDude.midJudgingText (points)));

			// Judge player and queue dialogue
			playerScore = currentJudge.evaluateCard (submissions.player.stats, submissions.ai.overpoweringMods);	// Score player's dish
			playerResponseText = currentJudge.judgeComments(playerScore, submissions.player.cardTitle);
			dialogueQueue.Enqueue (new DialogueTriple(IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + currentJudge.getSpriteLocation()), currentJudge.name, playerResponseText));

			// Judge ai and queue dialogue
			aiScore = currentJudge.evaluateCard (submissions.ai.stats, submissions.player.overpoweringMods);	// Score friend's dish
			aiResponseText = currentJudge.judgeComments(aiScore, submissions.ai.cardTitle);					// Give comment on friend's dish
			dialogueQueue.Enqueue (new DialogueTriple(IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + currentJudge.getSpriteLocation()), currentJudge.name, aiResponseText));

			// Who won?
			if (playerScore > aiScore) {
				points.x += 1;	// Add a point
				winnerText = currentJudge.andTheWinnerIs (submissions.player.owner, submissions.player.cardTitle, playerScore); // Let the player know
			}
			else {
				// AI has earned the point
				points.y += 1;	// Add a point
				winnerText = currentJudge.andTheWinnerIs (submissions.ai.owner, submissions.ai.cardTitle, aiScore); // Let the player know
			}
			dialogueQueue.Enqueue (new DialogueTriple(IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + currentJudge.getSpriteLocation()), currentJudge.name, winnerText));
		}
	}

	// Handles the sprites and everything after judging is complete!
	void postJudging() {
		dialogueQueue.Enqueue (new DialogueTriple(IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + announcerDude.spriteLocation), announcerDude.name, announcerDude.postJudgingText (points)));
		StartCoroutine (manageDialogue ());
		Debug.Log ("Need to go to new scene");
	}
}
