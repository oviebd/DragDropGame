using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableBase : MonoBehaviour
{
	[SerializeField]
	private LayerMask damagedBy = new LayerMask();
	private IDamageAble _iDamageable;

	public void SetDamageableInterface(IDamageAble damageable)
	{
		this._iDamageable = damageable;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (Utility.IsgameobjectIsInThisLayer(damagedBy, collision.gameObject))
		{

			IDamager damager = collision.gameObject.GetComponent<IDamager>();
			if (damager != null && _iDamageable != null)
			{
				_iDamageable.DoDamage(damager.GetDamageAmount());
			}

		}
	}
}

