using UnityEngine;

public class PlayerAbility : AnimatedAbility
{
    public int requiredPosition;

    private KeyCode[] backup = new KeyCode[2] { InputM.keys["Attack"], InputM.keys["Skill1"] };

    protected KeyCode getKeyCode()
    {
        switch (requiredPosition)
        {
            case 1:
                return InputM.keys["Attack"];
            case 2:
                return InputM.keys["Skill2"];
            case 3:
                return InputM.keys["Skill1"];
            case 10:
                return InputM.keys["Swap"];
            default:
                throw new System.Exception();
        }
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
