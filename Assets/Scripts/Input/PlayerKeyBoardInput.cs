using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyBoardInput : InputBase, Iinput
{
	public int GetJumpValue()
	{
		return jumpValue;
	}

	public int GetHorizontalValue()
	{
		return horizontalValue;
	}

	private void Update()
	{
		horizontalValue = GetVerticalInputValue();
		jumpValue = GetJumpInputValue();
		//Debug.Log("Verrticakl Input " + verticalValue);
	}

	private int GetVerticalInputValue()
	{
		int result = 0;
		if (Input.GetKey(KeyCode.A))
		{
			result = -1;
		}
		if (Input.GetKey(KeyCode.D))
		{
			result = 1;
		}

		return result;
	}

	private int GetJumpInputValue()
	{
		int result = 0;
		if (Input.GetKey(KeyCode.Space))
		{
			result = 1;
		}
		return result;
	}


}
