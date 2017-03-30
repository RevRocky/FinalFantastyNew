using UnityEngine;
using System.Collections;

/*
 * Holds everything that is necessary
 * to reproduce dialogue to the player
 * Author: Rocky Petkov
 */
public struct DialogueTriple {

	public Sprite sprite;	// Who to show
	public string name;		// Who's speaking
	public string dialogue;	// What they're saying

	//Little Constructor
	public DialogueTriple(Sprite sprite, string name, string dialogue) {
		this.sprite = sprite;
		this.name = name;
		this.dialogue = dialogue;
	}
}


