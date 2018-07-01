using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySpiritDownArea : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.OFFENSIVE;
        numOfTarget = 0;
        effectDescription = "Spirit Down to All Enemy";
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
            enemyList[i].GetComponent<EnemyStatusList>().actionStatusList.Add(Instantiate(status[0]));
        }
    }
}
