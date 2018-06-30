using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flinched : ActionCounterStatusEffect
{

    private void Awake()
    {
        isActive = true;
        intDuration = 2;
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
        
        intDuration--;
    }
    public override void RemoveStatus()
    {
        
    }
}
