using UnityEngine;

public class CardFactory : MonoBehaviour {
	
	public GameObject CardPrefab;					// Drag over in editor
	private static CardFactory _instance;
	public GameObject mealZone;						// For cards with no parent

	public static CardFactory instance {
		get    
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<CardFactory>();
			return _instance;
		}
	}

	public GameObject create() {
		return create (mealZone);
	}
		
	// Creates a card prefab object and returns it.
	public GameObject create(GameObject parent) {
		Transform myT = parent.transform;
		return Instantiate (CardPrefab, parent.transform);
	}
}