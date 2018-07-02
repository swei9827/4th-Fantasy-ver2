using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLockInSkill : PlayerVariableManager
{
    private void Awake()
    {
        //chooseSkillBar.transform.localScale = new Vector3(chooseSkillBar.transform.localScale.x, 0, chooseSkillBar.transform.localScale.z);
        /*battleStateManagerScript = this.GetComponent<BattleStateManager>();
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
        isPerfectTiming = false;*/
    }

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<PlayerVariableManager>().holdTimerInPercentage = this.GetComponent<PlayerVariableManager>().holdTimer / this.GetComponent<PlayerVariableManager>().timeNeeded;
        this.GetComponent<PlayerVariableManager>().chooseSkillBar.fillAmount = this.GetComponent<PlayerVariableManager>().holdTimerInPercentage;
        if (this.GetComponent<PlayerVariableManager>().battleStateManagerScript.gameState == BattleStateManager.GAMESTATE.CHOOSING_SKILL)
        {
            if (Input.GetButton(this.GetComponent<PlayerVariableManager>().playerButton))
            {
                this.GetComponent<PlayerVariableManager>().holdTimer += Time.deltaTime;                
                if (this.GetComponent<PlayerVariableManager>().holdTimer >= this.GetComponent<PlayerVariableManager>().timeNeeded)
                {
                    this.GetComponent<PlayerVariableManager>().lockInSkill = this.GetComponent<PlayerVariableManager>().skillHolder[2];
                    this.GetComponent<PlayerVariableManager>().isSkillLockedIn = true;
                    this.GetComponent<PlayerVariableManager>().holdTimer = 0f;
                    this.GetComponent<PlayerVariableManager>().battleStateManagerScript.gameState = BattleStateManager.GAMESTATE.CHOOSING_TARGET;
                }
            }
            else
            {
                this.GetComponent<PlayerVariableManager>().holdTimer = 0f;
            }
        }
        if (this.GetComponent<PlayerVariableManager>().isSkillLockedIn && GetComponent<actionTimeBar>().startSelection < 100f)
        {
            this.GetComponent<PlayerVariableManager>().lockedInTimer += Time.deltaTime;
        }
    }
}
