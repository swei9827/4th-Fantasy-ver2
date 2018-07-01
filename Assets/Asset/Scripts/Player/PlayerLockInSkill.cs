using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLockInSkill : PlayerVariableManager
{
    private void Awake()
    {
        //chooseSkillBar.transform.localScale = new Vector3(chooseSkillBar.transform.localScale.x, 0, chooseSkillBar.transform.localScale.z);
        battleStateManager = this.GetComponent<BattleStateManager>();
        skillList = this.GetComponent<Character_Skill_List>().skillHolder;
        if (this.transform.parent.name == "P1_Spawn_Point")
        {
            playerButton = "P1_Button";
        }
        else if (this.transform.parent.name == "P2_Spawn_Point")
        {
            playerButton = "P2_Button";
        }
        timeNeeded = 0.5f;
        isSkillLockedIn = false;
        lockedInTimer = 0f;
        isPerfectTiming = false;
    }

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        holdTimerInPercentage = holdTimer / timeNeeded;
        chooseSkillBar.fillAmount = holdTimerInPercentage;
        if (battleStateManager.gameState == BattleStateManager.GAMESTATE.CHOOSING_SKILL)
        {
            if (Input.GetButton(playerButton))
            {
                holdTimer += Time.deltaTime;                
                if (holdTimer >= timeNeeded)
                {
                    lockInSkill = skillList[2];
                    isSkillLockedIn = true;
                    holdTimer = 0f;
                    battleStateManager.gameState = BattleStateManager.GAMESTATE.CHOOSING_TARGET;
                }
            }
            else
            {
                holdTimer = 0f;
            }
        }
        if (isSkillLockedIn && GetComponent<actionTimeBar>().startSelection < 100f)
        {
            lockedInTimer += Time.deltaTime;
        }
    }
}
