using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    public GameObject bloodEffect;
    public GameObject gameOver;


    //Khai bao cac bien UI
    public Slider playerHealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        if(damage <= 0) 
            return;
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;


        if (currentHealth <= 0)
            makeDead();
    }
    void makeDead()
    {
        Instantiate(bloodEffect, transform.position, transform.rotation);
        Destroy (gameObject);
        gameOver.SetActive(true);
    }
}
