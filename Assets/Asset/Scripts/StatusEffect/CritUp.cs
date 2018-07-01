using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritUp : ActionCounterStatusEffect
{
    public void Awake()
    {
        isActive = true;
        intDuration = 5;
        type = "Good";
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void DoEffect()
    {
        if (intDuration <= 0)
        {
            isActive = false;
            RemoveStatus();
        }
        if (!effect)
        { 
            user.GetComponent<PlayerStats>().criticalChance += 10;
            effect = true;
        }
        intDuration--;


    }
    public override void RemoveStatus()
    {
        user.GetComponent<PlayerStats>().criticalChance -= 10;
        effect = false;
    }
}
