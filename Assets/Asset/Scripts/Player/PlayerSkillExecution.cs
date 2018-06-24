using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillExecution : MonoBehaviour {

    public List<GameObject> skillList;
    public actionTimeBar actionTimerBarScript;
    public PlayerLockInSkill playerLockInSkillScript;
    public PlayerSkillChooseTarget playerChooseTargetScript;
    public int reward;
    public GameObject testSkill;
    public GameObject testEnemy;
    public PlayerBattleLog battleLog;

    private void Awake()
    {
        actionTimerBarScript = this.GetComponent<actionTimeBar>();
        playerLockInSkillScript = this.GetComponent<PlayerLockInSkill>();
        playerChooseTargetScript = this.GetComponent<PlayerSkillChooseTarget>();
        skillList = this.GetComponent<Character_Skill_List>().skillHolder;
        reward = 10;

        battleLog = GameObject.Find("Panel").GetComponent<PlayerBattleLog>();
            //GameObject.Find("Canvas/Camera Label").GetComponent[UnityEngine.UI.Text]();
    }

    // Use this for initialization
    void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(actionTimerBarScript.selectionBar.fillAmount >= 1)
        {
            if (playerLockInSkillScript.isSkillLockedIn)
            {
                if (playerChooseTargetScript.isTargetLockedIn)
                {
                    //for(int i=0; i < playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionList.Count;i++)
                    playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[0].GetComponent<SkillEffect>().Execute(playerChooseTargetScript.targetedEnemy);
                    //battleLog.AddEvent(this.GetComponent<Stats>().name + " used " + scroll.playerSkillList[2].name);
                    battleLog.AddEvent(this.GetComponent<PlayerStats>().name + " dealt " + playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[0].GetComponent<SkillEffect>().damage + " to " + playerChooseTargetScript.targetedEnemy.GetComponent<EnemyStats>().name);
                    playerLockInSkillScript.isSkillLockedIn = false;
                    playerChooseTargetScript.isTargetLockedIn = false;
                    actionTimerBarScript.selectionBar.fillAmount = 0;
                    actionTimerBarScript.startSelection = 0;
                    //actionTimerBarScript.startSelection = reward;
                }

            }
        }
        /*if (playerLockInSkillScript.isSkillLockedIn)
        {
            if (playerChooseTargetScript.isTargetLockedIn)
            {
                //for(int i=0; i < playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionList.Count;i++)
                playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[0].GetComponent<SkillEffect>().Execute(playerChooseTargetScript.targetedEnemy);
                //actionTimerBarScript.startSelection = reward;
            }

        }*/

    }
}
