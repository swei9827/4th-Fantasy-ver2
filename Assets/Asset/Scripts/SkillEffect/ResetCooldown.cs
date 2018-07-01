using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCooldown : SkillEffect
{


    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 0;
        effectDescription = "Reset normal skills cooldown";
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
        for(int i=0;i< user.GetComponent<PlayerLockInSkill>().skillList.Count;i++)
        {
            user.GetComponent<PlayerLockInSkill>().skillList[i].GetComponent<SkillDetail>().skillCooldown = 0;
        }
    }
}