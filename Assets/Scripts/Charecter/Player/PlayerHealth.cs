using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : DamageableBase, IDamageAble
{
	[SerializeField]
	private int totalHealth = 100;

	private void Start()
	{
		PrepareDamageable();
	}

	public void DoDamage(int damageAmount)
	{
		totalHealth = totalHealth - damageAmount;
	}

	public void PrepareDamageable()
	{
		SetDamageableInterface(this);
	}
}
