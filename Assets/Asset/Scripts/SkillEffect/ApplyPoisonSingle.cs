using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyPoisonSingle : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
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
        targetedEnemy.GetComponent<EnemyStatusList>().secondsStatusList.Add(Instantiate(status[0]));
    }
}
