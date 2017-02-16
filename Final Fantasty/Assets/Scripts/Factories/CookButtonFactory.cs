using UnityEngine;

public class CookButtonFactory : MonoBehaviour {
	
	public GameObject CookButtonPrefab;					// Drag over in editor
	private static CookButtonFactory _instance;

	public static CookButtonFactory instance {
		get    
		{
			//If _instance hasn't been set yet, we grab it from the scene!
			//This will only happen the first time this reference is used.
			if(_instance == null)
				_instance = GameObject.FindObjectOfType<CookButtonFactory>();
			return _instance;
		}
	}

	// Creates a cook button and returns it!
	public GameObject create(CookZone parent) {
		return Instantiate(CookButtonPrefab, new Vector3(0,0,0),new Quaternion(0,0,0,0), parent.transform);
	}
}