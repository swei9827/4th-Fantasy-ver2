﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyAccuracyDownArea : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.DEBUFF;
        numOfTarget = 0;
        effectDescription = "Decrease accuracy of all enemies";
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
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(new AccuracyDown());
        }
    }
}
