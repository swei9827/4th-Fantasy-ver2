using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : ActionCounterStatusEffect
{
    private void Awake()
    {
        isActive = true;
        intDuration = 5;
        type = "Bad";
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public override void DoEffect()
    {
        if (intDuration <= 0)
        {
            isActive = false;
        }
        user.GetComponent<PlayerStats>().health -= (int)(user.GetComponent<PlayerStats>().baseHealth * 0.05f * user.GetComponent<PlayerStats>().defense);
        intDuration--;
        
    }
    public override void RemoveStatus()
    {

    }
}
