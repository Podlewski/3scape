using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float startHealth;
    public float health;
    public Image healthBar;
    public Image healthBarBG;
    public Image healthBarHUD;
    public Image healthBarHUDBG;
    private Image healthBarPicked;

    private bool physicalImmunity = false;
    private bool magicImmunity = false;

    internal bool isBeingHealed = false;

    void Start()
    {
        health = startHealth;
        PlayerMovement.runSpeed = 20f;

        if (InputM.ui["HealthbarDD"] == 0)
        {
            healthBarPicked = healthBar;
            healthBarHUD.fillAmount = 0;
            healthBarHUDBG.fillAmount = 0;
        }
        else if (InputM.ui["HealthbarDD"] == 1)
        {
            healthBarPicked = healthBarHUD;
            healthBar.fillAmount = 0;
            healthBarBG.fillAmount = 0;
        }
        else
        {
            throw new System.Exception();
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakePhysicalDamage(int damage)
    {
        if (!physicalImmunity)
            TakeDamage(damage);
    }

    public void TakeMagicDamage(int damage)
    {
        if (!magicImmunity)
            TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //healthBar.fillAmount = health / startHealth;
        //healthBarHUD.fillAmount = health / startHealth;
        healthBarPicked.fillAmount = health / startHealth;
        Debug.Log(this.gameObject.name + ": " + damage + " damage was taken!");
    }

    public void SetPhysicalImmunity()
    {
        physicalImmunity = true;
    }

    public void SetMagicImmunity()
    {
        magicImmunity = true;
    }

    public void DisbalePhysicalImmunity()
    {
        physicalImmunity = false;
    }

    public void DisableMagicImmunity()
    {
        magicImmunity = false;
    }

    public void Heal(float healValue)
    {
        health += healValue;
        if (health > startHealth)
        {
            health = startHealth;
        }
    }

    public void HealAnimation()
    {
        float waitTime = 1.0f;
        if (healthBarPicked.fillAmount < health / startHealth)
        //if ((healthBar.fillAmount < health / startHealth) || (healthBarHUD.fillAmount < health / startHealth))
        {
            //healthBar.fillAmount += 1.0f / waitTime * Time.deltaTime;
            //healthBarHUD.fillAmount += 1.0f / waitTime * Time.deltaTime;
            healthBarPicked.fillAmount += 1.0f / waitTime * Time.deltaTime;
        }
        else
        {
            isBeingHealed = false;
        }
        /*Debug.Log("To: " + 1.0f / waitTime * Time.deltaTime + "\t" +
            "Health: " + health + ", health / startHealth: " + health / startHealth + "\t" +
        "FillAmount: " + healthBar.fillAmount);*/
    }
}
