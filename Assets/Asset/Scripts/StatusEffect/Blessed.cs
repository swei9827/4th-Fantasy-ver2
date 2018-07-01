using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blessed : ActionCounterStatusEffect
{
    int damageCounter;
    private void Awake()
    {
        isActive = true;
        intDuration = 1;
        damageCounter = 2;
        type = "Good";
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public override void DoEffect()
    {
        if (intDuration <= 0 || damageCounter<=0)
        {
            isActive = false;
            RemoveStatus();
        }
        if (!effect)
        {
            user.GetComponent<PlayerStats>().speed += (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.1f);
            user.GetComponent<PlayerStats>().strength += (int)(user.GetComponent<PlayerStats>().baseStrength * 0.5f);
            user.GetComponent<PlayerStats>().defense += (int)(user.GetComponent<PlayerStats>().baseDefense * 0.5f);
            user.GetComponent<PlayerStats>().magic += (int)(user.GetComponent<PlayerStats>().baseMagic * 0.5f);
            user.GetComponent<PlayerStats>().spirit += (int)(user.GetComponent<PlayerStats>().baseSpirit * 0.5f);
            user.GetComponent<PlayerStats>().evasion += 40;
            user.GetComponent<PlayerStats>().criticalChance = 75;
            for (int i = 0; i < GetComponent<PlayerStatusList>().realTimeStatusList.Count; i++)
            {
                if (GetComponent<PlayerStatusList>().realTimeStatusList[i].type == "Bad")
                {
                    GetComponent<PlayerStatusList>().realTimeStatusList[i].RemoveStatus();
                    GetComponent<PlayerStatusList>().realTimeStatusList.Remove(GetComponent<PlayerStatusList>().realTimeStatusList[i]);
                }
            }
            for (int j = 0; j < GetComponent<PlayerStatusList>().actionCounterStatusList.Count; j++)
            {
                if (GetComponent<PlayerStatusList>().actionCounterStatusList[j].type == "Bad")
                {
                    GetComponent<PlayerStatusList>().actionCounterStatusList[j].RemoveStatus();
                    GetComponent<PlayerStatusList>().actionCounterStatusList.Remove(GetComponent<PlayerStatusList>().actionCounterStatusList[j]);
                }
                if (GetComponent<PlayerStatusList>().actionCounterStatusList[j] is CritUp)
                {
                    GetComponent<PlayerStatusList>().actionCounterStatusList[j].effect = false;
                }
            }
            effect = true;
        }
        intDuration--;
    }
    public override void RemoveStatus()
    {
        user.GetComponent<PlayerStats>().speed -= (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.1f);
        user.GetComponent<PlayerStats>().strength -= (int)(user.GetComponent<PlayerStats>().baseStrength * 0.5f);
        user.GetComponent<PlayerStats>().defense -= (int)(user.GetComponent<PlayerStats>().baseDefense * 0.5f);
        user.GetComponent<PlayerStats>().magic -= (int)(user.GetComponent<PlayerStats>().baseMagic * 0.5f);
        user.GetComponent<PlayerStats>().spirit -= (int)(user.GetComponent<PlayerStats>().baseSpirit * 0.5f);
        user.GetComponent<PlayerStats>().evasion -= 40;
        user.GetComponent<PlayerStats>().criticalChance = user.GetComponent<PlayerStats>().baseCriticalChance;
        for (int j = 0; j < GetComponent<PlayerStatusList>().actionCounterStatusList.Count; j++)
        {
            if (GetComponent<PlayerStatusList>().actionCounterStatusList[j] is CritUp)
            {
                GetComponent<PlayerStatusList>().actionCounterStatusList[j].effect = false;
            }
        }
        effect = false;
    }
}
