using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerBase : MonoBehaviour, IDamager
{
	[SerializeField]
	protected int damegeAmount;

	public int GetDamageAmount()
	{
		return damegeAmount;
	}
}