using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyTimePrietessSelfBuff : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 1;
        effectDescription = "Extra effect for Time Priestess";
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
        user.GetComponent<PlayerStatusList>().actionCounterStatusList.Add(new TimePriestessExtraSpeed());
        user.GetComponent<PlayerStatusList>().damageCounterStatusList.Add(new EvasionUpDamageCounter());
    }
}

