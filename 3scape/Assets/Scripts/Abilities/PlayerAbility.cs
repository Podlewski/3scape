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

    protected float isButtonPressedProper()
    {
        return InputM.GetAxisRaw("Ability");
        //return InputM.GetButton(getKeyCode());
    }

    protected float isButtonDownProper()
    {
        return InputM.GetAxisRaw("Ability");
        //return InputM.GetButtonDown(getKeyCode());
    }

    protected float isButtonUpProper()
    {
        return InputM.GetAxisRaw("Ability");
        //return InputM.GetButtonUp(getKeyCode());
    }

    protected bool isPositionProper()
    {
        return animator.GetInteger("Position") == requiredPosition;
    }

}
