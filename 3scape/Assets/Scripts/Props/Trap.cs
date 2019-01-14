using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    public GameObject explosion;
    public Text trapsT;

    public LayerMask whatIsEnemy;
    public float explosionRange;
    public int damage;

    private bool triggered = false;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        trapsT = GameObject.Find("Traps_Text").GetComponent<Text>();

        //  trapsT.text = "Traps: " + GlobalVariable.numberOfTraps + "/3";
        trapsT.text = GlobalVariable.numberOfTraps + "/3";
    }

    void Update()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(gameObject.transform.position, explosionRange, whatIsEnemy);

        if (!triggered && enemiesToDamage.Length > 0)
        {
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                Debug.Log(i);
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }

            triggered = true;
            Vector3 vector3 = gameObject.transform.position;
            vector3.y += 0.8f;
            Instantiate(explosion, vector3, transform.rotation = Quaternion.identity);
            Destroy(gameObject);
            GlobalVariable.numberOfTraps--;
            //  trapsT.text = "Traps: " + GlobalVariable.numberOfTraps + "/3";
            trapsT.text = GlobalVariable.numberOfTraps + "/3";
        }

        if (Time.time - startTime > 20)
        {
            triggered = true;
            Vector3 vector3 = gameObject.transform.position;
            vector3.y += 0.8f;
            Instantiate(explosion, vector3, transform.rotation = Quaternion.identity);
            Destroy(gameObject);
            GlobalVariable.numberOfTraps--;
            //trapsT.text = "Traps: " + GlobalVariable.numberOfTraps + "/3";
            trapsT.text = GlobalVariable.numberOfTraps + "/3";
        }
    }
}
