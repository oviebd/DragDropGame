using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpecialDraggedItemsPlacedOnGround : DraggableItem
{
	[SerializeField] private LayerMask groundLayer = new LayerMask();
	[SerializeField] private LayerMask playerLayer = new LayerMask();
	[SerializeField] private float maxActivatedTime = 5.0f;
	[SerializeField] private int maxUseNumber = 3;
	[SerializeField] private Color disableColor;
	[SerializeField] private Text remainingUseNumberText;

	private int _useNumber = 0;
	private bool _isActivated = false;
	private float _lastActivatedTime;

	private void Start()
	{
		_useNumber = 0;
		ShowRemainingText();
	}
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
		if (_isDragging)
		{
			CheckRayCast();
			remainingUseNumberText.enabled = false;
		}
	}

	protected override void GoBackToButtonState()
	{
		base.GoBackToButtonState();
		_isActivated = false;
		if(_useNumber >= maxUseNumber)
			MadeItemDisable();
		else
			MadeItemEnabled();

		ShowRemainingText();
	}

	protected override void GoBackToGameItemState()
	{
		base.GoBackToGameItemState();
		_lastActivatedTime = Time.time;
		_isActivated = true;
		_useNumber = _useNumber + 1;

		remainingUseNumberText.enabled = false;
	}

	private void ShowRemainingText()
	{
		int remaining = maxUseNumber - _useNumber;
		if (remaining < 0)
			remaining = 0;

		remainingUseNumberText.enabled = true;
		remainingUseNumberText.text = remaining + "";
	}

	private void MadeItemDisable()
	{
		this.gameObject.GetComponent<SpriteRenderer>().color = disableColor;
		_collider2D.enabled = false;
	}
	private void MadeItemEnabled()
	{
		this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		_collider2D.enabled = true;
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
		Vector3 direction = new Vector3(0, -1000, 0);
		Debug.DrawRay(fromPosition, direction, Color.green);
		RaycastHit2D hit2D = Physics2D.Raycast(fromPosition, direction);
		if (hit2D.collider != null)
		{
			Debug.DrawRay(fromPosition, direction, Color.yellow);
			Debug.Log(hit2D.collider.name);
			if (Utility.IsgameobjectIsInThisLayer(groundLayer,hit2D.collider.gameObject))
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
