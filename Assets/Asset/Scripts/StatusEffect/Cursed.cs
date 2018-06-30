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
            RemoveStatus();
        }
        if (!effect)
        {
            user.GetComponent<PlayerStats>().speed -= (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.2f);
            user.GetComponent<PlayerStats>().strength -= (int)(user.GetComponent<PlayerStats>().baseStrength * 0.25f);
            user.GetComponent<PlayerStats>().defense -= (int)(user.GetComponent<PlayerStats>().baseDefense * 0.3f);
            user.GetComponent<PlayerStats>().magic -= (int)(user.GetComponent<PlayerStats>().baseMagic * 0.25f);
            user.GetComponent<PlayerStats>().spirit -= (int)(user.GetComponent<PlayerStats>().baseSpirit * 0.3f);
            user.GetComponent<PlayerStats>().evasion -= 70;
            user.GetComponent<PlayerStats>().accuracy -= 50;
            effect = true;
        }
        intDuration--;

    }
    public override void RemoveStatus()
    {
        user.GetComponent<PlayerStats>().speed += (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.2f);
        user.GetComponent<PlayerStats>().strength += (int)(user.GetComponent<PlayerStats>().baseStrength * 0.25f);
        user.GetComponent<PlayerStats>().defense += (int)(user.GetComponent<PlayerStats>().baseDefense * 0.3f);
        user.GetComponent<PlayerStats>().magic += (int)(user.GetComponent<PlayerStats>().baseMagic * 0.25f);
        user.GetComponent<PlayerStats>().spirit += (int)(user.GetComponent<PlayerStats>().baseSpirit * 0.3f);
        user.GetComponent<PlayerStats>().evasion += 70;
        user.GetComponent<PlayerStats>().accuracy += 50;
        effect = false;
    }
}
