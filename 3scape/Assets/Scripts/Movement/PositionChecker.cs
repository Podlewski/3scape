using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PositionChecker : MonoBehaviour
{
    public GameObject knight;
    public GameObject archer;
    public GameObject mage;

    private List<GameObject> objects;

    private float timer1;
    private float timer2;
    // Use this for initialization
    void Start()
    {
        objects = new List<GameObject> { knight, archer, mage };
        timer1 = 0;
        timer2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //  BringBackIfTooFarAway();
    }

    void FixedUpdate()
    {
        if (!GlobalVariable.direction) objects = objects.OrderByDescending(o => o.transform.position.x).ToList();
        else objects = objects.OrderBy(o => o.transform.position.x).ToList();

        for (var i = 1; i <= objects.Count; i++)
        {
            objects[i - 1].GetComponent<PlayerMovement>().position = i;
            objects[i - 1].GetComponent<Animator>().SetInteger("Position", i);
        }
        //Debug.Log("Mage: " + mage.GetComponent<PlayerMovement>().position + ", Archer: " + archer.GetComponent<PlayerMovement>().position + ", knight: " + knight.GetComponent<PlayerMovement>().position);
        FixPositions();
    }

    private void FixPositions()
    {
        var tmpobjects = objects.OrderByDescending(o => o.transform.position.x).ToList();

        int facing = 1;
        if (tmpobjects[1].GetComponent<CharacterController2D>().m_FacingRight)
        {
            facing = -1;
        }
        if (Mathf.Abs(tmpobjects[0].transform.Find("GroundCheck").position.x - tmpobjects[1].transform.Find("GroundCheck").position.x) < 0.8f)
        {
            tmpobjects[0].transform.Translate(-1 * facing * 0.02f, 0, 0);
        }
        if (Mathf.Abs(tmpobjects[2].transform.Find("GroundCheck").position.x - tmpobjects[1].transform.Find("GroundCheck").position.x) < 0.8f )
        {
            tmpobjects[2].transform.Translate(facing * 0.02f, 0, 0);
        }
        if (Mathf.Abs(tmpobjects[0].transform.Find("GroundCheck").position.x - tmpobjects[1].transform.Find("GroundCheck").position.x) > 1f
            && Mathf.Abs(tmpobjects[0].transform.Find("GroundCheck").position.y - tmpobjects[1].transform.Find("GroundCheck").position.y) < 1f)
        {
            tmpobjects[0].transform.Translate(1 * facing * 0.02f, 0, 0);
            tmpobjects[0].GetComponent<Animator>().SetFloat("Walk", 20f);
        }
        else
        {
            tmpobjects[0].GetComponent<Animator>().SetFloat("Walk", 0);
        }
        if ( Mathf.Abs(tmpobjects[2].transform.Find("GroundCheck").position.x - tmpobjects[1].transform.Find("GroundCheck").position.x) > 1f
             && Mathf.Abs(tmpobjects[2].transform.Find("GroundCheck").position.y - tmpobjects[1].transform.Find("GroundCheck").position.y) < 1f)
        {
            tmpobjects[2].transform.Translate(-1 * facing * 0.02f, 0, 0);
            tmpobjects[2].GetComponent<Animator>().SetFloat("Walk", 20f);
        }
        else
        {
            tmpobjects[2].GetComponent<Animator>().SetFloat("Walk", 0);
        }
    }
}
