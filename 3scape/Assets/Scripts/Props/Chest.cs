using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour{

    public SpriteRenderer spriteRenderer;
    public Sprite openSprite;
    private bool isOpen = false;

    public GameObject[] objects;
    public Transform spawnPoint;

    public void checkIfOpen()
    {
        if (isOpen)
        {
            Debug.Log("opened");
        }

        else
        {
            Debug.Log("opening");
            isOpen = true;
            spriteRenderer.sprite = openSprite;
            GameObject item = Instantiate(objects[Random.Range(0, objects.Length)], spawnPoint.position, spawnPoint.rotation) as GameObject;
        }
    }
}
