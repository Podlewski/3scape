using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Swap : PlayerAbility
{
    public int position;
    private Vector3 newPosition;
    private List<Vector3> positions;

    public void Change()
    {
        // [HideInInspector]
        requiredPosition = 10;
    }

    public bool isIdle()
    {
        return GetComponent<SpriteRenderer>().sprite.name.Contains("idle");
    }

    public bool isRun()
    {
        return GetComponent<SpriteRenderer>().sprite.name.Contains("run");
    }

    public bool isNotActiveSkills()
    {
        float knightPhysicalShieldStatus = GameObject.Find("knight").GetComponent<PhysicalShield>().FirstSkillCoolDown.fillAmount;
        if (!knightPhysicalShieldStatus.Equals(1) && !knightPhysicalShieldStatus.Equals(0)) return false;

        float knightFasterWalkingStatus = GameObject.Find("knight").GetComponent<KnightFasterWalking>().SecondSkillCoolDown.fillAmount;
        if (!knightFasterWalkingStatus.Equals(1) && !knightFasterWalkingStatus.Equals(0)) return false;

        float mageHealStatus = GameObject.Find("mage").GetComponent<Heal>().FirstSkillCoolDown.fillAmount;
        if (!mageHealStatus.Equals(1) && !mageHealStatus.Equals(0)) return false;

        float mageMagicShieldStatus = GameObject.Find("mage").GetComponent<MagicShield>().SecondSkillCoolDown.fillAmount;
        if (!mageMagicShieldStatus.Equals(1) && !mageMagicShieldStatus.Equals(0)) return false;

        float archerTrapStatus = GameObject.Find("archer").GetComponent<SettingTraps>().FirstSkillCoolDown.fillAmount;
        if (!archerTrapStatus.Equals(1) && !archerTrapStatus.Equals(0)) return false;

        return true;
    }

    void FixedUpdate()
    {
        if (isAbilityReady() && isButtonDownProper() && isNotActiveSkills() && (isIdle() || isRun()))
        {
            GetComponent<CapsuleCollider2D>().enabled = false;

            newPosition = transform.position;

            if (position == 1)
            {
                newPosition = positions[2];
            }

            else if (position == 2)
            {
                newPosition = positions[0];
            }

            else if (position == 3)
            {
                newPosition = positions[1];
            }

            transform.position = newPosition;
        }

        else
        {
            positions = getCurrentPossitions();

            GetComponent<CapsuleCollider2D>().enabled = true;

            currentCooldown -= Time.deltaTime;
        }
        position = GetComponent<PlayerMovement>().position;
    }

    private List<Vector3> getCurrentPossitions()
    {
        List<Vector3> positions = new List<Vector3>();

        positions.Add(GameObject.Find("knight").transform.position);
        positions.Add(GameObject.Find("archer").transform.position);
        positions.Add(GameObject.Find("mage").transform.position);

        positions = positions.OrderBy(v => v.x).ToList<Vector3>();
        positions.Reverse();

        return positions;
    }
}