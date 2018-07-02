using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenDamage : SkillEffect
{


    private void Awake()
    {
        Assign();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 0;
        damage = (int)(user.GetComponent<PlayerStats>().magic * 0.5f);
        effectDescription = "Deal " + damage + " damage";
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
        float multiplier;
        if (Random.Range(1, 100) <= user.GetComponent<PlayerStats>().criticalChance)
        {
            multiplier = 1.5f;
        }
        else
        {
            multiplier = 1;
        }
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].GetComponent<EnemyStats>().health -= (int)(damage*multiplier);
        }
    }
}