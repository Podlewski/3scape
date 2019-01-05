using UnityEngine;

public class PlayerAbility : AnimatedAbility
{
    public int requiredPosition;

    private KeyCode[] backup = new KeyCode[2] { InputM.keys["Attack"], InputM.keys["Skill1"] };

    void Update()
    {
        UpdateKeys();
    }

    void LateUpdate()
    {
        if (!GlobalVariable.direction)
        {
            //UpdateKeys();

            InputM.keys["Attack"] = backup[0];
            InputM.keys["Skill1"] = backup[1];

            //InputM.keys["Attack"] = KeyCode.L;
            //InputM.keys["Skill1"] = KeyCode.J;
        }
        /*else
        {
            //UpdateKeys();

            InputM.keys["Attack"] = backup[1];
            InputM.keys["Skill1"] = backup[0];

            //InputM.keys["Attack"] = KeyCode.J;
            //InputM.keys["Skill1"] = KeyCode.L;
        }*/
    }

    void UpdateKeys()
    {
        if (GlobalVariable.keysChanged)
        {
            if (!GlobalVariable.direction)
            {
                backup = new KeyCode[2] { InputM.keys["Attack"], InputM.keys["Skill1"] };
                //backup[0] = InputM.keys["Attack"];
                //backup[1] = InputM.keys["Skill1"];
            }
            else
            {
                backup = new KeyCode[2] { InputM.keys["Skill1"], InputM.keys["Attack"] };
                //backup[0] = InputM.keys["Skill1"];
                //backup[1] = InputM.keys["Attack"];
            }
            GlobalVariable.keysChanged = false;
            Debug.Log("+++ UpdateKeys +++");
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
