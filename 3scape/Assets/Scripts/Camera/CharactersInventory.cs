using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersInventory : MonoBehaviour {

    public bool[] isThereKey;
    public bool[] isFull;
    public GameObject[] slots;
    public Image[] images;
    private Text keyText;

    private void Start()
    {
        keyText = GameObject.Find("keyText").GetComponent<Text>();

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
            {
                images[i].enabled = true;
                keyText.text = "Good job";
            } 
            else
            {
                images[i].enabled = false;
                keyText.text = "Find key";
            }
                
        }
    }
}
