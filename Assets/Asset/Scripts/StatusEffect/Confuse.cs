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
        }
        if (!effect)
        {
            if (userType == UserType.PLAYER)
            {
                user.GetComponent<PlayerStats>().accuracy -= (int)(user.GetComponent<PlayerStats>().baseAccuracy * 0.3f);
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStats>().accuracy -= (int)(user.GetComponent<EnemyStats>().baseAccuracy * 0.3f);
            }
            effect = true;
        }
        intDuration--;
        
    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStats>().accuracy += (int)(user.GetComponent<PlayerStats>().baseAccuracy * 0.3f);
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStats>().accuracy += (int)(user.GetComponent<EnemyStats>().baseAccuracy * 0.3f);
        }
        effect = false;
    }
}
