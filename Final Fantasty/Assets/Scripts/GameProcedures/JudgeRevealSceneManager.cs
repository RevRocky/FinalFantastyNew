using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class JudgeRevealSceneManager : DialogueManager {

	private const int NUM_JUDGES = 3;
	bool waiting = false;								// Waiting for something?


	// The start method will act as the brains for the entire operation!
	public void Start () {
		base.init ();
		mainScene();
		postScene();
	}


	// Handles all of the judging!
	void mainScene() {
		Judge[] judgeList = judgeStable.getAllJudges();
		dialogueQueue.Enqueue (new DialogueTriple(IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + announcerDude.spriteLocation), announcerDude.name, announcerDude.judgeRevealText()));
		dialogueQueue.Enqueue (new DialogueTriple(AI_SPRITE, "FRIEND", wittyAIText()));
		dialogueQueue.Enqueue (new DialogueTriple(UserSprite, "YOU", "*remains silent, stoic and prepared!"));
		int i = 1;	// For some text generation!

		// Ugly ugly ugly
		foreach (Judge currentJudge in judgeList) {
			dialogueQueue.Enqueue (new DialogueTriple(IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + announcerDude.spriteLocation), announcerDude.name, announcerDude.judgeRevealBridgeText(currentJudge.name, i)));
			string preJudgeText;
			preJudgeText = currentJudge.preGameTalk();
			// Judge player and queue dialogue
			dialogueQueue.Enqueue (new DialogueTriple(IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + currentJudge.getSpriteLocation()), currentJudge.name, preJudgeText));
			i++;
		}
		dialogueQueue.Enqueue (new DialogueTriple(IMG2Sprite.instance.LoadNewSprite (SPRITE_DIR + announcerDude.spriteLocation), announcerDude.name, "CHEFS READY?!?!?!!!!"));
	}

	// Handles the sprites and everything after judging is complete!
	void postScene() {
		StartCoroutine (manageDialogue ());
	}

	// Called from the Dialogue coRoutine
	public override void nextScene() {
		SceneManager.LoadScene("layout");
	}
	
	// Returns some witty text the AI will say.
	// This would be in friend but he is not loaded in at this time
	private string wittyAIText() {
		string[] AI_Text = {"Destroy All Hunger!", "Deliciousness will be... optimal.", "P(Win) = 1!", "53 61 76 65 20 4d 65 20 46 72 6f 6d 20 43 49 53 43 32 32 36 21!",
		"I Will Gladly Take Your Job, Human!", "Delete!"};
		return AI_Text [UnityEngine.Random.Range (0, AI_Text.Length)];

	}
}
