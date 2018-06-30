using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePriestessExtraSpeed : ActionCounterStatusEffect
{
    public void Awake()
    {
        isActive = true;
        intDuration = 2;
        type = "Good";
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
            user.GetComponent<PlayerStats>().speed += (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.1f);
            effect = true;
        }
        intDuration--;
        
    }
    public override void RemoveStatus()
    {
        user.GetComponent<PlayerStats>().speed -= (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.1f);
        effect = false;
    }
}
