using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    public Transform playerAveragePosition;
    public Transform knight;
    public Transform mage;
    public Transform archer;

    // Use this for initialization
    void Start()
    {
        playerAveragePosition.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = Vector3.zero;
        vec = (knight.position + mage.position + archer.position) / 3;
        playerAveragePosition.position = vec;
    }
}
