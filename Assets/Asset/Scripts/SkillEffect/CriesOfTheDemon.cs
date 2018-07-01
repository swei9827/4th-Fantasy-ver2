using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriesOfTheDemon : SkillEffect
{
    private void Awake()
    {
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
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new StrengthDown());
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new MagDown());
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new DefenseDown());
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new SpiritDown());
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new AccuracyDown());
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new EvaDown());
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new CritDown());
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new Blind());
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new Confuse());
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new Cursed());
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new Bleed());
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new Flinched());
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new Berserk());
            enemyList[i].GetComponent<EnemyStatusList>().realTimeStatusList.Add(new Poison());
            enemyList[i].GetComponent<EnemyStats>().health -= (int)((user.GetComponent<PlayerStats>().strength * 0.2f + user.GetComponent<PlayerStats>().magic * 4f - enemyList[i].GetComponent<EnemyStats>().defense*1.5f - enemyList[i].GetComponent<EnemyStats>().magic*2f) * multiplier);
            collectedDamage += (int)((user.GetComponent<PlayerStats>().strength * 0.2f + user.GetComponent<PlayerStats>().magic * 4f - enemyList[i].GetComponent<EnemyStats>().defense * 1.5f - enemyList[i].GetComponent<EnemyStats>().magic * 2f) * multiplier);
        }
        for(int j=0;j<playerList.Count;j++)
        {
            if (playerList[j] == this)
            {
                continue;
            }
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new StrengthDown());
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new MagDown());
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new DefenseDown());
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new SpiritDown());
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new AccuracyDown());
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new EvaDown());
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new CritDown());
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new Blind());
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new Confuse());
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new Cursed());
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new Bleed());
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new Flinched());
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new Berserk());
            playerList[j].GetComponent<PlayerStatusList>().realTimeStatusList.Add(new Poison());
            playerList[j].GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new RecoverAfterDamage());
            playerList[j].GetComponent<PlayerStats>().health -= (int)((user.GetComponent<PlayerStats>().strength * 0.2f + user.GetComponent<PlayerStats>().magic * 4f - playerList[j].GetComponent<PlayerStats>().defense * 1.5f - playerList[j].GetComponent<PlayerStats>().magic * 2f) * multiplier);
            collectedDamage += (int)((user.GetComponent<PlayerStats>().strength * 0.2f + user.GetComponent<PlayerStats>().magic * 4f - playerList[j].GetComponent<PlayerStats>().defense * 1.5f - playerList[j].GetComponent<PlayerStats>().magic * 2f) * multiplier);
            if (playerList[j].GetComponent<PlayerStats>().health<=0)
            {
                playerList[j].GetComponent<PlayerStats>().health = 1;
            }
        }
        user.GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new StrengthUp());
        user.GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new MagUp());
        user.GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new DefenseUp());
        user.GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new SpiritUp());
        user.GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new Immunity());
        user.GetComponent<PlayerStatusList>().realTimeStatusList.Add(new Regen());
        user.GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new Haste());
        user.GetComponent<PlayerStats>().health += (int)(user.GetComponent<PlayerStats>().magic + collectedDamage * 0.5f);
    }
}

