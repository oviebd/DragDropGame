using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : AnimatorPanel
{
	[SerializeField] private Text messageText;
	public override void Show()
	{
		base.Show();
		if (SceneManagerHelper.instance.IsAllLevelCompleted())
		{
			ShowLevelCompleteMessage();
		}
		else
		{
			ShowGameOverMessage();
		}
	}

	public void ShowLevelCompleteMessage()
	{
		messageText.text = "Congratulations ! \n You have CCompleted all Levels";
	}

	public void ShowGameOverMessage()
	{
		messageText.text = "Game Over ! \nTry Again";
	}

	public void OnRestartGameButtonClicked()
	{
		if (SceneManagerHelper.instance.IsAllLevelCompleted() == false)
			_gameManager.RestartGame();
		else
			_gameManager.StartInitialStage();

	}

	public void OnQuitGameButtonClicked()
	{
		DialogClass actionDialogClass = new DialogBuilder().
						   Title("Quit Game !").
						   Message(" Want to Quit Game ?").
						   PositiveButtonText("OK").
						   NegativeButtonText("Cancel").

						   PositiveButtonAction((IDialog dialog) =>
						   {
							   Debug.Log("Action Dialog posituve Button clicked ");
							   dialog.HideDialog();
							   Application.Quit();
						   }).

						   NegativeButtonAction((IDialog dialog) =>
						   {
							   Debug.Log("Action Dialog Negative Button clicked  ");
							   dialog.HideDialog();
						   }).

						   build();

		DialogManager.instance.SpawnDialogBasedOnDialogType(DialogTypeEnum.DialogType.ActionDialog, actionDialogClass);
	}
}
