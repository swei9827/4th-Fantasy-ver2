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
                }
            }
            else if (userType == UserType.ENEMY)
            {
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
