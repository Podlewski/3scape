using UnityEngine;

public class RangedAttack : PlayerAbility
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    void Update()
    {
        if (InputM.GetAxisRaw("Ability") == 8 && isPositionProper())
		//if (isButtonDownProper() == 8 && isPositionProper())
        //if (isButtonDownProper() && isPositionProper())
        {
            Shoot();
        }
	}

    void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
