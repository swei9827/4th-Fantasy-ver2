﻿using System.Collections.Generic;
using UnityEngine;

public class EnemyChooseSkill : EnemyVariableManager {
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<EnemyStats>().health <= this.GetComponent<EnemyStats>().baseHealth * 0.5f)
        {
            canUseUlti = true;
        }

        if (this.GetComponent<EnemyChooseTarget>().isTargetChosen)
        {
            

            if (!canUseUlti)
            {
                skillRandomizer();
            }
            else if(canUseUlti)
            {
                int randomNumber = Random.Range(0, 2);
                if(randomNumber == 0)
                {
                    if(UltiUsed)
                    {
                        skillRandomizer();
                    }
                    else 
                    {
                        Debug.Log("use skill 5");
                        float tempDmg = (this.GetComponent<EnemyStats>().magic * 3f) + (this.GetComponent<EnemyStats>().strength * 0.5f) - (this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().spirit * 1.3f);
                        this.GetComponent<EnemyStats>().health += tempDmg * 2;
                        this.GetComponent<EnemyChooseTarget>().hiAggroTarget.GetComponent<PlayerStats>().health -= tempDmg;
                        this.GetComponent<EnemyChooseTarget>().loAggroTarget.GetComponent<PlayerStats>().health -= tempDmg;
                        UltiUsed = true;
                    }
                }
                else
                {
                    skillRandomizer();
                }
            }
            for (int i = 0; i < GetComponent<EnemyVariableManager>().actionCounterStatusList.Count; i++)
            {
                GetComponent<EnemyVariableManager>().actionCounterStatusList[i].GetComponent<StatusDetail>().user = gameObject;
                GetComponent<EnemyVariableManager>().actionCounterStatusList[i].GetComponent<StatusDetail>().userType = StatusDetail.UserType.ENEMY;
                if (!GetComponent<EnemyVariableManager>().actionCounterStatusList[i].GetComponent<StatusDetail>().isActive)
                {
                    GetComponent<EnemyVariableManager>().actionCounterStatusList[i].GetComponent<StatusDetail>().RemoveStatus();
                    GetComponent<EnemyVariableManager>().actionCounterStatusList.Remove(GetComponent <EnemyVariableManager>().actionCounterStatusList[i]);
                }

                GetComponent<EnemyVariableManager>().actionCounterStatusList[i].GetComponent<StatusDetail>().DoEffect();
            }
        }
        
    }

    public void skillRandomizer()
    {
        randNo = Random.Range(1, 101);

        /*if (randNo <= 50)
        {
            Debug.Log("use skill 1");
            float tempDmg = this.GetComponent<EnemyStats>().strength - (this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().defense * 0.8f);
            this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().health -= tempDmg;
        }
        else if (randNo > 50 && randNo <= 80)
        {
            Debug.Log("use skill 2");
            float tempDmg = (this.GetComponent<EnemyStats>().strength * 1.5f) - (this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().defense * 0.7f);
            this.GetComponent<EnemyChooseTarget>().hiAggroTarget.GetComponent<PlayerStats>().health -= tempDmg;
            this.GetComponent<EnemyChooseTarget>().loAggroTarget.GetComponent<PlayerStats>().health -= tempDmg;
        }
        else if (randNo > 80 && randNo <= 90)
        {
            Debug.Log("use skill 3");
            float tempDmg = (this.GetComponent<EnemyStats>().magic * 0.7f) - (this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().spirit * 0.6f);
            this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().health -= tempDmg;
        }
        else if (randNo > 90 && randNo <= 100)
        {
            Debug.Log("use skill 4");
            float tempDmg = (this.GetComponent<EnemyStats>().magic * 2.5f) - (this.GetComponent<EnemyChooseTarget>().Target.GetComponent<PlayerStats>().spirit * 0.7f);
            this.GetComponent<EnemyChooseTarget>().hiAggroTarget.GetComponent<PlayerStats>().health -= tempDmg;
            this.GetComponent<EnemyChooseTarget>().loAggroTarget.GetComponent<PlayerStats>().health -= tempDmg;
        }*/

        this.GetComponent<EnemyChooseTarget>().isSkillUsed = true;
    }
}
