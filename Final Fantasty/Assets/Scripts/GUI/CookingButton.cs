using UnityEngine;
using UnityEngine.UI;

/*
 * Handles event listening for the cook button
 */
 public class CookingButton : MonoBehaviour {

 	private CookZone parentZone;			// Tracks which Cook Zone this button is attached to
 	private Button parentButton;			// A reference to the button who owns this Event Listener


	public void Start() {
	}
 	/*
 	 * Treat this as a constructor. If you want to create a button, call this
 	 * instead of simply instanting the game object
 	 */ 
 	public static CookingButton createButton(CookZone parent) {
 		GameObject newObj = CookButtonFactory.instance.create(parent);
		CookingButton newButton = newObj.GetComponent<CookingButton> ();
		newButton.Init(parent);
		return newButton;
 	}

 	// Ensures that we have reference to the parent objects
 	public void Init(CookZone parent) {
 		parentZone = parent;
 		parentButton = GetComponent<Button>();
 		parentButton.onClick.AddListener(() => {cookCards();});
 	}

 	// A simple wrapper for the combine Cards method
 	private void cookCards() {
		parentZone.getCardStack().combineCards();
 		// Destroy button
 	}
 }