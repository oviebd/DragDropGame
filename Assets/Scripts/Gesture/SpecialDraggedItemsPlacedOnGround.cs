using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpecialDraggedItemsPlacedOnGround : DraggableItem
{
	[SerializeField]
	private LayerMask layerMask = new LayerMask();
	protected override void onDragEnded(PointerEventData eventData)
	{
		Vector2 pos = CheckRayCast();
		if(pos!= Vector2.zero)
		{
			this.transform.position = pos;
			GoBackToGameItemState();
		}
		else
		{
			GoBackToButtonState();
		}
	}


	public Vector3 CheckRayCast()
	{
		Vector3 fromPosition = transform.position;
		fromPosition.y = fromPosition.y - 1.0f;
		Vector3 direction = new Vector3(0, -100, 0);
	//	Debug.DrawRay(fromPosition, direction, Color.green);
		RaycastHit2D hit2D = Physics2D.Raycast(fromPosition, direction);
		if (hit2D.collider != null)
		{
			if (IsThisLayerCollidable(hit2D.collider.gameObject))
			{
				//	Debug.DrawRay(fromPosition, direction, Color.red);
				return hit2D.point;
			}
		}
		return Vector2.zero;
	}

	public bool IsThisLayerCollidable(GameObject collidedObj)
	{
		if ((layerMask.value & 1 << collidedObj.layer) != 0)
			return true;
		return false;
	}

}
