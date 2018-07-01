using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseDown : ActionCounterStatusEffect
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
                user.GetComponent<PlayerStats>().defense -= (int)(user.GetComponent<PlayerStats>().baseDefense * 0.3f);
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStats>().defense -= (int)(user.GetComponent<EnemyStats>().baseDefense * 0.3f);
            }
            
            effect = true;
        }
        intDuration--;


    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStats>().defense += (int)(user.GetComponent<PlayerStats>().baseDefense * 0.3f);
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStats>().defense += (int)(user.GetComponent<EnemyStats>().baseDefense * 0.3f);
        }
        effect = false;
    }
}
