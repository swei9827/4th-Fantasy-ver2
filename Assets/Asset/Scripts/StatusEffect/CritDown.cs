using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritDown : ActionCounterStatusEffect
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
        }
        if (!effect)
        {
            if (userType == UserType.PLAYER)
            {
                user.GetComponent<PlayerStats>().criticalChance -= 10;
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStats>().criticalChance -= 10;
            }
            effect = true;
        }
        intDuration--;


    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStats>().criticalChance += 10;
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStats>().criticalChance += 10;
        }
        effect = false;
    }
}
