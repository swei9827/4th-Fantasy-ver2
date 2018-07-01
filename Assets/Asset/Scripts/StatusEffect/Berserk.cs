using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserk : ActionCounterStatusEffect
{
    private void Awake()
    {
        isActive = true;
        intDuration = 4;
        type = "Neutral";
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
        if(!effect)
        {
            if (userType == UserType.PLAYER)
            {
                user.GetComponent<PlayerStats>().strength += (int)(user.GetComponent<PlayerStats>().baseStrength * 1.5f);
                user.GetComponent<PlayerStats>().defense -= (int)(user.GetComponent<PlayerStats>().baseDefense * 0.5f);
                effect = true;
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStats>().strength += (int)(user.GetComponent<EnemyStats>().baseStrength * 1.5f);
                user.GetComponent<EnemyStats>().defense -= (int)(user.GetComponent<EnemyStats>().baseDefense * 0.5f);
                effect = true;
            }
        }
        intDuration--;

    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStats>().strength -= (int)(user.GetComponent<PlayerStats>().baseStrength * 1.5f);
            user.GetComponent<PlayerStats>().defense += (int)(user.GetComponent<PlayerStats>().baseDefense * 0.5f);
            effect = false;
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStats>().strength -= (int)(user.GetComponent<EnemyStats>().baseStrength * 1.5f);
            user.GetComponent<EnemyStats>().defense += (int)(user.GetComponent<EnemyStats>().baseDefense * 0.5f);
            effect = false;
        }
    }
}
