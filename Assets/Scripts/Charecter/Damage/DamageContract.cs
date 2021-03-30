using UnityEngine;

public interface IDamager
{
	int GetDamageAmount();
}

public interface IDamageAble
{
	void DoDamage(int damageAmount);
	void PrepareDamageable();
}


