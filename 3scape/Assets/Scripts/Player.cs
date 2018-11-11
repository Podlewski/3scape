using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float startHealth;
    public float health;
    public Image healthBar;

    private bool physicalImmunity = false;
    private bool magicImmunity = false;

    void Start()
    {
        health = startHealth;
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
        Debug.Log(this.gameObject.name + ": " + damage + " damage was taken!");
    }

    public void ChangePhysicalImmunity()
    {
        physicalImmunity = !physicalImmunity;
    }

    public void ChangeMagicImmunity()
    {
        magicImmunity = !magicImmunity;
    }

    public void Heal(float percentages)
    {
        //float previousHealth = health;
        health += startHealth * percentages / 100;
        if (health > startHealth)
        {
            health = startHealth;
        }
        healthBar.fillAmount = health / startHealth;
    }
}
