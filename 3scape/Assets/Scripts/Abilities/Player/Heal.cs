using UnityEngine;
using UnityEngine.UI;

public class Heal : PlayerAbility
{
    public int healValue;

    private Player knight;
    private Player mage;
    private Player archer;

    public Image FirstSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;
    public GameObject effect;

    public float timeLeft = 1.0f;
    private Text firstSkillTextCd;


    private void Start()
    {
        firstSkillTextCd = GameObject.Find("FirstSkillTextCdMage").GetComponent<Text>();

        knight = GameObject.Find("knight").GetComponent<Player>();
        mage = GameObject.Find("mage").GetComponent<Player>();
        archer = GameObject.Find("archer").GetComponent<Player>();

        defaultColor = FirstSkillCoolDown.color;
        defaultDirection = FirstSkillCoolDown.fillClockwise;

    }

    void Update()
    {
        if (isAbilityReady())
        {
            timeLeft = 1.0f;

            if (isButtonDownProper() && isPositionProper())
            {
                animator.SetBool("IsHealing", true);


                knight.isBeingHealed = true;
                archer.isBeingHealed = true;
                mage.isBeingHealed = true;

                mage.Heal(healValue);
                archer.Heal(healValue);
                knight.Heal(healValue);


                setCooldown();

                FirstSkillCoolDown.fillAmount = 1;

                effect.SetActive(true);
            }
        }
        else if (!isAbilityStillWorking() || !isPositionProper())
        {


            reduceCooldown();

            //FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && animator.GetBool("IsHealing"))
        {

            animator.SetBool("IsHealing", false);
            timeLeft = 1.0f;
        }

        if (knight.isBeingHealed) knight.HealAnimation();
        if (mage.isBeingHealed) mage.HealAnimation();
        if (archer.isBeingHealed) archer.HealAnimation();

        if (isAbilityStillWorking())
        {
            FirstSkillCoolDown.color = new Color(0.5f, 0.2f, 0.7f, 0.8f);
            FirstSkillCoolDown.fillClockwise = !defaultDirection;
            FirstSkillCoolDown.fillAmount = remaindingDuration / duration;
            
        }
        else
        {
            FirstSkillCoolDown.color = defaultColor;
            FirstSkillCoolDown.fillClockwise = defaultDirection;
            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
            int val = (int)currentCooldown;
            firstSkillTextCd.text = val.ToString();
            if(currentCooldown < 0.1)
            {
                firstSkillTextCd.text = "";
            }
        }

        if (!isPositionProper())
        {
            FirstSkillCoolDown.color = defaultColor;
            FirstSkillCoolDown.fillAmount = 1;
        }
        else if (!isAbilityStillWorking())
            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }
}
