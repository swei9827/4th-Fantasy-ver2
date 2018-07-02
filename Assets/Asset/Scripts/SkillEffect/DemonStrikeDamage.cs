using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonStrikeDamage : SkillEffect
{


    private void Awake()
    {
        Assign();
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        damage = (int)(user.GetComponent<PlayerStats>().strength*1.5f);
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
        float Dmg = (damage - targetedEnemy.GetComponent<EnemyStats>().defense * 0.5f) * multiplier;
        targetedEnemy.GetComponent<EnemyStats>().health -= (int)Dmg;
        user.GetComponent<PlayerStats>().health += (int)(Dmg * 0.2f);
    }
}