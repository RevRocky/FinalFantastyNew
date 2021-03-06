using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class CookZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public Text textBox;
	public string message;
	public IEnumerator messageRoutine;
	public GameObject buttonBox;
	public List<int> buttonInt;
	private bool noButton;
	private GameObject cookButton;
	private IngredientStack cardStack;

	// Use this for initialization
	void Start () {
		noButton = false;
		cardStack = new IngredientStack(); 
	}

	// TODO REMOVE. THIS IS ONLY FOR TEST BUILD!
	void Update() {
		if (cardStack.getCount() < 2 && noButton) {
			GameObject.Destroy (cookButton);
			noButton = !noButton;
		}
	}
			

	public void OnPointerEnter(PointerEventData eventData) {
		//Debug.Log("OnPointerEnter");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
			d.placeholderParent = this.transform;
		}
	}

	public void OnPointerExit(PointerEventData eventData) {
		Debug.Log("OnPointerExit");
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d == null) {																				// TODO Is the check (d.placeholderParent==this.transform) really necessary
			d.placeholderParent = d.parentToReturnTo;
		}
		else {
			Card removedCard = d.gameObject.GetComponent<Card>();
			cardStack.removeCard(removedCard);
			if(cardStack.getCount() < 2 && noButton == true){
				Destroy(cookButton); 																// TODO Figure out a better way to go about this!
				noButton = false;
			}
		}
	}

	public void OnDrop(PointerEventData eventData) {
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
																			
		if (d == null){
			return;
		}
		else {
			Card droppedCard = d.gameObject.GetComponent<Card>();									// Get reference to the card
			if (droppedCard.getType() != "Meal") {
				cardStack.addCard(droppedCard);														// Add to card stack
				d.parentToReturnTo = this.transform;												// Return to this game object!

				foreach (Mechanic mechanic in droppedCard.getMechanics()) {
					mechanic.onPlayEnter();																// Fire it off!
				}

				if (cardStack.getCount() >= 2 && noButton==false) {
					CookingButton aButton = CookingButton.createButton(this);							// Create a button!	
					cookButton = aButton.gameObject;													// Get the associated game object!	
					noButton = true;
				}
			}
		}
	}

	// Returns a reference to the card stack
	public IngredientStack getCardStack() {return cardStack;}
	
}