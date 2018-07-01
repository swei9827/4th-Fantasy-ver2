using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blind : ActionCounterStatusEffect
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
                user.GetComponent<PlayerStats>().defense -= (int)(user.GetComponent<PlayerStats>().baseDefense * 0.1f);
                user.GetComponent<PlayerStats>().accuracy -= 50;
                user.GetComponent<PlayerStats>().evasion -= 5;
                effect = true;
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStats>().defense -= (int)(user.GetComponent<EnemyStats>().baseDefense * 0.1f);
                user.GetComponent<EnemyStats>().accuracy -= 50;
                user.GetComponent<EnemyStats>().evasion -= 5;
                effect = true;
            }
        }
        intDuration--;
        
    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStats>().defense += (int)(user.GetComponent<PlayerStats>().baseDefense * 0.1f);
            user.GetComponent<PlayerStats>().accuracy += 50;
            user.GetComponent<PlayerStats>().evasion += 5;
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStats>().defense += (int)(user.GetComponent<EnemyStats>().baseDefense * 0.1f);
            user.GetComponent<EnemyStats>().accuracy += 50;
            user.GetComponent<EnemyStats>().evasion += 5;
        }
        effect = false;
    }
}
