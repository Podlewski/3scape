using UnityEngine;
using UnityEngine.UI;

public class SettingTraps : PlayerAbility
{
    public GameObject trap;
    public Transform settingPoint;

    public Image FirstSkillCoolDown;
    private Color defaultColor;
    private bool defaultDirection;

    public byte maxNumberOfTraps = 3;

    private Text firstSkillTextCdArcher;

    private Image skillImage;
    public Sprite skillSprite;
    public Sprite skillSpriteUsed;

    void Start()
    {
        firstSkillTextCdArcher = GameObject.Find("FirstSkillTextCdArcher").GetComponent<Text>();
        skillImage = GameObject.Find("FirstSkillArcher").GetComponent<Image>();
        defaultColor = FirstSkillCoolDown.color;
        defaultDirection = FirstSkillCoolDown.fillClockwise;
        GlobalVariable.maximumNumberOfTraps = maxNumberOfTraps;
    }

    void Update ()
    {
        if (isAbilityReady() && isPositionProper() && isButtonPressedProper() && (GlobalVariable.maximumNumberOfTraps - GlobalVariable.numberOfTraps > 0))
        {
            skillImage.sprite = skillSprite;
            SetTrap();
            setCooldown();

            FirstSkillCoolDown.fillAmount = 1;
        }

        if(!isPositionProper() || !isAbilityStillWorking())
        {
            reduceCooldown();
        }

        if (isAbilityStillWorking())
        {
            FirstSkillCoolDown.color = new Color(0.5f, 0.2f, 0.7f, 0.8f);
            FirstSkillCoolDown.fillClockwise = !defaultDirection;
            FirstSkillCoolDown.fillAmount = remaindingDuration / duration;
        }
        else
        {
            skillImage.sprite = skillSprite;
            FirstSkillCoolDown.color = defaultColor;
            FirstSkillCoolDown.fillClockwise = defaultDirection;
            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;

            int val = (int)currentCooldown;
            firstSkillTextCdArcher.text = val.ToString();
            if (currentCooldown < 0.1)
            {
                firstSkillTextCdArcher.text = "";
            }
        }

        if (!isPositionProper())
        {
            //FirstSkillCoolDown.color = defaultColor;
            //FirstSkillCoolDown.fillAmount = 1;
            skillImage.sprite = skillSpriteUsed;
        }
        else if (!isAbilityStillWorking())
            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }

    void SetTrap()
    {
        Vector3 v3 = settingPoint.position;

        if(GlobalVariable.numberOfTraps < maxNumberOfTraps)
        {
            Instantiate(trap, settingPoint.position, settingPoint.rotation);
            GlobalVariable.numberOfTraps++;
        }

    }
}
