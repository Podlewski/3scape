using UnityEngine;

public class PlayerAbility : AnimatedAbility
{
    public int requiredPosition;

    protected string getKeyCode()
    {
        if (requiredPosition == 1)
            return "PositionR";

        else if (requiredPosition == 2)
            return "PositionM";

        else if (requiredPosition == 3)
            return "PositionL";

        else if (requiredPosition == 10)
            return "Swap";

        else
            return "";
    }

    protected bool isButtonPressedProper()
    {
        return Input.GetButton(getKeyCode());
    }

    protected bool isButtonDownProper()
    {
        return Input.GetButtonDown(getKeyCode());
    }

    protected bool isButtonUpProper()
    {
        return Input.GetButtonUp(getKeyCode());
    }

    protected bool isPositionProper()
    {
        return animator.GetInteger("Position") == requiredPosition;
    }

}
