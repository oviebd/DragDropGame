using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : DamageableBase, IDamageAble
{
	[SerializeField] private int totalHealth = 100;

	private PlayerManager _playerManager;


	private void Start()
	{
		_playerManager = this.gameObject.GetComponent<PlayerManager>();
		PrepareDamageable();
	}

	public void DoDamage(int damageAmount)
	{
		totalHealth = totalHealth - damageAmount;
		if (totalHealth <= 0)
		{
			totalHealth = 0;
			_playerManager.OnPlayerDie();
		}
	}

	public void PrepareDamageable()
	{
		SetDamageableInterface(this);
	}
}
