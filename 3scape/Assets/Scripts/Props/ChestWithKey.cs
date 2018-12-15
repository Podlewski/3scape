using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestWithKey : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite openSprite;
    private bool isOpen = false;
    private bool isFilled = false;

    public GameObject[] objects;
    public Transform spawnPoint;

    public Image timeBar;

    private void Update()
    {
        if (timeBar.fillAmount == 1 && isFilled == false)
        {
            timeBar.enabled = false;
        }

        if (timeBar.fillAmount == 0 && isFilled == false)
        {
            timeBar.enabled = false;
            isFilled = true;
        }

        if (timeBar.fillAmount < 1 && timeBar.fillAmount > 0 && isFilled == false)
        {
            timeBar.enabled = true;
        }
    }

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
