using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersInventory : MonoBehaviour {

    public bool[] isThereKey;
    public bool[] isFull;
    public GameObject[] slots;
    public Image[] images;

    private void Start()
    {
        for(int i=0; i<images.Length; i++)
            images[i].enabled = false;

        for (int i = 0; i < isThereKey.Length; i++)
            isThereKey[i] = false;
    }

    private void Update()
    {
        for(int i = 0; i < isThereKey.Length; i++)
        {
            if(isThereKey[i])
                images[i].enabled = true;

            else
                images[i].enabled = false;
        }
    }
}
