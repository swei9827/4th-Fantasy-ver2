using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyPoisonSingle : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.DEBUFF;
        numOfTarget = 1;
        effectDescription = "Poison Attack";
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
        targetedEnemy.GetComponent<EnemyVariableManager>().realTimeStatusList.Add(Instantiate(status[0]));
    }
}
