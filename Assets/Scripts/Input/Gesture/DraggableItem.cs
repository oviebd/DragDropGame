using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils.Gesture;

public abstract class DraggableItem : GestureRecognizerBase
{
	public EnumUtility.DraggedItemType inputType;

    public delegate void OnDraggingStarted(bool isDragging,EnumUtility.DraggedItemType inputType);
    public static event OnDraggingStarted OnDraggingValueChanged;
	private bool _canDraggable = true;

    private Vector3 _initialPosition;
    private Collider2D _collider2D;

	protected abstract void onDragEnded(PointerEventData eventData);

	private void Awake()
    {
        _initialPosition = this.transform.localPosition;
        _collider2D = this.gameObject.GetComponent<Collider2D>();
    }

 
	private bool CanDockToInitialPosition(Vector3 position)
	{
		this.gameObject.transform.SetParent(InputDragManager.instance.gameObject.transform, true);
		float distance =Mathf.Abs(Vector3.Distance(transform.localPosition,_initialPosition));
		this.gameObject.transform.parent = null;

		if (distance <= 1.5)
			return true;

		return false;
	}

	public void SetDragAbility(bool canDrag)
	{
		_canDraggable = canDrag;
	}

    protected void GoBackToButtonState()
    {
        _collider2D.isTrigger = true;
		InputDragManager.instance.OnDragItemReachedInitialPosition();
		this.gameObject.transform.SetParent(InputDragManager.instance.gameObject.transform, true);
		this.transform.localPosition = _initialPosition;
	}

    protected void GoBackToGameItemState()
    {
        _collider2D.isTrigger = false;
    }

	protected override void onDraggingStarted(PointerEventData eventData)
	{
		if (_canDraggable == false)
			return;

		_collider2D.isTrigger = true;
		OnDraggingValueChanged?.Invoke(true, inputType);
	}
	protected override void onDragging(Vector3 draggingPoint, PointerEventData eventData)
	{
		if (_canDraggable == false)
			return;

		transform.parent = null;
		OnDraggingValueChanged?.Invoke(true, inputType);
		//Debug.Log("drag pos " + eventData.pointerCurrentRaycast.worldPosition);
		if (eventData.pointerCurrentRaycast.worldPosition != Vector3.zero)
		{
			transform.position = eventData.pointerCurrentRaycast.worldPosition;
		}
		
		//transform.position = draggingPoint;
	}
	protected override void onEndDragging(PointerEventData eventData)
	{
		if (_canDraggable == false)
			return;

		OnDraggingValueChanged?.Invoke(false, inputType);

		if (CanDockToInitialPosition(eventData.pointerCurrentRaycast.worldPosition))
		{
			GoBackToButtonState();
			return;
		}
		onDragEnded(eventData);
	}
}
