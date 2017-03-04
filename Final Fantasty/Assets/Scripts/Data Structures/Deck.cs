using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class Deck : MonoBehaviour {

	public TextAsset deckList;
	private string deckListPath = "Misc" + Path.DirectorySeparatorChar + "GameDeck.txt";		// Game Deck will always have the deck the user wants to play with
	private List<DatabaseEntry> cardList;

	public int length;
	public GameObject hand;

	// Constructs an empty deck
	public void Start() {
		cardList = new List<DatabaseEntry> ();
		constructFromList ();
	}

	// Constructs the deck from a list stored at Resources/Misc/GameDeck
	public void constructFromList() {
		string[] cardArray;														// Look into a more space efficient way
		DatabaseEntry newCard;

		char[] delimiters = {'\n'};												// Deck list delimited with a new line!
		cardArray = deckList.text.Split(delimiters);


		foreach (string cardTag in cardArray) {
			newCard = Database.instance.searchByTag (cardTag);					// Getting a copy of it's DB entry
			addCard(newCard);													// Adding it to the deck
		}
		shuffle ();																// Shuffle the deck
	}
		

	// Implements Fisher - Yates Shuffle
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

	public void Update() {
		if (Input.GetMouseButtonDown(0)) {
			drawCard ();						// Draw card if the right mouse button is down
		}
	}

	// Returns the a game object containing the top card of the deck.
	public GameObject drawCard() {
		if (length > 0) {
			DatabaseEntry drawnCardInfo = cardList [0];	
			Card drawnCard = Card.instantiateCard (drawnCardInfo, hand);		// Read card from DB
			GameObject newObject = drawnCard.gameObject;				// Get the associated game object
			cardList.RemoveAt (0);
			length--;
			return newObject;
		}
		return null;
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