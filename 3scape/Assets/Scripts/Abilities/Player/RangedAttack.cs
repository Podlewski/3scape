using UnityEngine;

public class RangedAttack : PlayerAbility
{
    public Transform firePoint;
    public GameObject arrowPrefab;

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
    }
}
