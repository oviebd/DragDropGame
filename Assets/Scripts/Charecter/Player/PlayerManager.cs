using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
	[SerializeField] private GameObject playerSprite;

	private PlayerMovement _playerMovement;
	private GameManager _gameManager;

	private void Awake()
	{
		_playerMovement = GetComponent<PlayerMovement>();
	}

	private void Start()
	{
		_gameManager = GameManager.instance;
	}

	public void OnActivateHyperJump()
	{
		_playerMovement.PerformHyperJump();
	}

	public void OnPlayerDie()
	{
		_gameManager.EndGame();
		Invoke("DstroyPlayer", 0.5f);
	}

	public void DstroyPlayer()
	{
		Destroy(this.gameObject);
	}

	public GameObject GetPlayerSprite()
	{
		return playerSprite;
	}


	


}
