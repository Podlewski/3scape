using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PositionChecker : MonoBehaviour {

    public GameObject knight;
    public GameObject archer;
    public GameObject mage;

    private List<GameObject> objects;
	// Use this for initialization
	void Start () {
		objects =  new List<GameObject> { knight, archer, mage };
    }
	
	// Update is called once per frame
	void Update () {
        objects = objects.OrderByDescending(o => o.transform.position.x).ToList();
        for (int i = 1; i <= objects.Count; i++)
        {
            objects[i - 1].GetComponent<PlayerMovement>().position = i;
            objects[i - 1].GetComponent<Animator>().SetInteger("Position", i);
        }
	}
}
