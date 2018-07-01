using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaUp : ActionCounterStatusEffect
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
            user.GetComponent<PlayerStats>().evasion += 10f;
            effect = true;
        }
        intDuration--;


    }
    public override void RemoveStatus()
    {
        user.GetComponent<PlayerStats>().evasion += 10f;
        effect = false;
    }
}
