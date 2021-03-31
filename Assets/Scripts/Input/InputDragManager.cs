using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDragManager : MonoBehaviour
{

	public static InputDragManager instance;
	public List<DraggableItem> draggerList;

	private EnumUtility.DraggedItemType _activeDraggedItem = EnumUtility.DraggedItemType.NONE;

	private void Awake()
	{
		if (instance == null)
			instance = this;

		DraggableItem.OnDraggingValueChanged += OnDraggingValueChanged;
	}
	private void OnDestroy()
	{
		DraggableItem.OnDraggingValueChanged -= OnDraggingValueChanged;
	}

	private void OnDraggingValueChanged(bool isDragging, EnumUtility.DraggedItemType inputType)
	{
		_activeDraggedItem = inputType;
		SetDraggedItem(inputType);
	}

	public void SetDraggedItem(EnumUtility.DraggedItemType inputType)
	{
		for(int i = 0; i < draggerList.Count; i++)
		{
			draggerList[i].SetDragAbility(false);
			if (draggerList[i].inputType == inputType)
			{
				draggerList[i].SetDragAbility(true);
			}
		}
	}

	public EnumUtility.DraggedItemType GetActiveDraggedItem()
	{
		return _activeDraggedItem;
	}
	public void OnDragItemReachedInitialPosition()
	{
		
		for (int i = 0; i < draggerList.Count; i++)
		{
		/*	if (draggerList[i].inputType == _activeDraggedItem)
			{
				draggerList[i].transform.parent = this.gameObject.transform;
			}*/
			draggerList[i].SetDragAbility(true);
		}
		_activeDraggedItem = EnumUtility.DraggedItemType.NONE;
	}
}
