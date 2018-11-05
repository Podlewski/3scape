using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public int health;


    void Start () {
		
	}
	
	void Update () {

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DestroyObstacle(int damage)
    {
        health -= damage;
        Debug.Log("damage taken!");
    }
}
