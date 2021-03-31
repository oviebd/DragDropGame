using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//This Items can be moved freely 
public class InputTypeDraggedItems : DraggableItem
{

	private bool _isColliding = false;
	protected override void onDragEnded(PointerEventData eventData)
	{
		if (_isColliding)
		{
			GoBackToButtonState();
		}
		else
		{
			GoBackToGameItemState();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		_isColliding = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		_isColliding = false;
	}
}
