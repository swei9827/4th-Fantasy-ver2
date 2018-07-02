using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyUp : ActionCounterStatusEffect
{
    public void Awake()
    {
        isActive = true;
        intDuration = 5;
        type = "Good";
    }
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {

    }

    public override void DoEffect()
    {
        if (intDuration <= 0)
        {
            isActive = false;
        }
        if (!effect)
        {
            if (userType == UserType.PLAYER)
            {
                user.GetComponent<PlayerStats>().accuracy += 30;
                effect = true;
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStats>().accuracy += 30;
                effect = true;
            }
        }
        intDuration--;

    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStats>().accuracy -= 30;
            effect = false;
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStats>().accuracy -= 30;
            effect = false;
        }
    }
}
