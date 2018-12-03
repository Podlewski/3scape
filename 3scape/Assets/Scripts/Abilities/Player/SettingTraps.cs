using UnityEngine;

public class SettingTraps : PlayerAbility
{
    public GameObject trap;
    public Transform settingPoint;
	
	void Update () {
        if (isAbilityReady() && isPositionProper() && isButtonPressedProper())
        {
            SetTrap();
            setCooldown();
        }

        if(!isPositionProper() || !isAbilityStillWorking())
        {
            reduceCooldown();
        }
	}

    void SetTrap()
    {
        Instantiate(trap, settingPoint.position, settingPoint.rotation);
    }
}
