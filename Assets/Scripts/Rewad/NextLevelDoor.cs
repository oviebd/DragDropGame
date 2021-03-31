using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelDoor : MonoBehaviour
{
	[SerializeField] private LayerMask playerLayer = new LayerMask();
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (Utility.IsgameobjectIsInThisLayer(playerLayer, collision.gameObject))
		{
			collision.gameObject.GetComponent < PlayerManager>().DstroyPlayer();
			GameManager.instance.OnLevelCompleted();
		}
	}
}

