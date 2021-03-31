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


/*	public void OnClickedQuitApplication()
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
	}*/


	


}
