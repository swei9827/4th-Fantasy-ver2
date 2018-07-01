using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulHuntDamage : SkillEffect
{


    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        damage = (int)(user.GetComponent<PlayerStats>().strength * 0.5f + user.GetComponent<PlayerStats>().magic *0.5f + user.GetComponent<PlayerStats>().baseStrength + user.GetComponent<PlayerStats>().baseMagic);
        effectDescription = "Deal " + damage + " damage and heal for a portion of damage dealed";
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
        float Dmg = (damage - targetedEnemy.GetComponent<EnemyStats>().defense * 0.6f - targetedEnemy.GetComponent<EnemyStats>().spirit) * multiplier;
        targetedEnemy.GetComponent<EnemyStats>().health -= (int)Dmg;
        user.GetComponent<PlayerStats>().health += (int)(Dmg * 0.5f);
    }
}