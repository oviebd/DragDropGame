using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUiInput : InputBase, Iinput
{
	public int GetJumpValue()
	{
		return jumpValue;
	}

	public int GetHorizontalValue()
	{
		return horizontalValue;
	}

	public void leftButtonDown()
	{
		horizontalValue = -1;
	}
	public void rightButtonDown()
	{
		horizontalValue = 1;
	}
	public void jumpButtonDown()
	{
		jumpValue = 1;
	}

	public void moveButtonUp()
	{
		horizontalValue = 0;
	}

	public void jumpButtonUp()
	{
		jumpValue = 0;
	}


}
