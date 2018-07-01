using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : ActionCounterStatusEffect
{
    public int burnDamage;
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
        user.GetComponent<PlayerStats>().health -= burnDamage;
        effect = true;
        intDuration--;
        
    }
    public override void RemoveStatus()
    {

    }
}
