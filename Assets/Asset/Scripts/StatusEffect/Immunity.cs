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
            RemoveStatus();
        }
        if (!effect)
        {
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
                if (GetComponent<PlayerStatusList>().actionCounterStatusList[j].type == "Bad" || GetComponent<PlayerStatusList>().actionCounterStatusList[j].type == "Neutral")
                {
                    GetComponent<PlayerStatusList>().actionCounterStatusList[j].RemoveStatus();
                    GetComponent<PlayerStatusList>().actionCounterStatusList.Remove(GetComponent<PlayerStatusList>().actionCounterStatusList[j]);
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
