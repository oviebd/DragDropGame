using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHelper : MonoBehaviour
{
	public static StageHelper instance;

	[SerializeField] private GameObject playerPrefab;
	private GameObject _playerInitialPosition;

	private CinemachineVirtualCamera _cinemachineCamera;

	private void Awake()
	{
		if(instance == null)
			instance = this;
	}

	void Start()
	{
	
	}
	public PlayerManager InstantiatePlayer()
	{
		_playerInitialPosition = GameObject.FindGameObjectWithTag(EnumUtility.Tags.PlayerInitiatlPoint.ToString());

		PlayerManager[] players = FindObjectsOfType<PlayerManager>();
		for(int i = 0; i < players.Length; i++)
		{
			Destroy(players[i].gameObject);
		}

		GameObject playerObj = Instantiate(playerPrefab,_playerInitialPosition.transform.position, Quaternion.identity);
		playerObj.transform.SetParent(_playerInitialPosition.transform, true);
		PlayerManager playerManager = playerObj.GetComponent<PlayerManager>();
		SetCinemachineCameraWithPlayer(playerManager);
		return playerManager;

	}

  

	void SetCinemachineCameraWithPlayer(PlayerManager playerManger)
	{
		_cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
		if (_cinemachineCamera != null)
		{
			_cinemachineCamera.LookAt = playerManger.GetPlayerSprite().transform;
			_cinemachineCamera.Follow = playerManger.gameObject.transform;
		}
	}


}
