using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverZoomImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

	private float zoom;
	public float zoomSpeed;
	public Image map;

	public float zoomMin;
	public float zoomMax;

	public bool isOver = false;

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("Mouse enter");
		isOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("Mouse exit");
		isOver = false;
	}

	void Update () {
		zoom = (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomSpeed);
		map.transform.localScale += new Vector3(map.transform.localScale.x * zoom, map.transform.localScale.y * zoom, 0);
		Vector3 scale = map.transform.localScale;
		scale = new Vector3(Mathf.Clamp(map.transform.localScale.x, zoomMin, zoomMax), Mathf.Clamp(map.transform.localScale.y, zoomMin, zoomMax), 0);
		map.transform.localScale = scale;
	}
}
