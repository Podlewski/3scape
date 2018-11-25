using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float startHealth;
    public float health;
    public Image healthBar;
    public Image healthBarHUD;

    private bool physicalImmunity = false;
    private bool magicImmunity = false;

    internal bool isBeingHealed = false;

    void Start()
    {
        health = startHealth;
        PlayerMovement.runSpeed = 20f;
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
        healthBar.fillAmount = health / startHealth;
        healthBarHUD.fillAmount = health / startHealth;
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
        if ((healthBar.fillAmount < health / startHealth) || (healthBarHUD.fillAmount < health / startHealth))
        {
            healthBar.fillAmount += 1.0f / waitTime * Time.deltaTime;
            healthBarHUD.fillAmount += 1.0f / waitTime * Time.deltaTime;
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
