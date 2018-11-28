using UnityEngine;

public class RangedAttack : PlayerAbility
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    void Update()
    {
		if(isButtonDownProper() == 8 && isPositionProper())
        {
            Shoot();
        }
	}

    void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
