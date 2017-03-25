using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	private DialogueManager dMan;
	public string[] dialogueLines;
	public string theName;
	public float theSum;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			//dMan.ShowBox(dialogue);
			if (!dMan.dialogActive)
			{
				dMan.dialogLines = dialogueLines;
				dMan.ShowDialogues();
			}
			else
			{
				if(dMan.currentLine == 2){
					dMan.dText.text= "I'm judge" + theName;
				}
				else if (dMan.currentLine == 3){
					dMan.dText.text= "Your score is" + theSum;
				}
			}
		}
		
	}

}
