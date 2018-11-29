using UnityEngine;

public class PlayerAbility : AnimatedAbility
{
    public int requiredPosition;

    protected KeyCode getKeyCode()
    //protected string getKeyCode()
    {
        if (requiredPosition == 1)
            return InputM.keys["Attack"];
        //return "Skill1";
        //return "PositionR";

        else if (requiredPosition == 2)
            return InputM.keys["Skill2"];
        //return "Skill2";
        //return "PositionM";

        else if (requiredPosition == 3)
            return InputM.keys["Skill1"];
        //return "Attack";
        //return "PositionL";

        else if (requiredPosition == 10)
            return InputM.keys["Swap"];
        //return "Swap";

        else
            throw new System.Exception();
            //return "";
    }

    protected bool isButtonPressedProper()
    {
        //return InputM.GetAxisRaw("Ability");
        //return InputM.GetButton(getKeyCode());
        return Input.GetKey(getKeyCode());
    }

    protected bool isButtonDownProper()
    {
        //return InputM.GetAxisRaw("Ability");
        //return InputM.GetButtonDown(getKeyCode());
        return Input.GetKeyDown(getKeyCode());
    }

    protected bool isButtonUpProper()
    {
        //return InputM.GetAxisRaw("Ability");
        //return InputM.GetButtonUp(getKeyCode());
        return Input.GetKeyUp(getKeyCode());
    }

    protected bool isPositionProper()
    {
        return animator.GetInteger("Position") == requiredPosition;
    }
}
