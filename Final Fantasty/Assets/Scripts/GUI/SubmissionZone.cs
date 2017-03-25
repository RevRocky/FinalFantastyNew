using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

/*
 * Handles the Submission Zone. This is the zone which contains the card that
 * will be submitted for judging. 
 * Author: Rocky Raccoon
 */
public class SubmissionZone : DropZone {

	private Card submissionCard;	// The card to be submitted

	// This formally adds a card to the SubmissionZone
	public void addCard(Card newMeal) {
		if (submissionCard != null) {
			ReserveMealManager.instance.addCard(submissionCard);	// Move the card to the reserves
		}
		submissionCard = newMeal;	// TODO Handle Location?
	}

	// Handles a meal card being dropped in this area!
	// TODO Ensure this works correctly because I'm not explicitly overriding it
	public void OnDrop(PointerEventData eventData) {
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		Card droppedCard;

		// If D is actually something... and also a meal... we want it
		if (d != null) {
			droppedCard = d.gameObject.GetComponent (typeof(Card)) as Card;

			// Gross nested conditionals
			if (droppedCard.getType () == "Meal") {
				d.parentToReturnTo = this.transform;	// I wish I could tell you what this did
				addCard (droppedCard);					// Add the dropped card, only if it's a meal!
			}
		}
	}

	// A Fetch Method for the card being submitted
	public Card getCard() {
		return submissionCard;	
	}
}