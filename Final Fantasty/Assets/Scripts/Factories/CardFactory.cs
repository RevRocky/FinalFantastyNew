using UnityEngine;

public class CardFactory : MonoBehaviour {
	
	public GameObject CardPrefab;					// Drag over in editor
	private static CardFactory _instance;

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

	// Creates a card prefab object and returns it.
	public GameObject create() {
		return Instantiate(CardPrefab);
	}
}