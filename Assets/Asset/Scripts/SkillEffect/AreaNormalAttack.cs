using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaNormalAttack : SkillEffect
{
    private void Awake()
    {
        Assign();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 0;
        float calDmg = user.GetComponent<PlayerStats>().strength * 0.9f;
        damage = (int)calDmg;
        effectDescription = "Deal "+ damage + " to all enemies";
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
        for(int i=0;i<enemyList.Count;i++)
        {
            enemyList[i].GetComponent<EnemyStats>().health -= (int)((damage - enemyList[i].GetComponent<EnemyStats>().defense * 0.8f)*multiplier);
        }
        Debug.Log("AreaNormalAttack");
    }
}

