using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyStrengthUpArea : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 0;
        effectDescription = "Strength Increase";
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
        for (int i = 0; i < playerList.Count; i++)
        {
            playerList[i].GetComponent<PlayerVariableManager>().actionCounterStatusList.Add(Instantiate(status[0]));
        }
    }
}
