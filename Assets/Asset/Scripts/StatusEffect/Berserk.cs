using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserk : ActionCounterStatusEffect
{
    private void Awake()
    {
        isActive = true;
        intDuration = 4;
        type = "Neutral";
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
            RemoveStatus();
        }
        if(!effect)
        {
            user.GetComponent<PlayerStats>().strength += (int)(user.GetComponent<PlayerStats>().baseStrength * 1.5f);
            user.GetComponent<PlayerStats>().defense -= (int)(user.GetComponent<PlayerStats>().baseDefense * 0.5f);
            effect = true;
        }
        intDuration--;

    }
    public override void RemoveStatus()
    {
        user.GetComponent<PlayerStats>().strength -= (int)(user.GetComponent<PlayerStats>().baseStrength * 1.5f);
        user.GetComponent<PlayerStats>().defense += (int)(user.GetComponent<PlayerStats>().baseDefense * 0.5f);
        effect = false;
    }
}
