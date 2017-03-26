using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Compost : MonoBehaviour, IDropHandler {

	// When you drop something into compost, we simply remove the card from play
	public void OnDrop(PointerEventData eventData){

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
			Destroy (d.gameObject);
		}
	}

}
