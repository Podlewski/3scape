using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    public Sprite redFlag;
    public Sprite greenFlag;
    private SpriteRenderer checpointSpriteRenderer;
    public bool checkpointReached = false;

    // Use this for initialization
    void Start()
    {
        checpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            checpointSpriteRenderer.sprite = greenFlag;
            checkpointReached = true;
        }
    }
}
