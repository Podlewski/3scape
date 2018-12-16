using UnityEngine;

public class PlayerAbility : AnimatedAbility
{
    public int requiredPosition;

    void Update()
    {
        if (!GlobalVariable.direction)
        {
            InputM.SetKey("Attack", KeyCode.L);
            InputM.SetKey("Skill1", KeyCode.J);
        }
        else
        {
            InputM.SetKey("Attack", KeyCode.J);
            InputM.SetKey("Skill1", KeyCode.L);
        }
    }

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
