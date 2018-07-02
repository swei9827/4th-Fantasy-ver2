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
        }
        if (!effect)
        {
            if (userType == UserType.PLAYER)
            {
                user.GetComponent<PlayerStats>().speed += (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.1f);
                user.GetComponent<PlayerStats>().strength += (int)(user.GetComponent<PlayerStats>().baseStrength * 0.5f);
                user.GetComponent<PlayerStats>().defense += (int)(user.GetComponent<PlayerStats>().baseDefense * 0.5f);
                user.GetComponent<PlayerStats>().magic += (int)(user.GetComponent<PlayerStats>().baseMagic * 0.5f);
                user.GetComponent<PlayerStats>().spirit += (int)(user.GetComponent<PlayerStats>().baseSpirit * 0.5f);
                user.GetComponent<PlayerStats>().evasion += 40;
                user.GetComponent<PlayerStats>().criticalChance = 75;
                for (int i = 0; i < GetComponent<PlayerVariableManager>().actionCounterStatusList.Count; i++)
                {
                    if (GetComponent<PlayerVariableManager>().actionCounterStatusList[i].GetComponent<StatusDetail>().type == "Bad")
                    {
                        GetComponent<PlayerVariableManager>().actionCounterStatusList[i].GetComponent<StatusDetail>().RemoveStatus();
                        GetComponent<PlayerVariableManager>().actionCounterStatusList.Remove(GetComponent<PlayerVariableManager>().actionCounterStatusList[i]);
                    }
                }
                for (int j = 0; j < GetComponent<PlayerVariableManager>().realTimeStatusList.Count; j++)
                {
                    if (GetComponent<PlayerVariableManager>().realTimeStatusList[j].GetComponent<StatusDetail>().type == "Bad")
                    {
                        GetComponent<PlayerVariableManager>().realTimeStatusList[j].GetComponent<StatusDetail>().RemoveStatus();
                        GetComponent<PlayerVariableManager>().realTimeStatusList.Remove(GetComponent<PlayerVariableManager>().actionCounterStatusList[j]);
                    }
                    if (GetComponent<PlayerVariableManager>().actionCounterStatusList[j].GetComponent<StatusDetail>() is CritUp)
                    {
                        GetComponent<PlayerVariableManager>().actionCounterStatusList[j].GetComponent<StatusDetail>().effect = false;
                    }
                }
                effect = true;
            }
            else if (userType == UserType.ENEMY)
            {
                user.GetComponent<EnemyStats>().speed += (int)(user.GetComponent<EnemyStats>().baseSpeed * 0.1f);
                user.GetComponent<EnemyStats>().strength += (int)(user.GetComponent<EnemyStats>().baseStrength * 0.5f);
                user.GetComponent<EnemyStats>().defense += (int)(user.GetComponent<EnemyStats>().baseDefense * 0.5f);
                user.GetComponent<EnemyStats>().magic += (int)(user.GetComponent<EnemyStats>().baseMagic * 0.5f);
                user.GetComponent<EnemyStats>().spirit += (int)(user.GetComponent<EnemyStats>().baseSpirit * 0.5f);
                user.GetComponent<EnemyStats>().evasion += 40;
                user.GetComponent<EnemyStats>().criticalChance = 75;
                for (int i = 0; i < GetComponent<EnemyVariableManager>().actionCounterStatusList.Count; i++)
                {
                    if (GetComponent<EnemyVariableManager>().actionCounterStatusList[i].GetComponent<StatusDetail>().type == "Bad")
                    {
                        GetComponent<EnemyVariableManager>().actionCounterStatusList[i].GetComponent<StatusDetail>().RemoveStatus();
                        GetComponent<EnemyVariableManager>().actionCounterStatusList.Remove(GetComponent<EnemyVariableManager>().actionCounterStatusList[i]);
                    }
                }
                for (int j = 0; j < GetComponent<EnemyVariableManager>().realTimeStatusList.Count; j++)
                {
                    if (GetComponent<EnemyVariableManager>().realTimeStatusList[j].GetComponent<StatusDetail>().type == "Bad")
                    {
                        GetComponent<EnemyVariableManager>().realTimeStatusList[j].GetComponent<StatusDetail>().RemoveStatus();
                        GetComponent<EnemyVariableManager>().realTimeStatusList.Remove(GetComponent<EnemyVariableManager>().realTimeStatusList[j]);
                    }
                    if (GetComponent<EnemyVariableManager>().actionCounterStatusList[j].GetComponent<StatusDetail>() is CritUp)
                    {
                        GetComponent<EnemyVariableManager>().actionCounterStatusList[j].GetComponent<StatusDetail>().effect = false;
                    }
                }
                effect = true;
            }
        }
        intDuration--;
    }
    public override void RemoveStatus()
    {
        if (userType == UserType.PLAYER)
         {
            user.GetComponent<PlayerStats>().speed -= (int)(user.GetComponent<PlayerStats>().baseSpeed * 0.1f);
            user.GetComponent<PlayerStats>().strength -= (int)(user.GetComponent<PlayerStats>().baseStrength * 0.5f);
            user.GetComponent<PlayerStats>().defense -= (int)(user.GetComponent<PlayerStats>().baseDefense * 0.5f);
            user.GetComponent<PlayerStats>().magic -= (int)(user.GetComponent<PlayerStats>().baseMagic * 0.5f);
            user.GetComponent<PlayerStats>().spirit -= (int)(user.GetComponent<PlayerStats>().baseSpirit * 0.5f);
            user.GetComponent<PlayerStats>().evasion -= 40;
            user.GetComponent<PlayerStats>().criticalChance = user.GetComponent<PlayerStats>().baseCriticalChance;
            for (int j = 0; j < GetComponent<PlayerVariableManager>().actionCounterStatusList.Count; j++)
            {
                if (GetComponent<PlayerVariableManager>().actionCounterStatusList[j].GetComponent<StatusDetail>() is CritUp)
                {
                    GetComponent<PlayerVariableManager>().actionCounterStatusList[j].GetComponent<StatusDetail>().effect = false;
                }
            }
            effect = false;
        }
            else if (userType == UserType.ENEMY)
            {
            user.GetComponent<EnemyStats>().speed -= (int)(user.GetComponent<EnemyStats>().baseSpeed * 0.1f);
            user.GetComponent<EnemyStats>().strength -= (int)(user.GetComponent<EnemyStats>().baseStrength * 0.5f);
            user.GetComponent<EnemyStats>().defense -= (int)(user.GetComponent<EnemyStats>().baseDefense * 0.5f);
            user.GetComponent<EnemyStats>().magic -= (int)(user.GetComponent<EnemyStats>().baseMagic * 0.5f);
            user.GetComponent<EnemyStats>().spirit -= (int)(user.GetComponent<EnemyStats>().baseSpirit * 0.5f);
            user.GetComponent<EnemyStats>().evasion -= 40;
            user.GetComponent<EnemyStats>().criticalChance = user.GetComponent<EnemyStats>().baseCriticalChance;
            for (int j = 0; j < GetComponent<EnemyVariableManager>().actionCounterStatusList.Count; j++)
            {
                if (GetComponent<EnemyVariableManager>().actionCounterStatusList[j].GetComponent<StatusDetail>() is CritUp)
                {
                    GetComponent<EnemyVariableManager>().actionCounterStatusList[j].GetComponent<StatusDetail>().effect = false;
                }
            }
            effect = false;
        }
        
    }
}
