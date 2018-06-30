using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyAccuracyDownArea : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.DEBUFF;
        numOfTarget = 0;
        effectDescription = "Decrease accuracy of all enemies";
        SetReference();
    }

    // Use this for initialization
    void Start()
    {
        Execute();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Execute()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].GetComponent<EnemyStatusList>().actionCounterStatusList.Add(gameObject.AddComponent<AccuracyDown>());
        }
        Debug.Log("HEY");
    }
}
