using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyActionTimeBar : EnemyVariableManager {    

    // Use this for initialization
    void Start ()
    {
        maxCooldown = 1;
        actionBar.fillAmount = 0;
        curCooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateBar();
    }

    void UpdateBar()
    {
        if(!ATBFull)
        {
            curCooldown += Time.deltaTime * this.GetComponent<EnemyStats>().speed/100;
            actionBar.fillAmount = curCooldown;
            if (curCooldown >= maxCooldown)
            {
                ATBFull = true;
                curCooldown = 0;
            }
        }
        
    }
}
