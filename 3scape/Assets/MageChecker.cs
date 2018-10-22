using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageChecker : MonoBehaviour {

    public Animator animator;
	
	// Update is called once per frame
	void Update () {
        GlobalVariable.isMageInMiddle = animator.GetInteger("Position") == 2;
	}
}
