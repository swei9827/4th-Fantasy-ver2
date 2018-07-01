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
                for (int i = 0; i < GetComponent<PlayerStatusList>().actionStatusList.Count; i++)
                {
                    if (GetComponent<PlayerStatusList>().actionStatusList[i].GetComponent<StatusDetail>().type == "Bad")
                    {
                        GetComponent<PlayerStatusList>().actionStatusList[i].GetComponent<StatusDetail>().RemoveStatus();
                        GetComponent<PlayerStatusList>().actionStatusList.Remove(GetComponent<PlayerStatusList>().actionStatusList[i]);
                    }
                }
                for (int j = 0; j < GetComponent<PlayerStatusList>().secondsStatusList.Count; j++)
                {
                    if (GetComponent<PlayerStatusList>().secondsStatusList[j].GetComponent<StatusDetail>().type == "Bad")
                    {
                        GetComponent<PlayerStatusList>().secondsStatusList[j].GetComponent<StatusDetail>().RemoveStatus();
                        GetComponent<PlayerStatusList>().secondsStatusList.Remove(GetComponent<PlayerStatusList>().secondsStatusList[j]);
                    }
                    if (GetComponent<PlayerStatusList>().actionStatusList[j].GetComponent<StatusDetail>() is CritUp)
                    {
                        GetComponent<PlayerStatusList>().actionStatusList[j].GetComponent<StatusDetail>().effect = false;
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
                for (int i = 0; i < GetComponent<EnemyStatusList>().actionStatusList.Count; i++)
                {
                    if (GetComponent<EnemyStatusList>().actionStatusList[i].GetComponent<StatusDetail>().type == "Bad")
                    {
                        GetComponent<EnemyStatusList>().actionStatusList[i].GetComponent<StatusDetail>().RemoveStatus();
                        GetComponent<EnemyStatusList>().actionStatusList.Remove(GetComponent<EnemyStatusList>().actionStatusList[i]);
                    }
                }
                for (int j = 0; j < GetComponent<EnemyStatusList>().secondsStatusList.Count; j++)
                {
                    if (GetComponent<EnemyStatusList>().secondsStatusList[j].GetComponent<StatusDetail>().type == "Bad")
                    {
                        GetComponent<EnemyStatusList>().secondsStatusList[j].GetComponent<StatusDetail>().RemoveStatus();
                        GetComponent<EnemyStatusList>().secondsStatusList.Remove(GetComponent<EnemyStatusList>().secondsStatusList[j]);
                    }
                    if (GetComponent<EnemyStatusList>().actionStatusList[j].GetComponent<StatusDetail>() is CritUp)
                    {
                        GetComponent<EnemyStatusList>().actionStatusList[j].GetComponent<StatusDetail>().effect = false;
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
            for (int j = 0; j < GetComponent<PlayerStatusList>().actionStatusList.Count; j++)
            {
                if (GetComponent<PlayerStatusList>().actionStatusList[j].GetComponent<StatusDetail>() is CritUp)
                {
                    GetComponent<PlayerStatusList>().actionStatusList[j].GetComponent<StatusDetail>().effect = false;
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
            for (int j = 0; j < GetComponent<EnemyStatusList>().actionStatusList.Count; j++)
            {
                if (GetComponent<EnemyStatusList>().actionStatusList[j].GetComponent<StatusDetail>() is CritUp)
                {
                    GetComponent<EnemyStatusList>().actionStatusList[j].GetComponent<StatusDetail>().effect = false;
                }
            }
            effect = false;
        }
        
    }
}
