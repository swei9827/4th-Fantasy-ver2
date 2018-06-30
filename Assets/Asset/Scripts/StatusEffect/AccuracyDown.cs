using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyDown : ActionCounterStatusEffect
{
    public void Awake()
    {
        isActive = true;
        intDuration = 5;
        type = "Bad";
    }
    // Use this for initialization
    void Start()
    {
        DoEffect();
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
            user.GetComponent<EnemyStats>().accuracy -= 30;
            effect = true;
        }
        intDuration--;


    }
    public override void RemoveStatus()
    {
        user.GetComponent<PlayerStats>().accuracy += 30;
        effect = false;
    }
}
