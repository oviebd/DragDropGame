using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragger : MonoBehaviour, IDragHandler
{
	[SerializeField] private RectTransform draggingRectTransform;

	public void OnDrag(PointerEventData eventData)
	{
		Debug.Log("Dragging .........");
		draggingRectTransform.anchoredPosition += eventData.delta;
	}

	/*public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("Dragging .........");
		draggingRectTransform.anchoredPosition += eventData.delta;
	}*/
}
