/*using System.Collections;
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
    //public PlayerBattleLog battleLog;
    public battleLog battleLog;

    private void Awake()
    {
        actionTimerBarScript = this.GetComponent<actionTimeBar>();
        playerLockInSkillScript = this.GetComponent<PlayerLockInSkill>();
        playerChooseTargetScript = this.GetComponent<PlayerSkillChooseTarget>();
        skillList = this.GetComponent<Character_Skill_List>().skillHolder;
        reward = 10;

      //  battleLog = GameObject.Find("Panel").GetComponent<PlayerBattleLog>();
        battleLog = GameObject.Find("Panel").GetComponent<battleLog>();
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
                    for (int i = 0; i < playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder.Count; i++)
                    {
                        playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[i].GetComponent<SkillEffect>().Execute(playerChooseTargetScript.targetedEnemy);
                    }
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

        }

    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillExecution : MonoBehaviour
{

    public List<GameObject> skillList;
    public actionTimeBar actionTimerBarScript;
    public PlayerLockInSkill playerLockInSkillScript;
    public PlayerSkillChooseTarget playerChooseTargetScript;
    public BattleStateManager battleStateManager;
    public int reward;
    public GameObject testSkill;
    public GameObject testEnemy;

    private void Awake()
    {

        actionTimerBarScript = this.GetComponent<actionTimeBar>();
        playerLockInSkillScript = this.GetComponent<PlayerLockInSkill>();
        playerChooseTargetScript = this.GetComponent<PlayerSkillChooseTarget>();
        skillList = this.GetComponent<Character_Skill_List>().skillHolder;
        reward = 10;

        //battleLog = GameObject.Find("Panel").GetComponent<PlayerBattleLog>();
        battleStateManager = this.GetComponent<BattleStateManager>();
        //GameObject.Find("Canvas/Camera Label").GetComponent[UnityEngine.UI.Text]();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //THIS WHOLE THING GOT PROBLEM CANT ACCESS SO FIX THIS FIRST BEFORE PROCEED
        /*if (actionTimerBarScript.selectionBar.fillAmount >= 1)
        {
            if (playerLockInSkillScript.isSkillLockedIn && )
            {
                if (playerChooseTargetScript.isTargetLockedIn)
                {
                    for (int i = 0; i < playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder.Count; i++)
                    {
                        //playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[i].GetComponent<SkillEffect>().DebugL()
                        
                        Debug.Log("Damage Enemy 1");
                    }
                    //battleLog.AddEvent(this.GetComponent<Stats>().name + " used " + scroll.playerSkillList[2].name);
                    //battleLog.AddEvent(this.GetComponent<PlayerStats>().name + " dealt " + playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[0].GetComponent<SkillEffect>().damage + " to " + playerChooseTargetScript.targetedEnemy.GetComponent<EnemyStats>().name);
                    playerLockInSkillScript.isSkillLockedIn = false;
                    playerChooseTargetScript.isTargetLockedIn = false;
                    actionTimerBarScript.selectionBar.fillAmount = 0;
                    actionTimerBarScript.startSelection = 0;
                    //actionTimerBarScript.startSelection = reward;
                }

            }
        }*/
        if (actionTimerBarScript.selectionBar.fillAmount >= 1)
        {
            if (playerLockInSkillScript.isSkillLockedIn && playerChooseTargetScript.isTargetLockedIn)
            {
                battleStateManager.gameState = BattleStateManager.GAMESTATE.EXECUTE_SKILL;
                Debug.Log("HEY");
            }
        }
        if (battleStateManager.gameState == BattleStateManager.GAMESTATE.EXECUTE_SKILL)
        {
            for (int i = 0; i < playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder.Count; i++)
            {
                playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[i].GetComponent<SkillEffect>().Execute(playerChooseTargetScript.targetedEnemy[i]);
            }
            playerLockInSkillScript.isSkillLockedIn = false;
            playerChooseTargetScript.isTargetLockedIn = false;
            playerChooseTargetScript.targetedEnemy.Clear();
            actionTimerBarScript.selectionBar.fillAmount = 0;
            actionTimerBarScript.startSelection = 0;
            battleStateManager.gameState = BattleStateManager.GAMESTATE.CHOOSING_SKILL;
        }
    }
}

