using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject arrowPrefab;
    public KeyCode button;
    public Animator animator;
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(button) && animator.GetInteger("Position") == 1)
        {
            Shoot();
        }
	}

    void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
