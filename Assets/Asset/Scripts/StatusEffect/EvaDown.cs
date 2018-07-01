using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaDown : ActionCounterStatusEffect
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
                user.GetComponent<PlayerStats>().evasion -= 30;
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStats>().evasion -= 30;
            }
            effect = true;
        }
        intDuration--;


    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStats>().evasion += 30;
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStats>().evasion += 30;
        }
        effect = false;
    }
}
