﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRegenSingle : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 1;
        effectDescription = "Regenerate health over time";
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
        targetedEnemy.GetComponent<PlayerVariableManager>().realTimeStatusList.Add(Instantiate(status[0]));
        GameObject.Find("SceneManager").GetComponent<NeutralVariable>().regenCasterMag = (int)(user.GetComponent<PlayerStats>().magic * 0.5f);
    }
}

