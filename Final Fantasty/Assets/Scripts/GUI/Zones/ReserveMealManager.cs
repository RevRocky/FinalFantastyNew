using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;


/*
 * Handles all of the meals currently in the reserve area.
 * The card which has been in the area the longest will automatically
 * be sent to compost
 * Author: Rocky Petkov
 */
public class ReserveMealManager : CardCollection {

	private static ReserveMealManager _instance;											// Private copy of instance	
	public static ReserveMealManager instance												// Tracks present instance of the RMM. Now we can use it everywhere
	{
		get    
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.

			if(_instance == null)
				_instance = GameObject.FindObjectOfType<ReserveMealManager>();
			return _instance;
		}
	}

	// Just set up the list o cards!

	// This method adds the supplied card to the reserve meal queue.
	public override void addCard(Card newCard){
		addToCollection(newCard);

		// If the queue is at it's limit, remove oldest card!
		if (getCollectionSize() == CAPACITY) {
			Card removedCard = popFirstCard();
			GameObject.Destroy (removedCard.gameObject);	// Destroy the game object associated iwth the top card
		}
	}

	// Handles a card being dropped in this zone!
	public void OnDrop(PointerEventData eventData){
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		Card droppedCard;

		// If we actually have an object let us do something with this
		if (d != null) {
			droppedCard = d.gameObject.GetComponent<Card>();	// Obtain reference to the card

			if (droppedCard.getType () == "Meal") {
				d.parentToReturnTo = this.transform;
				addCard (droppedCard);		// Adds a card. Will automatically remove a card
				// TODO Warn the player?
			}
		}
	}

	// Ensures that a card is correctly removed from the queue when dragged out of this zone!
	public override void OnPointerExit(PointerEventData eventData) {
		base.OnPointerExit (eventData);
		// Mark card for deletion
	}
}


