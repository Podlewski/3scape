using UnityEngine;

public class RangedAttack : PlayerAbility
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    public AudioClip shot;
    public AudioSource source;
 

    void Update()
    {
        if (isButtonDownProper() && isPositionProper())
        {
            Shoot();
        }
	}

    void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        if(source != null && shot != null)
        {
            source.PlayOneShot(shot);
        }
    }
}
