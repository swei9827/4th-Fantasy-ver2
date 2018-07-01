using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confuse : ActionCounterStatusEffect
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
            RemoveStatus();
        }
        if (!effect)
        {
            user.GetComponent<PlayerStats>().accuracy -= (int)(user.GetComponent<PlayerStats>().baseAccuracy * 0.3f);
            effect = true;
        }
        intDuration--;
        
    }
    public override void RemoveStatus()
    {
        user.GetComponent<PlayerStats>().speed += (int)(user.GetComponent<PlayerStats>().baseAccuracy * 0.3f);
        effect = false;
    }
}
