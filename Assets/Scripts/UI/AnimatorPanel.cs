using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorPanel : Panel
{
	[SerializeField] protected Animator animator;
	protected GameManager _gameManager; // Will replace with zenject
	protected string anim_identifier_Appearing = "isMenuAppearing";
	

	private Image _backgroundImage;

	private void Start()
	{
		_gameManager = GameManager.instance;
	}

	private Image GetBackgroundImage()
	{
		if(_backgroundImage == null)
			_backgroundImage = this.gameObject.GetComponent<Image>();
		return _backgroundImage;

	}

	public override void Show()
	{
		base.Show();
		//GetBackgroundImage().enabled =true;
		animator.SetBool(anim_identifier_Appearing, true);
	}

	public override void Hide()
	{
		animator.SetBool(anim_identifier_Appearing, false);
		//GetBackgroundImage().enabled = false;
		CancelInvoke();
		Invoke("HidePanel", 1.0f);
	}
	private void HidePanel()
	{
		base.Hide();
	}
}
