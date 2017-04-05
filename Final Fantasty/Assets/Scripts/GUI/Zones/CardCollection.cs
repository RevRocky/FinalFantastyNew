using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

/*
 * This is a more specialised version of dropzone
 * which allows for the ability for zones to have
 * some form of reference to the cards contained
 * within them as well as control over
 * what sorts of cards they will allow. 
 * This is largely intended to replace in most applications
 * Author: Rocky Raccoon.
 * Original Dropzone Code by: Andrew Liu
 */
 public abstract class CardCollection : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

 	public Text textBox;
 	public string message;
 	public IEnumerator messageRoutine;


 	public int CAPACITY;		// How many cards the collection can hold
 	private List<Card> collection;

	public void init() {
		collection = new List<Card> (CAPACITY);
	}


 	// What happens when we drop a card
 	public abstract void OnDrop(PointerEventData eventData);

 	// How do we go about adding a card
 	public abstract void addCard(Card newCard);

 	/* 
 	 * When we drop a new card into the zone, we want to do some
 	 * updating of it's draggable object
 	 */
 	public void OnPointerEnter(PointerEventData eventData) {
 		//Debug.Log("OnPointerEnter");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
			d.placeholderParent = this.transform;
		}
 	}

 	/*
 	 * When we drag a card out of the scene, the events
 	 * we need to transpire are more or less mechanical, We remove
 	 * the card from our list and change the game object's parent
 	 */
 	public virtual void OnPointerExit(PointerEventData eventData) {
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null && d.placeholderParent==this.transform) {
			d.placeholderParent = d.parentToReturnTo;
			Card removedCard = d.gameObject.GetComponent<Card>();
			removeCardFromCollection(removedCard);
		}
 	}

 	// Removes a reference to the card from the collection!
 	public void removeCardFromCollection(Card cardToRemove) {
 		collection.Remove(cardToRemove);
 	
 	}

 	// Adds the new card to the tail end of the collection
 	public void addToCollection(Card newCard) {
 		collection.Add(newCard);
 	}

 	// Returns a quick and clean reference to the size of the collection
	public int getCollectionSize() {return collection.Count;}

 	// Pops off the first element in the collection
 	public Card popFirstCard() {
 		Card returnCard = collection[0];	// Popping getting a reference
 		collection.RemoveAt(0);				// Removing from the list
 		return returnCard;					// Returning the card
 	}

 	// Show crazy zany messages at the player!
 	public IEnumerator ShowMessage(string text, float delay) {
		textBox.text = text;
		textBox.enabled = true;
		yield return new WaitForSeconds (delay);
		textBox.enabled = false;
	}

	// Getter method for the entire collection
	public List<Card> getCollection() {return collection;}

	// Gets just the first card of the collection
	public Card getFirstCard() {return collection[0];}

	// Updates the collection to be a new list!
	public void setCollection(List<Card> newCollection) {
		if (newCollection.Count <= CAPACITY) {
			collection = newCollection;
		}
	}

 }