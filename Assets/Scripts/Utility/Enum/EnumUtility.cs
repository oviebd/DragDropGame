using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumUtility 
{
   public  enum DraggedItemType
	{
		NONE = 0,
		LEFT = 1,
		RIGHT = 2,
		JUMP = 3,
		SPRING =4
	}

	public enum Scenes
	{
		NONE = 0,
		Stage_1 = 1,
		Stage_2 = 2
	}

	public enum Tags
	{
		NONE = 0,
		PlayerInitiatlPoint = 1
	}
}
