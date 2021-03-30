using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	private PlayerMovement _playerMovement;

	private void Awake()
	{
		_playerMovement = GetComponent<PlayerMovement>();
	}

	public void OnActivateHyperJump()
	{
		_playerMovement.PerformHyperJump();
	}
}
