using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour 
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots; i++)
            {
                if(inventory.isFull[i]==false)
                {
                    // item can be added to inventory
                    inventory.isFull[i] = true;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
