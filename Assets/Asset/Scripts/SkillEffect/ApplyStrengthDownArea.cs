using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyStrengthDownArea : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 0;
        effectDescription = "Strength Down";
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
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].GetComponent<EnemyVariableManager>().actionCounterStatusList.Add(new StrengthDown());
        }
    }
}
