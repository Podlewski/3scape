using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float startHealth;
    private float health;
    //public Image healthBar;
    //public GameObject loadingScreen;
    //public Slider slider;

    void Start()
    {
        health = startHealth;
    }

    void Update()
    {
        //slider.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DestroyObstacle(float damage)
    {
        health -= damage;
        //healthBar.fillAmount = health / startHealth;
        Debug.Log("damage taken!");
    }
}
