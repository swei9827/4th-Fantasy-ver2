using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyHasteArea : SkillEffect
{
    private void Awake()
    {
        user = transform.parent.parent.parent.gameObject;
        effectType = SKILL_EFFECT_TYPE.SUPPORTIVE;
        numOfTarget = 0;
        effectDescription = "Buff allies with haste";
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
