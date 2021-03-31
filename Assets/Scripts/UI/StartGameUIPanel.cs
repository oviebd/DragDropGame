using SaveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameUIPanel : AnimatorPanel
{
	
	public void OnClickStartGameButton()
	{
		_gameManager.StartGame();
		Hide();
	}

	public void OnClickTutorialButton()
	{
		UIManager.instance.ShowTutorial();
		Hide();
	}

}
