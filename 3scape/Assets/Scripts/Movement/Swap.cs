using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Swap : PlayerAbility
{
    public int position;
    private Vector3 newPosition;
    private List<Vector3> positions;

    public void Change()
    {
        // [HideInInspector]
        requiredPosition = 10;
    }

    void FixedUpdate()
    {
        if (isAbilityReady() && isButtonDownProper())
        {
            GetComponent<CapsuleCollider2D>().enabled = false;

            newPosition = transform.position;

            if (position == 1)
            {
                newPosition = positions[2];
            }

            else if (position == 2)
            {
                newPosition = positions[0];
            }

            else if (position == 3)
            {
                newPosition = positions[1];
            }

            transform.position = newPosition;
        }

        else
        {
            positions = getCurrentPossitions();

            GetComponent<CapsuleCollider2D>().enabled = true;

            currentCooldown -= Time.deltaTime;
        }
        position = GetComponent<PlayerMovement>().position;
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