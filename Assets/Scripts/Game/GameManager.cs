using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	StageHelper _stageHelper;
	SceneManagerHelper _sceneManagerHelper;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	private void Start()
	{
		_stageHelper = StageHelper.instance;
		_sceneManagerHelper = SceneManagerHelper.instance;

		StartGame();
	}

	public void StartGame()
	{
	//	_stageHelper.InstantiatePlayer();
	}

	public void EndGame()
	{
		RestartGame();
	}

	public void RestartGame()
	{
		//_sceneManagerHelper.ReLoadCurrentScene();
	}

	public void OnLevelCompleted()
	{
		_sceneManagerHelper.LoadnextLevel();
	}
}
