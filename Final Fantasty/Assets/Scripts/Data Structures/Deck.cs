using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

	public TextAsset deckList;					// A text file containing each card in the text asset!
	private List<DatabaseEntry> cardList;
	public int length;
	public GameObject hand;

	// Constructs an empty deck
	public void Start() {
		
	}

	// TODO create a constructor which reads in a list of cards and creates a deck that way

	// Implements Fisher - Yates Sort
	public void shuffle() {
		DatabaseEntry temp;
		int random;
		for (int i = 0; i < cardList.Count; i++) {
			random = Random.Range(i, cardList.Count);
			temp = cardList[i];
			cardList[i] = cardList[random];
			cardList [random] = cardList [i];
		}
	}

	// When we click down on the collider we want to draw a card
	public void OnMouseDown() {
		drawCard();					// We can disregard the game object in this case
	}

	// Returns the a game object containing the top card of the deck.
	public GameObject drawCard() {
		DatabaseEntry drawnCardInfo = cardList[0];	
		Card drawnCard = Card.instantiateCard(drawnCardInfo, hand);		// Read card from DB
		GameObject newObject = drawnCard.gameObject;				// Get the associated game object
		cardList.RemoveAt(0);
		length--;
		return newObject;
	}

	// Adds a card to the bottom of the deck
	public void addCard(DatabaseEntry newCard) {
		cardList.Add(newCard);
		length++;			// Increment our length
	}

	// Adds a card to the index specified of the deck
	public void addCard(DatabaseEntry newCard, int index) {
		cardList.Insert(index, newCard);
		length++;
	}


}