using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyFlinchedSingleChance : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        effectDescription = "Flinch enemy from action";
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
        if(Random.Range(1,10)<=5)
        {
            targetedEnemy.GetComponent<EnemyVariableManager>().actionCounterStatusList.Add(new Flinched());
        }
    }
}

