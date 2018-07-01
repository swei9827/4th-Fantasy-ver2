using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : ActionCounterStatusEffect
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
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStats>().health -= (int)(user.GetComponent<PlayerStats>().baseHealth * 0.05f * user.GetComponent<PlayerStats>().defense);
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStats>().health -= (int)(user.GetComponent<EnemyStats>().baseHealth * 0.05f * user.GetComponent<EnemyStats>().defense);
        }
        intDuration--;
        
    }
    public override void RemoveStatus()
    {

    }
}
