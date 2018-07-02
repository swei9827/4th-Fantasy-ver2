using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immunity : ActionCounterStatusEffect
{

    private void Awake()
    {
        isActive = true;
        intDuration = 2;
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
        if (intDuration <= 0)
        {
            isActive = false;
        }
        if (!effect)
        {
            if (userType == UserType.PLAYER)
            {
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
                        GetComponent<PlayerVariableManager>().realTimeStatusList.Remove(GetComponent<PlayerVariableManager>().realTimeStatusList[j]);
                    }
                }
            }
            else if (userType == UserType.ENEMY)
            {
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
                }
            }
            effect = true;
        }
        intDuration--;

    }
    public override void RemoveStatus()
    {
        effect = false;
    }
}
