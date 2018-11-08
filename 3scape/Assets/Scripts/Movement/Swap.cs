using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swap : Ability
{
    public int position;
    private Vector3 newPosition;

    void Update()
    {
        if (isAbilityReady() && isPressedKeyProper())
        {
            List<float> positions = getCurrentPossitions();
            newPosition = transform.position;

            if (position == 1)
                newPosition.x = positions[2] + 2;

            else if (position == 2)
                newPosition.x = positions[0] + 2;

            else if (position == 3)
                newPosition.x = positions[1] + 2;

            transform.position = newPosition;
        }
    }

    private List<float> getCurrentPossitions()
    {
        List<float> positions = new List<float>();

        positions.Add(GameObject.Find("knight").transform.position.x);
        positions.Add(GameObject.Find("archer").transform.position.x);
        positions.Add(GameObject.Find("mage").transform.position.x);

        positions.Sort();

        return positions;
    }
}