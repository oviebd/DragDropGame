using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
	public static bool IsTutorialShowed = false;
	public static bool IsgameobjectIsInThisLayer(LayerMask layerMask,GameObject obj)
	{
		if ((layerMask.value & 1 << obj.layer) != 0)
			return true;
		return false;
	}
}
