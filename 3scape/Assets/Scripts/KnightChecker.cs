using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightChecker : MonoBehaviour {

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        GlobalVariable.isKnightInMiddle = animator.GetInteger("Position") == 2;
    }
}
