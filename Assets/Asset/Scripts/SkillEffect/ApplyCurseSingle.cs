﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyCurseSingle : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.DEBUFF;
        numOfTarget = 1;
        effectDescription = "Curse Youuu";
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
        targetedEnemy.GetComponent<EnemyVariableManager>().actionCounterStatusList.Add(Instantiate(status[0]));
    }
}

