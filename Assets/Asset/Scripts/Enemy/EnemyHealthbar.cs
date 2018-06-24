﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour {

    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    public Slider healthBar;


    float calHealth()
    {
        return currentHealth / maxHealth;
    }
    // Use this for initialization
    void Start()
    {
        maxHealth = 100;
        //reset health
        currentHealth = this.GetComponent<EnemyStats>().health;
        healthBar.value = calHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            dealDamage(this.GetComponent<EnemyStats>().strength);
        currentHealth = this.GetComponent<EnemyStats>().health;
        healthBar.value = calHealth();
    }

    void dealDamage(float damageValue)
    {
        //minus damage
        currentHealth -= damageValue;
        healthBar.value = calHealth();
        //if 0 hp
        if (currentHealth <= 0)
        {
            Debug.Log("DEATH");
        }



    }
}
