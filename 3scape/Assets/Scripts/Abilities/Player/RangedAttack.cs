using UnityEngine;

public class RangedAttack : PlayerAbility
{
    public Transform firePoint;
    public GameObject arrowPrefab;


    public AudioSource source;

 

    void Update()
    {
        if (isAbilityReady())
        {

            animator.SetBool("IsAttacking", false);

            if (isButtonDownProper() && isPositionProper())
            {
                animator.SetBool("IsAttacking", true);

                Shoot();
                setCooldown();
            }
        }
        else
        {
            reduceCooldown();
        }

            
	}

    void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        if(source != null)
        {
            source.Play();
        }
    }
}
