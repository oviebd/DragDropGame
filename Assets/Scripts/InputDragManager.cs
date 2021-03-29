using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDragManager : MonoBehaviour
{

	public static InputDragManager instance;
	public List<DraggableItem> draggerList;

	private EnumUtility.InputType _activeDraggedItem = EnumUtility.InputType.NONE;

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

	private void OnDraggingValueChanged(bool isDragging, EnumUtility.InputType inputType)
	{
		_activeDraggedItem = inputType;
		SetDraggedItem(inputType);
	}

	public void SetDraggedItem(EnumUtility.InputType inputType)
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

	public EnumUtility.InputType GetActiveDraggedItem()
	{
		return _activeDraggedItem;
	}
	public void OnDragItemReachedInitialPosition()
	{
		_activeDraggedItem = EnumUtility.InputType.NONE;
		for (int i = 0; i < draggerList.Count; i++)
		{
			draggerList[i].SetDragAbility(true);
		}
	}
}
