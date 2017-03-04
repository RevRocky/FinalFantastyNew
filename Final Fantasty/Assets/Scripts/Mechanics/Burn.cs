using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is intended to be a template for future mechanic
 * scripts!
 *
 * Delete before any and all builds of the game
 *
 * Remember to update the "instantiateByName Method for all new mechanics"
 */
public class Burn : Mechanic {

	public const string NAME = "Burn"
	public const string DESCRIPTION = "Finish before time is out or you'll have a charred husk!";
	public const bool INHERITABLE = false;				// An inheritable mechanic is one that is meant to act on a meal card
	public CookTimer timer;								// The timer that counts down on burn. It'll handle all the countdown stuff!

	/*
	 * Constructs a "NAME" mechanic
	 * ParentCard, description are both passed to
	 * the constructor of the parent class
	 */
	public void init(Card parentCard) {
		base.init(NAME, parentCard, DESCRIPTION, INHERITABLE);		// Call the initialisation function of the parent class
	}

	public void update() {
		// Using that short circuit AND. Whooee!
		if (getActivated() && timer.getTimeRemaining() <= 0.0) {
			// Send card to graveyard
			Debug.log("The card has been sent to the graveyard");	// Debug print until grave yard is sorted out!
		}
	}

	// This method will contain any effects that happen when a card is drawn into a player's hand
	public override void onDraw () {
		;	// Code Here
	}

	// When we enter play we want to activate the effect as well as create a timer near the card
	public override void onPlayEnter () {
		; // Code Here
	}

	// Any effects that happen when this card leaves play. Generally unpacking the impact of the 
	// on play enter method
	public override void onPlayExit(){
		;	// Code Here
	}


	// If there is still time left when the card is combined, we augment the stats of the parent
	public override void onCombine () {
		timer.stop();															// Stops the timer!
	}


	// Contains any effects that are triggered when a card is "stacked" upon another
	public override void onStack () {
		if (!getActivated()){
			activate();															// Mechanic will activate the first time it is added to stack
		}
		timer = getParent().gameObject.AddComponent<CookTimer>() as CookTimer;	// Adding the timer. It

	}

	// Contains any effects that will happen when play is over
	public override void onGameOver() {
		;	// Code Here
	}

	


}
