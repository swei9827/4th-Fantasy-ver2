using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursed : ActionCounterStatusEffect
{
    int damageCounter;
    private void Awake()
    {
        isActive = true;
        intDuration = 2;
        damageCounter = 1;
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
        if (intDuration <= 0 || damageCounter <= 0)
        {
            isActive = false;
        }
        if (!effect)
        {
            if (userType == UserType.PLAYER)
            {
                user.GetComponent<PlayerStats>().speed -= (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.2f);
                user.GetComponent<PlayerStats>().strength -= (int)(user.GetComponent<PlayerStats>().baseStrength * 0.25f);
                user.GetComponent<PlayerStats>().defense -= (int)(user.GetComponent<PlayerStats>().baseDefense * 0.3f);
                user.GetComponent<PlayerStats>().magic -= (int)(user.GetComponent<PlayerStats>().baseMagic * 0.25f);
                user.GetComponent<PlayerStats>().spirit -= (int)(user.GetComponent<PlayerStats>().baseSpirit * 0.3f);
                user.GetComponent<PlayerStats>().evasion -= 70;
                user.GetComponent<PlayerStats>().accuracy -= 50;
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStats>().speed -= (int)(user.GetComponent<EnemyStats>().baseSpeed * 0.2f);
                user.GetComponent<EnemyStats>().strength -= (int)(user.GetComponent<EnemyStats>().baseStrength * 0.25f);
                user.GetComponent<EnemyStats>().defense -= (int)(user.GetComponent<EnemyStats>().baseDefense * 0.3f);
                user.GetComponent<EnemyStats>().magic -= (int)(user.GetComponent<EnemyStats>().baseMagic * 0.25f);
                user.GetComponent<EnemyStats>().spirit -= (int)(user.GetComponent<EnemyStats>().baseSpirit * 0.3f);
                user.GetComponent<EnemyStats>().evasion -= 70;
                user.GetComponent<EnemyStats>().accuracy -= 50;
            }
            effect = true;
        }
        intDuration--;

    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStats>().speed += (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.2f);
            user.GetComponent<PlayerStats>().strength += (int)(user.GetComponent<PlayerStats>().baseStrength * 0.25f);
            user.GetComponent<PlayerStats>().defense += (int)(user.GetComponent<PlayerStats>().baseDefense * 0.3f);
            user.GetComponent<PlayerStats>().magic += (int)(user.GetComponent<PlayerStats>().baseMagic * 0.25f);
            user.GetComponent<PlayerStats>().spirit += (int)(user.GetComponent<PlayerStats>().baseSpirit * 0.3f);
            user.GetComponent<PlayerStats>().evasion += 70;
            user.GetComponent<PlayerStats>().accuracy += 50;
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStats>().speed += (int)(user.GetComponent<EnemyStats>().baseSpeed * 0.2f);
            user.GetComponent<EnemyStats>().strength += (int)(user.GetComponent<EnemyStats>().baseStrength * 0.25f);
            user.GetComponent<EnemyStats>().defense += (int)(user.GetComponent<EnemyStats>().baseDefense * 0.3f);
            user.GetComponent<EnemyStats>().magic += (int)(user.GetComponent<EnemyStats>().baseMagic * 0.25f);
            user.GetComponent<EnemyStats>().spirit += (int)(user.GetComponent<EnemyStats>().baseSpirit * 0.3f);
            user.GetComponent<EnemyStats>().evasion += 70;
            user.GetComponent<EnemyStats>().accuracy += 50;
        }
        effect = false;
    }
}
