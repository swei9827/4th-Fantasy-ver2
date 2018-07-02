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
        for(int i=0;i<status.Count;i++)
        {
            if(status[i].GetComponent<StatusDetail>() is ActionCounterStatusEffect)
            {
                user.GetComponent<PlayerVariableManager>().actionCounterStatusList.Add(Instantiate(status[i]));
            }
            else if(status[i].GetComponent<StatusDetail>() is DamageCounterStatusEffects)
            {
                user.GetComponent<PlayerVariableManager>().damageCounterStatusList.Add(status[i]);
            }        
        }
        
    }
}

