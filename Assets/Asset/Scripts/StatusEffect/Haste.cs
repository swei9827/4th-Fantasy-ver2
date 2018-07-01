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
            RemoveStatus();
        }
        if (!effect)
        {
            user.GetComponent<PlayerStats>().speed += (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.3f);
            effect = true;
        }
        intDuration--;
        
    }
    public override void RemoveStatus()
    {
        user.GetComponent<PlayerStats>().speed -= (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.3f);
        effect = false;
    }
}
