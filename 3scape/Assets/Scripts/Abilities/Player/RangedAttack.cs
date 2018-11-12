using UnityEngine;

public class RangedAttack : Ability
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    void Update()
    {
		if(isPressedKeyProper() && isPositionProper())
        {
            Shoot();
        }
	}

    void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
