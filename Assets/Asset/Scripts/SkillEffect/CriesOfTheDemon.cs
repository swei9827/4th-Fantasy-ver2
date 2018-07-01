using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriesOfTheDemon : SkillEffect
{
    public GameObject recoverAfterDamage;
    public List<GameObject> selfstatus;
    private void Awake()
    {
        Assign();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 0;
        effectDescription = "Beware the cries of my beloved demons!!!!";
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Execute(GameObject targetedEnemy)
    {
        int collectedDamage = 0;
        float multiplier;
        if (Random.Range(1, 100) <= user.GetComponent<PlayerStats>().criticalChance)
        {
            multiplier = 1.5f;
        }
        else
        {
            multiplier = 1;
        }
        for (int i=0;i<enemyList.Count;i++)
        {
            for (int k = 0; k < status.Count; k++)
            {
                if (status[k].GetComponent<StatusDetail>() is ActionCounterStatusEffect)
                {
                    enemyList[i].GetComponent<EnemyStatusList>().actionStatusList.Add(Instantiate(status[k]));
                }
                else if (status[k].GetComponent<StatusDetail>() is RealTimeStatusEffect)
                {
                    enemyList[i].GetComponent<EnemyStatusList>().secondsStatusList.Add(Instantiate(status[k]));
                }
            }
            enemyList[i].GetComponent<EnemyStats>().health -= (int)((user.GetComponent<PlayerStats>().strength * 0.2f + user.GetComponent<PlayerStats>().magic * 4f - enemyList[i].GetComponent<EnemyStats>().defense*1.5f - enemyList[i].GetComponent<EnemyStats>().magic*2f) * multiplier);
            collectedDamage += (int)((user.GetComponent<PlayerStats>().strength * 0.2f + user.GetComponent<PlayerStats>().magic * 4f - enemyList[i].GetComponent<EnemyStats>().defense * 1.5f - enemyList[i].GetComponent<EnemyStats>().magic * 2f) * multiplier);
        }
        for(int j=0;j<playerList.Count;j++)
        {
            if (playerList[j] == user)
            {
                continue;
            }
            for (int y = 0; y < status.Count; y++)
            {
                if (status[y].GetComponent<StatusDetail>() is ActionCounterStatusEffect)
                {
                    playerList[j].GetComponent<PlayerStatusList>().actionStatusList.Add(Instantiate(status[y]));
                }
                else if (status[y].GetComponent<StatusDetail>() is RealTimeStatusEffect)
                {
                    playerList[j].GetComponent<PlayerStatusList>().secondsStatusList.Add(Instantiate(status[y]));
                }
            }
            playerList[j].GetComponent<PlayerStatusList>().actionStatusList.Add(Instantiate(recoverAfterDamage));
            playerList[j].GetComponent<PlayerStats>().health -= (int)((user.GetComponent<PlayerStats>().strength * 0.2f + user.GetComponent<PlayerStats>().magic * 4f - playerList[j].GetComponent<PlayerStats>().defense * 1.5f - playerList[j].GetComponent<PlayerStats>().magic * 2f) * multiplier);
            collectedDamage += (int)((user.GetComponent<PlayerStats>().strength * 0.2f + user.GetComponent<PlayerStats>().magic * 4f - playerList[j].GetComponent<PlayerStats>().defense * 1.5f - playerList[j].GetComponent<PlayerStats>().magic * 2f) * multiplier);
            if (playerList[j].GetComponent<PlayerStats>().health<=0)
            {
                playerList[j].GetComponent<PlayerStats>().health = 1;
            }
        }
        for(int x = 0;x<selfstatus.Count;x++)
        {
            if (status[x].GetComponent<StatusDetail>() is ActionCounterStatusEffect)
            {
                user.GetComponent<PlayerStatusList>().actionStatusList.Add(Instantiate(selfstatus[x]));
            }
            else if (status[x].GetComponent<StatusDetail>() is RealTimeStatusEffect)
            {
                user.GetComponent<PlayerStatusList>().secondsStatusList.Add(Instantiate(selfstatus[x]));
            }
        }
        user.GetComponent<PlayerStats>().health += (int)(user.GetComponent<PlayerStats>().magic + collectedDamage * 0.5f);
    }
}

