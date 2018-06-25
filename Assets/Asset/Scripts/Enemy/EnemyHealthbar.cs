using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour {

    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    public Slider healthBar;
    public float healthInPercentage;


    // Use this for initialization
    void Start()
    {
        maxHealth = this.GetComponent<EnemyStats>().baseHealth;
        currentHealth = this.GetComponent<EnemyStats>().health;
        healthInPercentage = currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        currentHealth = this.GetComponent<EnemyStats>().health;

        healthInPercentage = currentHealth / maxHealth;

        healthBar.value = healthInPercentage;

    }
}
