using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float startHealth;
    private float health;

    public float speed;
    public Image optionalHealthBar;
    public bool shouldExplode = false;
    public GameObject PossibleExplosion;

    bool m_FacingLeft = true;

    public AudioClip barrelExplosion;
    public AudioClip zombieDeath;
    public AudioSource source;

    public float walkDetectionDistance = 0.3f;

    public GameObject deathBlood;
    public GameObject hurtBlood;

    void Start()
    {
        health = startHealth;
     //   source.clip = barrelSound;
    }

    void Update()
    {
        if (health <= 0)
        {

            if (gameObject.name.Equals("Barrel"))
            {
                AudioSource.PlayClipAtPoint(barrelExplosion, this.gameObject.transform.position);
            }

            if (gameObject.name.Equals("zombie"))
            {
                AudioSource.PlayClipAtPoint(zombieDeath, this.gameObject.transform.position);
                Instantiate(deathBlood, transform.position, Quaternion.identity);
            }

            if (shouldExplode && PossibleExplosion != null)
            {
               // AudioSource.PlayClipAtPoint(enemySound, this.gameObject.transform.position);

                Vector3 vector3 = gameObject.transform.position;
                vector3.y += 0.8f;
                Instantiate(PossibleExplosion, vector3, transform.rotation = Quaternion.identity);
            }
            

            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (GetComponent<Animator>() != null)
        {
            if (!(Physics2D.Raycast(transform.position + new Vector3(0,0.5f,0) , Vector2.left, walkDetectionDistance, 1 << 8 /*player layerMask*/)
                         || (Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), Vector2.right, walkDetectionDistance, 1 << 8 /*player layerMask*/))))
            {
              //  Debug.Log("1");
                GetComponent<Animator>().SetFloat("Speed", speed);

                if (Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), -1 * transform.right, 7, 1 << 8 /*player layerMask*/)
                || (gameObject.name=="black_knight" &&(Physics2D.Raycast(transform.position + new Vector3(0, 1.5f, 0), -1 * transform.right, 7, 1 << 8)
                    ||  Physics2D.Raycast(transform.position + new Vector3(0, 2.5f, 0), -1 * transform.right, 7, 1 << 8))))
                {
               //     Debug.Log("2");
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
                }
                else if (Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.right, 7, 1 << 8 /*player layerMask*/))
                {
                        Flip();
                  //  Debug.Log("3");
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
                }
                else
                {
                   // Debug.Log("4");
                    GetComponent<Animator>().SetFloat("Speed", 0);
                }
            }
            else
            {
             //   Debug.Log("5");
                GetComponent<Animator>().SetFloat("Speed", 0);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (gameObject.name.Equals("zombie"))
        {
            Instantiate(hurtBlood, transform.position, Quaternion.identity);
        }

        if (optionalHealthBar != null)
            optionalHealthBar.fillAmount = health / startHealth;

        Debug.Log(damage + " damage was taken!");
    }

    public void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
