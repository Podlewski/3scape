using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour{

    public SpriteRenderer spriteRenderer;
    public Sprite openSprite;
    private bool isOpen = false;

    public AudioSource source;
    public AudioClip attemptSound;
    public AudioClip openSound;

    public GameObject[] objects;
    public Transform spawnPoint;

    public Image timeBar;

    private void Start()
    {
        source.clip = openSound;
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
            if (source != null)
            {
                source.Play();
            }
            isOpen = true;
            spriteRenderer.sprite = openSprite;
            GameObject item = Instantiate(objects[Random.Range(0, objects.Length)], spawnPoint.position, spawnPoint.rotation) as GameObject;
        }
    }
}
