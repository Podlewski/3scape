using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockHPBarRotation : MonoBehaviour
{
	void Update ()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.x);
    }
}
