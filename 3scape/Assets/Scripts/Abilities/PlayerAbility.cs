using UnityEngine;

public class PlayerAbility : AnimatedAbility
{
    public int requiredPosition;

    private KeyCode[] backup = new KeyCode[2] { InputM.keys["Attack"], InputM.keys["Skill1"] };

    protected KeyCode getKeyCode()
    {
        if (requiredPosition == 1)
            return InputM.keys["Attack"];

        else if (requiredPosition == 2)
            return InputM.keys["Skill2"];

        else if (requiredPosition == 3)
            return InputM.keys["Skill1"];

        else if (requiredPosition == 10)
            return InputM.keys["Swap"];

        else
            throw new System.Exception();
    }

    protected bool isButtonPressedProper()
    {
        return Input.GetKey(getKeyCode());
    }

    protected bool isButtonDownProper()
    {
        return Input.GetKeyDown(getKeyCode());
    }

    protected bool isButtonUpProper()
    {
        return Input.GetKeyUp(getKeyCode());
    }

    protected bool isPositionProper()
    {
        return animator.GetInteger("Position") == requiredPosition;
    }
}
