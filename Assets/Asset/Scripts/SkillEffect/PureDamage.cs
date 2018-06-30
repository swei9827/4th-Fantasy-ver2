using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PureDamage : SkillEffect {
    
    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        damage = (int)user.GetComponent<PlayerStats>().strength;
        effectDescription = "Deal " + damage + " damage";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Execute(GameObject targetedEnemy)
    {
        float multiplier;
        if(Random.Range(1,100)<=user.GetComponent<PlayerStats>().criticalChance)
        {
            multiplier = 1.5f;
        }
        else
        {
            multiplier = 1;
        }
        float Dmg = (damage - targetedEnemy.GetComponent<EnemyStats>().defense * 0.8f)*multiplier;
        targetedEnemy.GetComponent<EnemyStats>().health -= (int)Dmg;
        
    }
}
