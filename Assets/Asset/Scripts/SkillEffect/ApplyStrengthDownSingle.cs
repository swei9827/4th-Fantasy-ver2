using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyStrengthDownSingle : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 1;
        effectDescription = "Strength Up";
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
        targetedEnemy.GetComponent<EnemyVariableManager>().actionCounterStatusList.Add(new StrengthDown());
    }
}

