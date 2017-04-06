using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

/*
 * A script which manages the Mise En Place
 */
public class MiseEnPlace : CardCollection {

	private static MiseEnPlace _instance;											// Private copy of instance	
	public static MiseEnPlace instance												// Tracks present instance of the Hand. Now we can use it everywhere
	{
		get    
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.

			if(_instance == null)
				_instance = GameObject.FindObjectOfType<MiseEnPlace>();
			return _instance;
		}
	}

	// Initialise base class
	public void Start() {
		base.init();
	}

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

	// On drop we only want to allow the card to join if it is both not a meal
	// and if there is enough capacity to allow the card to display
	public override void OnDrop(PointerEventData eventData) {
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		Card droppedCard;

		// If we actually have an object let us do something with this
		if (d != null) {
			droppedCard = d.gameObject.GetComponent<Card>();	// Obtain reference to the card

			if (getCollectionSize() < CAPACITY) {
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

	