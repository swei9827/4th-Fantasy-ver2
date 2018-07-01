using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyMagUpArea : SkillEffect
{
    private void Awake()
    {
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 0;
        effectDescription = "Magic Up";
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
            playerList[i].GetComponent<PlayerStatusList>().actionStatusList.Add(Instantiate(status[0]));
        }
    }
}
