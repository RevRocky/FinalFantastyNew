using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

/*
 * A script which manages the User's Hand
 */
public class Hand : CardCollection {

	/*
	 * Adds a card to the User's Hand. It will throw an exception
	 * if the hand has more than 5 cards
	 */
	public override void addCard(Card newCard) {
		if (getCollectionSize() >= CAPACITY) {
			throw new HandSizeException ("Can not draw to a full hand!");
		}
		addToCollection (newCard);
	}

	public overide void onDrop(Card newCard) {
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		Card droppedCard;

		// If we actually have an object let us do something with this
		if (d != null) {
			droppedCard = d.gameObject.GetComponent<Card>();	// Obtain reference to the card

			if (droppedCard.getType () != "Meal") {
				try {
				d.parentToReturnTo = this.transform;
				addCard (droppedCard);
				}
				catch (HandSizeException e) {
					// Perhaps display the message somehow?
					return;
				}
			}
		}
	}
}

	