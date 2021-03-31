using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerHelper : MonoBehaviour
{
	public static SceneManagerHelper instance;

	[SerializeField] private int maxSceneNumber = 2;
	[SerializeField] EnumUtility.Scenes _currentScene = EnumUtility.Scenes.Stage_1;

	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);

		if (instance == null)
			instance = this;
	}

	public void LoadFirstScene()
	{
		_currentScene = EnumUtility.Scenes.Stage_1;
		LoadScene(_currentScene);
	}

	public void ReLoadCurrentScene()
	{
		if(IsSceneExist((int)_currentScene))
			LoadScene(_currentScene);
	}

	public void LoadnextLevel()
	{
		if (IsSceneExist((int) _currentScene + 1))
		{
			_currentScene = (_currentScene) + 1;
			LoadScene(_currentScene);
		}
		
	}

	public void LoadPreviousLevel()
	{
		if (IsSceneExist((int)_currentScene - 1))
		{
			_currentScene = (_currentScene) - 1;
			LoadScene(_currentScene);
		}

	}

	private void LoadScene(EnumUtility.Scenes scene)
	{
	//	Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.ToString());
	}

	private bool IsSceneExist(int sceneNumber)
	{
		if (sceneNumber <= maxSceneNumber && sceneNumber >= 1)
			return true;
		return false;
	}

	public bool IsAllLevelCompleted()
	{
		if (IsSceneExist((int)_currentScene + 1) == true)
			return false;

		return true;
	}
}
