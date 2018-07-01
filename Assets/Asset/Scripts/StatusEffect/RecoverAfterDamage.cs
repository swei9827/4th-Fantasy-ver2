using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverAfterDamage : ActionCounterStatusEffect
{

    private void Awake()
    {
        isActive = true;
        intDuration = 0;
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
        user.GetComponent<PlayerStats>().health = user.GetComponent<PlayerStats>().baseHealth;

        isActive = false;

    }
    public override void RemoveStatus()
    {

    }
}
