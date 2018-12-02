using UnityEngine;
using UnityEngine.UI;

public class Heal : PlayerAbility
{
    public int healValue;

    private Player knight;
    private Player mage;
    private Player archer;

    /*jak zmiana na zielony sie nie przyjmie to zakomentowac*/
    //////////////////////////////////////////////////
    private SpriteRenderer srKnight;
    private SpriteRenderer srMage;
    private SpriteRenderer srArcher;

    private Color32 playerColor = new Color32(255, 255, 255, 225);
    public Color32 magicColor = new Color32(3, 0, 255, 255);
    //////////////////////////////////////////////////


    public Image FirstSkillCoolDown;

    public float timeLeft = 1.0f;

    private void Start()
    {
        knight = GameObject.Find("knight").GetComponent<Player>();
        mage = GameObject.Find("mage").GetComponent<Player>();
        archer = GameObject.Find("archer").GetComponent<Player>();

        /*jak zmiana na zielony sie nie przyjmie to zakomentowac*/
        //////////////////////////////////////////////////
        srKnight = GameObject.Find("knight").GetComponent<SpriteRenderer>();
        srMage = GameObject.Find("mage").GetComponent<SpriteRenderer>();
        srArcher = GameObject.Find("archer").GetComponent<SpriteRenderer>();
        //////////////////////////////////////////////////
    }

    void Update()
    {
        if (isAbilityReady())
        {
            timeLeft = 1.0f;

            if (isButtonDownProper() && isPositionProper())
            {
                animator.SetBool("IsHealing", true);

                /*jak zmiana na zielony sie nie przyjmie to zakomentowac*/
                //////////////////////////////////////////////////
                srKnight.color = magicColor;
                srMage.color = magicColor;
                srArcher.color = magicColor;
                //////////////////////////////////////////////////


                knight.isBeingHealed = true;
                archer.isBeingHealed = true;
                mage.isBeingHealed = true;

                mage.Heal(healValue);
                archer.Heal(healValue);
                knight.Heal(healValue);
                

                setCooldown();

                FirstSkillCoolDown.fillAmount = 1;
            }
        }
        else if (!isAbilityStillWorking() || !isPositionProper())
        {

            
            reduceCooldown();

            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && animator.GetBool("IsHealing"))
        {
            /*jak zmiana na zielony sie nie przyjmie to zakomentowac*/
            //////////////////////////////////////////////////
            srKnight.color = playerColor;
            srMage.color = playerColor;
            srArcher.color = playerColor;
            //////////////////////////////////////////////////
            
            animator.SetBool("IsHealing", false);
            timeLeft = 1.0f;
        }

        if (knight.isBeingHealed) knight.HealAnimation();
        if (mage.isBeingHealed) mage.HealAnimation();
        if (archer.isBeingHealed) archer.HealAnimation();

        if (!isPositionProper())
            FirstSkillCoolDown.fillAmount = 1;
        else
            FirstSkillCoolDown.fillAmount = currentCooldown / cooldown;
    }
}
