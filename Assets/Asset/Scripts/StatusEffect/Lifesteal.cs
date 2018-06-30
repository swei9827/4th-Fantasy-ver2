using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifesteal : ActionCounterStatusEffect
{

    private void Awake()
    {
        isActive = true;
        intDuration = 5;
        type = "Good";
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
        intDuration--;

    }
    public override void RemoveStatus()
    { 
    }
}
