using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine;


public class JudgeRevealSceneManager : DialogueManager {

	private MealSubmissionHolder submissions;	// Our submissions. For safekeeping!
	private const int NUM_JUDGES = 3;
	bool waiting = false;								// Waiting for something?

	// The start method will act as the brains for the entire operation!
	// Not actually... an init. Only for testing
	public override void init () {
		base.init ();
		submissions = MealSubmissionHolder.instance;
		mainScene();
		postScene();
	}


	// Handles all of the judging!
	void mainScene() {
		Judge[] judgeList = judgeStable.getAllJudges();

		// Ugly ugly ugly
		foreach (Judge currentJudge in judgeList) {
			string preJudgeText;
			dialogueQueue.Enqueue (new DialogueTriple(IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + announcerDude.spriteLocation), announcerDude.name, announcerDude.judgeRevealText()));
			preJudgeText = currentJudge.preGameTalk();
			// Judge player and queue dialogue
			dialogueQueue.Enqueue (new DialogueTriple(IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + currentJudge.getSpriteLocation()), currentJudge.name, preJudgeText));
		}
	}

	// Handles the sprites and everything after judging is complete!
	void postScene() {
		StartCoroutine (manageDialogue ());
		Debug.Log ("Need to go to new scene");
	}
}
