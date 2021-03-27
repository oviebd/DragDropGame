using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    [SerializeField] private Animator _animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update () {
		horizontalMove = InputManager.instance.GetHorizontalValue();
		jump = InputManager.instance.IsJumpButtonPressed();

		playAnimations();
    }

    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * runSpeed * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }


    void playAnimations()
    {
       // _animator.SetFloat("MoveSpeed", Mathf.Abs(horizontalMove));
        if (controller.getIsGrounded())
            _animator.SetFloat("MoveSpeed", Mathf.Abs(horizontalMove));
        else
            _animator.SetFloat("MoveSpeed", Mathf.Abs(0));
           
        _animator.SetBool("jump", jump);
    }

}
