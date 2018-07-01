using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantAction : ActionCounterStatusEffect
{

    private void Awake()
    {
        isActive = true;
        intDuration = 3;
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
            RemoveStatus();
        }
        user.GetComponent<actionTimeBar>().startSelection += 100;
       
        intDuration--;
        
    }
    public override void RemoveStatus()
    {
      
    }
}
