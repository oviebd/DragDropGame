using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	[SerializeField] private Animator _animator;
	[SerializeField] private float hyperJumpForce = 800.0f;
	[SerializeField] private float runSpeed = 80f;

	private CharacterController2D _controller;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

	private float _originalJumpForce;
	private bool _isHyperJumpActivated = false;

	private PlayerManager _playerManager;

	private void Start()
	{
		_controller = GetComponent<CharacterController2D>();
		_originalJumpForce = _controller.GetJumopforce();
		_playerManager = GetComponent<PlayerManager>();
	}

	void Update () {

		horizontalMove = InputManager.instance.GetHorizontalValue();

		if (_isHyperJumpActivated == false)
			jump = InputManager.instance.IsJumpButtonPressed();

		playAnimations();
    }

    void FixedUpdate ()
    {
		if (jump && _controller.getIsGrounded())
		{
			_playerManager.PlayJumpAudio();
		}

        _controller.Move(horizontalMove * runSpeed * Time.fixedDeltaTime, crouch, jump);

		if (_isHyperJumpActivated)
		{
			_isHyperJumpActivated = false;
			_controller.SetJumpForce(_originalJumpForce);
		}
		jump = false;

    }


    void playAnimations()
    {
       // _animator.SetFloat("MoveSpeed", Mathf.Abs(horizontalMove));
        if (_controller.getIsGrounded())
            _animator.SetFloat("MoveSpeed", Mathf.Abs(horizontalMove));
        else
            _animator.SetFloat("MoveSpeed", Mathf.Abs(0));
           
        _animator.SetBool("jump", jump);
    }

	public void PerformHyperJump()
	{
	//	Debug.Log("Perform Hyper Jump " );
		_isHyperJumpActivated = true;
		_controller.SetJumpForce(hyperJumpForce);
		jump = true;
	}

}
