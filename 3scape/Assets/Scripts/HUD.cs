using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    /*private Canvas archerHUD;
    private Canvas mageHUD;
    private Canvas knightHUD;*/

    private RectTransform archerRT;
    private RectTransform mageRT;
    private RectTransform knightRT;

    private int posArcher;
    private int posMage;
    private int posKnight;

    private Player knight;
    private Player mage;
    private Player archer;

    void Start()
    {
        knightRT = GameObject.Find("knightCanvas").GetComponent<RectTransform>();
        mageRT = GameObject.Find("mageCanvas").GetComponent<RectTransform>();
        archerRT = GameObject.Find("archerCanvas").GetComponent<RectTransform>();

        archer = GameObject.Find("archer").GetComponent<Player>();
        knight = GameObject.Find("knight").GetComponent<Player>();
        mage = GameObject.Find("mage").GetComponent<Player>();

        enabled = InputM.ui["HudDD"] == 1;
    }

    void Update()
    {
        posKnight = knight.GetComponent<PlayerMovement>().position;
        posMage = mage.GetComponent<PlayerMovement>().position;
        posArcher = archer.GetComponent<PlayerMovement>().position;

        if (!GlobalVariable.direction) //w prawo
        {
            if (posKnight == 3 && posMage == 2 && posArcher == 1)
            {
                knightRT.transform.localPosition = new Vector3(-850.0f, knightRT.localPosition.y, knightRT.localPosition.z);
                mageRT.transform.localPosition = new Vector3(0.0f, mageRT.localPosition.y, mageRT.localPosition.z);
                archerRT.transform.localPosition = new Vector3(850.0f, archerRT.localPosition.y, archerRT.localPosition.z);
            }
            else if (posArcher == 3 && posKnight == 2 && posMage == 1)
            {
                archerRT.transform.localPosition = new Vector3(-850.0f, archerRT.localPosition.y, archerRT.localPosition.z);
                knightRT.transform.localPosition = new Vector3(0.0f, knightRT.localPosition.y, knightRT.localPosition.z);
                mageRT.transform.localPosition = new Vector3(850.0f, mageRT.localPosition.y, mageRT.localPosition.z);
            }
            else if (posMage == 3 && posArcher == 2 && posKnight == 1)
            {
                mageRT.transform.localPosition = new Vector3(-850.0f, mageRT.localPosition.y, mageRT.localPosition.z);
                archerRT.transform.localPosition = new Vector3(0.0f, archerRT.localPosition.y, archerRT.localPosition.z);
                knightRT.transform.localPosition = new Vector3(850.0f, knightRT.localPosition.y, knightRT.localPosition.z);
            }
            else if (posKnight == 3 && posArcher == 2 && posMage == 1)
            {
                knightRT.transform.localPosition = new Vector3(-850.0f, knightRT.localPosition.y, knightRT.localPosition.z);
                archerRT.transform.localPosition = new Vector3(0.0f, archerRT.localPosition.y, archerRT.localPosition.z);
                mageRT.transform.localPosition = new Vector3(850.0f, mageRT.localPosition.y, mageRT.localPosition.z);
            }
            else if (posArcher == 3 && posMage == 2 && posKnight == 1)
            {
                archerRT.transform.localPosition = new Vector3(-850.0f, archerRT.localPosition.y, archerRT.localPosition.z);
                mageRT.transform.localPosition = new Vector3(0.0f, mageRT.localPosition.y, mageRT.localPosition.z);
                knightRT.transform.localPosition = new Vector3(850.0f, knightRT.localPosition.y, knightRT.localPosition.z);
            }
            else if (posMage == 3 && posKnight == 2 && posArcher == 1)
            {
                mageRT.transform.localPosition = new Vector3(-850.0f, mageRT.localPosition.y, mageRT.localPosition.z);
                knightRT.transform.localPosition = new Vector3(0.0f, knightRT.localPosition.y, knightRT.localPosition.z);
                archerRT.transform.localPosition = new Vector3(850.0f, archerRT.localPosition.y, archerRT.localPosition.z);
            }
        }
        else //w lewo
        {
            if (posKnight == 1 && posMage == 2 && posArcher == 3)
            {
                knightRT.transform.localPosition = new Vector3(-850.0f, knightRT.localPosition.y, knightRT.localPosition.z);
                mageRT.transform.localPosition = new Vector3(0.0f, mageRT.localPosition.y, mageRT.localPosition.z);
                archerRT.transform.localPosition = new Vector3(850.0f, archerRT.localPosition.y, archerRT.localPosition.z);
            }
            else if (posArcher == 1 && posKnight == 2 && posMage == 3)
            {
                archerRT.transform.localPosition = new Vector3(-850.0f, archerRT.localPosition.y, archerRT.localPosition.z);
                knightRT.transform.localPosition = new Vector3(0.0f, knightRT.localPosition.y, knightRT.localPosition.z);
                mageRT.transform.localPosition = new Vector3(850.0f, mageRT.localPosition.y, mageRT.localPosition.z);
            }
            else if (posMage == 1 && posArcher == 2 && posKnight == 3)
            {
                mageRT.transform.localPosition = new Vector3(-850.0f, mageRT.localPosition.y, mageRT.localPosition.z);
                archerRT.transform.localPosition = new Vector3(0.0f, archerRT.localPosition.y, archerRT.localPosition.z);
                knightRT.transform.localPosition = new Vector3(850.0f, knightRT.localPosition.y, knightRT.localPosition.z);
            }
            else if (posKnight == 1 && posArcher == 2 && posMage == 3)
            {
                knightRT.transform.localPosition = new Vector3(-850.0f, knightRT.localPosition.y, knightRT.localPosition.z);
                archerRT.transform.localPosition = new Vector3(0.0f, archerRT.localPosition.y, archerRT.localPosition.z);
                mageRT.transform.localPosition = new Vector3(850.0f, mageRT.localPosition.y, mageRT.localPosition.z);
            }
            else if (posArcher == 1 && posMage == 2 && posKnight == 3)
            {
                archerRT.transform.localPosition = new Vector3(-850.0f, archerRT.localPosition.y, archerRT.localPosition.z);
                mageRT.transform.localPosition = new Vector3(0.0f, mageRT.localPosition.y, mageRT.localPosition.z);
                knightRT.transform.localPosition = new Vector3(850.0f, knightRT.localPosition.y, knightRT.localPosition.z);
            }
            else if (posMage == 1 && posKnight == 2 && posArcher == 3)
            {
                mageRT.transform.localPosition = new Vector3(-850.0f, mageRT.localPosition.y, mageRT.localPosition.z);
                knightRT.transform.localPosition = new Vector3(0.0f, knightRT.localPosition.y, knightRT.localPosition.z);
                archerRT.transform.localPosition = new Vector3(850.0f, archerRT.localPosition.y, archerRT.localPosition.z);
            }
        }
    }
}
