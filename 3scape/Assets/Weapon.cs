using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject arrowPrefab;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
