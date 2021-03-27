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

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
	}

	private void Start()
	{
		_playerKeyBoardInput = GetComponent<PlayerKeyBoardInput>();
		_playerUiInput = GetComponent<PlayerUiInput>();
	}



	public int GetHorizontalValue()
	{
		if (_playerKeyBoardInput.GetHorizontalValue() != 0)
			return _playerKeyBoardInput.GetHorizontalValue();
		else
			return _playerUiInput.GetHorizontalValue();
	}

	public bool IsJumpButtonPressed()
	{
		if (_playerKeyBoardInput.GetJumpValue() == 0 && _playerUiInput.GetJumpValue() == 0)
			return false;
		else
			return true;
	}

	private void Update()
	{
	 //  Debug.Log("Horizontal Value Input " + GetHorizontalValue() + "  Jump  " + IsJumpButtonPressed());
	}
}
