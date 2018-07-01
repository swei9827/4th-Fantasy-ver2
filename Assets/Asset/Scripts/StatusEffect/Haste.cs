using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haste : ActionCounterStatusEffect {

    private void Awake()
    {
        isActive = true;
        intDuration = 5;
        type = "Good";
    }

    void Start ()
    {
		
	}

	void Update ()
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
                user.GetComponent<PlayerStats>().speed += (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.3f);
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStats>().speed += (int)(user.GetComponent<EnemyStats>().baseSpeed * 0.3f);
            }
            effect = true;
        }
        intDuration--;
        
    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
        {
            user.GetComponent<PlayerStats>().speed -= (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.3f);
        }
        else if (userType == UserType.ENEMY)
        {
            user.GetComponent<EnemyStats>().speed -= (int)(user.GetComponent<EnemyStats>().baseSpeed * 0.3f);
        }
        effect = false;
    }
}
