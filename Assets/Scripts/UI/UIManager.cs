using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	[SerializeField] private Panel startGamePanel;
	[SerializeField] private Panel endGamePanel;
	[SerializeField] private Panel tutorialPanel;


	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	private void Start()
	{
		//ShowHomeUi();
		if (Utility.IsTutorialShowed == false)
		{
			ShowTutorial();
		}
		else
			ShowHomeUi();
		
	}

	public void ShowHomeUi()
	{
		startGamePanel.Show();
		HideAllExceptOne(startGamePanel);
	}

	public void ShowTutorial()
	{
		//gameRunningPanel.Hide();
		tutorialPanel.Show();
		HideAllExceptOne(tutorialPanel);
	}

	public void ShowGameOverMenu()
	{
		//gameRunningPanel.Hide();
		endGamePanel.Show();
		HideAllExceptOne(endGamePanel);
	}

	private void HideAllExceptOne( Panel activePanel)
	{
		if(activePanel != startGamePanel && startGamePanel.isActiveAndEnabled)
			startGamePanel?.Hide();
		if (activePanel != endGamePanel && endGamePanel.isActiveAndEnabled )
			endGamePanel.Hide();
		if (activePanel != tutorialPanel && tutorialPanel.isActiveAndEnabled)
			tutorialPanel.Hide();
	}
}
