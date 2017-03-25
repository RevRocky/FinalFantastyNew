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
public class ReserveMealManager : DropZone {

	public int CAPACITY;				// How many meals can be in the reserve zone
	private List<Card> compostQueue;	// I'm not precisely sure what would be the best way to do this

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

	// This method adds the supplied card to the reserve meal queue.
	public void addCard(Card newCard){
		compostQueue.Add (newCard);
		// TODO Look at how to visually indicate the card scheduled for deletion

		// If the queue is at it's limit, remove oldest card!
		if (compostQueue.Count == CAPACITY) {
			Card removedCard = compostQueue [0];
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
	public void OnPointerExit(PointerEventData eventData) {

		// If the data is nill return
		if (eventData.pointerDrag == null) {
			return;
		}

		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d == null) {
			return;		// If there's no draggable return
		}

		Card removedCard = d.gameObject.GetComponent<Card> ();	// Acquiring reference to the card
		removeSpecificCard (removedCard);
		if (compostQueue.Count < CAPACITY) {
			// TODO UNMARK CARD
			;
		}
	}

	// Removes the a reference to the supplied card from the queue on Dragout
	private void removeSpecificCard(Card specificCard) {
		compostQueue.Remove (specificCard);		// Removes the card
	}
		






}
