using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;


    //Bien de tao hieu ung khi ennemi die
    public GameObject enemyHealthEF;

    //Khai bao cac bien de tao thanh mau cho enemy
    public Slider enemyHealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamge(float damage)
    {
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth < 0)
            makeDead();
    }
    void makeDead()
    {
        Destroy(gameObject);
        Instantiate(enemyHealthEF, transform.position, transform.rotation);
    }
}
