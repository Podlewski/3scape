using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkArcherAttack : AnimatedAbility {

    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    public Transform firePoint;
    public GameObject arrowPrefab;

    private Color defaultColor;
    private bool defaultDirection;

    public AudioClip shot;
    public AudioSource source;

    void Update()
    {
        if ((Physics2D.Raycast(transform.position, Vector2.left, attackRange, whatIsEnemy /*player layerMask*/)
          || Physics2D.Raycast(transform.position, Vector2.right, attackRange, whatIsEnemy/*player layerMask*/)))
        {
            animator.SetBool("IsAttacking", true);
            if (isAbilityReady())
            {
                setCooldown();
                var enemiesToDamage = Physics2D.OverlapCircleAll(gameObject.transform.Find("DarkArcherFirePoint").position, attackRange, 1 << 8);
                foreach (var enemy in enemiesToDamage)
                {
                    //enemy.GetComponent<Player>().TakePhysicalDamage(damage);
                    Shoot();
                }
            }
            else
            {
                currentCooldown -= Time.deltaTime;
            }

        }

        else
        {
            currentCooldown -= Time.deltaTime;
            animator.SetBool("IsAttacking", false);
        }

    }

    void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        if (source != null && shot != null)
        {
            source.PlayOneShot(shot);
        }
    }
}
