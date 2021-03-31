using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : AnimatorPanel
{

	public override void Show()
	{
		base.Show();
		Utility.IsTutorialShowed = true;
	}

	public void OnClickCloseButton()
	{
		Hide();
		UIManager.instance.ShowHomeUi();
	}
}
