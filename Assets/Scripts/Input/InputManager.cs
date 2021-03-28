using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerKeyBoardInput))]
[RequireComponent(typeof(PlayerUiInput))]
public class InputManager : MonoBehaviour
{
	public static InputManager instance;

	private Iinput _playerKeyBoardInput;
	private Iinput _playerUiInput;

	//public Dragger dragger;

	private bool _isDragging = false;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}

		Dragger.OnDraggingValueChanged += OnDraggingValueChanged;
	}

	private void Start()
	{
		_playerKeyBoardInput = GetComponent<PlayerKeyBoardInput>();
		_playerUiInput = GetComponent<PlayerUiInput>();
	}

    private void OnDestroy()
    {
		Dragger.OnDraggingValueChanged -= OnDraggingValueChanged;
	}

    private void OnDraggingValueChanged(bool isDragging)
    {
		this._isDragging = isDragging;
    }

	public int GetHorizontalValue()
	{
		if (this._isDragging == true)
		{
			return 0;
		}

		if (_playerKeyBoardInput.GetHorizontalValue() != 0)
			return _playerKeyBoardInput.GetHorizontalValue();
		else
			return _playerUiInput.GetHorizontalValue();
	}

	public bool IsJumpButtonPressed()
	{
        if(this._isDragging == true)
        {
			return false;
        }

		if (_playerKeyBoardInput.GetJumpValue() == 0 && _playerUiInput.GetJumpValue() == 0)
			return false;
		else
			return true;
	}

	private void Update()
	{
//	   Debug.Log("Horizontal Value Input " + GetHorizontalValue() + "  Jump  " + IsJumpButtonPressed());
	}
}
