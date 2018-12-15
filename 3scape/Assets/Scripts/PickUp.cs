using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour 
{
    private CharactersInventory charactersinventory;

    private void Start()
    {
        charactersinventory = GameObject.Find("Characters").GetComponent<CharactersInventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            for (int i = 0; i < charactersinventory.slots.Length; i++)
            {
                if(charactersinventory.isFull[i]==false)
                {
                    charactersinventory.isFull[i] = true;
                    charactersinventory.isThereKey[i] = true;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}