using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	StageHelper _stageHelper;
	SceneManagerHelper _sceneManagerHelper;
	UIManager _uiManager;

	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	private void Start()
	{
		_stageHelper = StageHelper.instance;
		_sceneManagerHelper = SceneManagerHelper.instance;
		_uiManager = UIManager.instance;
	}

	public void StartInitialStage()
	{
		_sceneManagerHelper.LoadFirstScene();
	}

	public void StartGame()
	{
		_stageHelper.InstantiatePlayer();
	}

	public void EndGame()
	{
		_uiManager.ShowGameOverMenu();
	}

	public void RestartGame()
	{
		_sceneManagerHelper.ReLoadCurrentScene();
	}

	public void OnLevelCompleted()
	{
		if (_sceneManagerHelper.IsAllLevelCompleted() == false)
		{
			_sceneManagerHelper.LoadnextLevel();
		}
		else
			EndGame();
		
	}
}
