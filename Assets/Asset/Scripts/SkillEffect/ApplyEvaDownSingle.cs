﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyEvaDownSingle : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 1;
        effectDescription = "Evasion Down";
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
        targetedEnemy.GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new EvaDown());
    }
}
