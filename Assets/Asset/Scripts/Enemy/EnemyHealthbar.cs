using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : EnemyVariableManager {

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthInPercentage = enemyStats.health / enemyStats.baseHealth;

        healthBar.value = healthInPercentage;
    }
}
