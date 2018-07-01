using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasionUpDamageCounter : DamageCounterStatusEffects
{
    private void Awake()
    {
        isActive = true;
        damageCounter = 2;
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
        if(!effect)
        {
            user.GetComponent<PlayerStats>().evasion += 20f;
            effect = true;
        }
        if(damageCounter<=0)
        {
            isActive = false;
        }
    }
    public override void RemoveStatus()
    {
        user.GetComponent<PlayerStats>().evasion -= 20f;
        effect = false;
    }
}
