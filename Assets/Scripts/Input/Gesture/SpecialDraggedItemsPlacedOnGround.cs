using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpecialDraggedItemsPlacedOnGround : DraggableItem
{
	[SerializeField] private LayerMask groundLayer = new LayerMask();
	[SerializeField] private LayerMask playerLayer = new LayerMask();
	[SerializeField] private float maxActivatedTime = 5.0f;

	private bool _isActivated = false;
	private float _lastActivatedTime;
	protected override void onDragEnded(PointerEventData eventData)
	{
		_isActivated = false;
		Vector2 pos = CheckRayCast();
		if(pos != Vector2.zero)
		{
			this.transform.position = pos;
			GoBackToGameItemState();
		}
		else
		{
			GoBackToButtonState();
		}
	}

	private void Update()
	{
		if( _isDragging == false && _isActivated)
		{
			if( (Time.time - _lastActivatedTime) >= maxActivatedTime)
			{
				GoBackToButtonState();
			}
		}
	}

	protected override void GoBackToButtonState()
	{
		base.GoBackToButtonState();
		_isActivated = false;
	}

	protected override void GoBackToGameItemState()
	{
		base.GoBackToGameItemState();
		_lastActivatedTime = Time.time;
		_isActivated = true;
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (Utility.IsgameobjectIsInThisLayer(playerLayer, collision.gameObject))
		{
			if(inputType == EnumUtility.DraggedItemType.SPRING)
			{
				collision.gameObject.GetComponent<PlayerManager>().OnActivateHyperJump();
			}
		}
	}


	public Vector3 CheckRayCast()
	{
		//this.gameObject.transform.SetParent(InputDragManager.instance.gameObject.transform, true);

		Vector3 fromPosition = transform.localPosition;
		fromPosition.y = fromPosition.y - 1.0f;
		Vector3 direction = new Vector3(0, -100, 0);
		Debug.DrawRay(fromPosition, direction, Color.green);
		RaycastHit2D hit2D = Physics2D.Raycast(fromPosition, direction);
		if (hit2D.collider != null)
		{
			if(Utility.IsgameobjectIsInThisLayer(groundLayer,hit2D.collider.gameObject))
			{
				Debug.DrawRay(fromPosition, direction, Color.red);
				return hit2D.point;
			}
		}
		return Vector2.zero;
	}

	public bool IsThisLayerCollidable(GameObject collidedObj)
	{
		if ((groundLayer.value & 1 << collidedObj.layer) != 0)
			return true;
		return false;
	}

}
