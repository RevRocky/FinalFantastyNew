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
public class SubmissionZone : CardCollection {

	private static SubmissionZone _instance;											// Private copy of instance	
	public static SubmissionZone instance												// Tracks present instance of the this zone!
	{
		get    
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<SubmissionZone>();
			return _instance;
		}
	}

	void Start(){
		base.init ();
	}

	// This formally adds a card to the SubmissionZone
	public override void addCard(Card newMeal) {
		if (getCollectionSize() >= CAPACITY && getCollection()[0] != newMeal) {
			Card oldCard = popFirstCard ();
			Destroy (oldCard.gameObject);
		}
		addToCollection (newMeal);
		newMeal.gameObject.transform.localPosition = new Vector3 (0, 0, 0);	// I guess this works.
	}

	// Handles a meal card being dropped in this area!
	// TODO Ensure this works correctly because I'm not explicitly overriding it
	public override void OnDrop(PointerEventData eventData) {
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		Card droppedCard;

		// If D is actually something... and also a meal... we want it
		if (d != null) {
			droppedCard = d.gameObject.GetComponent (typeof(Card)) as Card;

			// Gross nested conditionals
			if (droppedCard.getType () == "Meal") {
				Destroy (d.getPlaceholder ().gameObject);	// Destroy the placeholder object created
				d.parentToReturnTo = this.transform;	// I wish I could tell you what this did
				addCard (droppedCard);					// Add the dropped card, only if it's a meal!
			}
		}
	}

	// A Fetch Method for the card being submitted
	public Card getCard() {
		return getFirstCard();	
	}
}