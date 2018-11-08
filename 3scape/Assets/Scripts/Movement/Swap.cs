using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Swap : Ability
{
    public int position;
    private Vector3 newPosition;
    private List<Vector3> positions;

    void Update()
    {
        if (isAbilityReady() && isPressedKeyProper())
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

            newPosition = transform.position;

            if (position == 1)
            {
                position = 3;
                newPosition = positions[2];
            }

            else if (position == 2)
            {
                position = 1;
                newPosition = positions[0];
            }

            else if (position == 3)
            {
                position = 2;
                newPosition = positions[1];
            }

            transform.position = newPosition;
        }

        else
        {
            positions = getCurrentPossitions();

            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = true;

            currentCooldown -= Time.deltaTime;
        }

        GetComponent<PlayerMovement>().CheckPosition(position);
        animator.SetInteger("Position", position);
    }

    private List<Vector3> getCurrentPossitions()
    {
        List<Vector3> positions = new List<Vector3>();

        positions.Add(GameObject.Find("knight").transform.position);
        positions.Add(GameObject.Find("archer").transform.position);
        positions.Add(GameObject.Find("mage").transform.position);

        positions = positions.OrderBy(v => v.x).ToList<Vector3>();
        positions.Reverse();

        return positions;
    }
}