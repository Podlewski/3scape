using UnityEngine;

public class RangedAttack : PlayerAbility
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    public AudioClip shootSound;
    public AudioSource source;

    void Start()
    {
       
        source.clip = shootSound;
    }

    void Update()
    {
		if(isButtonDownProper() && isPositionProper())
        {
            Shoot();
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
