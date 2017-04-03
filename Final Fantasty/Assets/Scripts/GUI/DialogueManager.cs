using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine;


/*
 * An abstract class which manages some of the common behaviours
 * of all scenes which have dialogue!
 * Author: Rocky Raccoon
 */
public abstract class DialogueManager : MonoBehaviour
{

	public Sprite AI_SPRITE;
	public Sprite UserSprite;
	public Queue<DialogueTriple> dialogueQueue;	// Where upcomming dialogue is stored
	public Image judgeSprite;	// Handles the rendering of the judge images
	public Text nameBox;				// The name box.
	public Text mainTextBox;			// This is where the talking goes!

	public string SPRITE_DIR = "Art" + Path.DirectorySeparatorChar + "Judge" + Path.DirectorySeparatorChar;
	public Announcer announcerDude;
	public JudgeManager judgeStable;	// Reference to our stable of judges.

	public virtual void init() {
		dialogueQueue = new Queue<DialogueTriple> ();
		judgeStable = JudgeManager.instance;	// Grabbing reference to our Judge Manager
		announcerDude = Announcer.instance;
	}

	// This is the first of a series of coroutines meant to handle the processing of dialogue!!!

	// This is a top level co routine which simply calls the dialogue coroutine on the next bit of dialogue to be spoken
	public IEnumerator manageDialogue() {
		while (dialogueQueue.Count > 0) {
			yield return speakDialogue (dialogueQueue.Dequeue ());
		}
		nextScene ();
	}

	// Unpacks the bundle and speaks it!
	public IEnumerator speakDialogue(DialogueTriple dialogueBundle) {
		judgeSprite.sprite = dialogueBundle.sprite;
		nameBox.text = dialogueBundle.name;
		mainTextBox.text = dialogueBundle.dialogue;
		yield return StartCoroutine(waitForKeyPress (KeyCode.Space));
	}

	// Waits for someone to hit a supplied key before returning
	public IEnumerator waitForKeyPress(KeyCode continueKey) {
		while (!Input.GetKeyDown(continueKey)) {
			yield return null;
		}
		yield return new WaitForFixedUpdate ();
	}

	// Plays the next scene
	public abstract void nextScene();
			
}

