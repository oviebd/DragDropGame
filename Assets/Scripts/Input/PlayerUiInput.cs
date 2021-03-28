using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUiInput : InputBase, Iinput
{
    private float delay = 0.25f;

    private enum ButtonType { HorizontalButton, JumpButton }



    public int GetJumpValue()
    {
        return jumpValue;
    }

    public int GetHorizontalValue()
    {
        return horizontalValue;
    }

    public void leftButtonDown()
    {
        StopAllCoroutines();
        StartCoroutine(OnButtonPressed(-1, ButtonType.HorizontalButton));
    }
    public void rightButtonDown()
    {
        StopAllCoroutines();
        StartCoroutine(OnButtonPressed(1, ButtonType.HorizontalButton));

    }
    public void jumpButtonDown()
    {
        StopAllCoroutines();
        StartCoroutine(OnButtonPressed(1, ButtonType.JumpButton));
    }

    public void moveButtonUp()
    {
        StopAllCoroutines();
        horizontalValue = 0;
    }

    public void jumpButtonUp()
    {
        StopAllCoroutines();
        jumpValue = 0;
    }

    private IEnumerator OnButtonPressed(int value, ButtonType buttonType)
    {
        yield return new WaitForSeconds(delay);
        switch (buttonType)
        {
            case ButtonType.HorizontalButton:
                horizontalValue = value;
                break;
            case ButtonType.JumpButton:
                jumpValue = value;
                break;
        }
    }

}
