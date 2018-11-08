using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour{

    public SpriteRenderer spriteRenderer;
    public Sprite openSprite;
    private bool isOpen = false;

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
        }
    }
}
