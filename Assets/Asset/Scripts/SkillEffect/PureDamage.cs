using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PureDamage : SkillEffect {

    public GameObject testEnemy;

    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        //damage = user.GetComponent<PlayerStats>().strength;
        effectDescription = "Deal " + damage + " damage";
    }

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        damage = user.GetComponent<PlayerStats>().strength;
    }

    public override void Execute(GameObject targetedEnemy)
    {
        targetedEnemy.GetComponent<EnemyStats>().health -= damage;
    }
}
