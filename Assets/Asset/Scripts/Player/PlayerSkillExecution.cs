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
<<<<<<< HEAD
    public PlayerBattleLog battleLog;
    public BattleStateManager battleStateManagerScript;
=======
    //public PlayerBattleLog battleLog;
    public battleLog battleLog;
>>>>>>> shaun

    private void Awake()
    {
        actionTimerBarScript = this.GetComponent<actionTimeBar>();
        playerLockInSkillScript = this.GetComponent<PlayerLockInSkill>();
        playerChooseTargetScript = this.GetComponent<PlayerSkillChooseTarget>();
        skillList = this.GetComponent<Character_Skill_List>().skillHolder;
        reward = 10;
        battleStateManagerScript = this.GetComponent<BattleStateManager>();

<<<<<<< HEAD
        battleLog = GameObject.Find("Panel").GetComponent<PlayerBattleLog>();
        //GameObject.Find("Canvas/Camera Label").GetComponent[UnityEngine.UI.Text]();
=======
      //  battleLog = GameObject.Find("Panel").GetComponent<PlayerBattleLog>();
        battleLog = GameObject.Find("Panel").GetComponent<battleLog>();
            //GameObject.Find("Canvas/Camera Label").GetComponent[UnityEngine.UI.Text]();
>>>>>>> shaun
    }

    // Use this for initialization
    void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(battleStateManagerScript.gameState == BattleStateManager.GAMESTATE.EXECUTE_SKILL)
        {
            if(actionTimerBarScript.selectionBar.fillAmount >= 1)
            {
                if (playerLockInSkillScript.isSkillLockedIn)
                {
<<<<<<< HEAD
                    if (playerChooseTargetScript.isTargetLockedIn)
                    {
                        //for(int i=0; i < playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionList.Count;i++)
                        for (int i = 0; i < playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder.Count; i++)
                        {
                            playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[i].GetComponent<SkillEffect>().Execute(playerChooseTargetScript.targetedEnemy);
                        }
                        //battleLog.AddEvent(this.GetComponent<Stats>().name + " used " + scroll.playerSkillList[2].name);
                        battleLog.AddEvent(this.GetComponent<PlayerStats>().name + " dealt " + playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[0].GetComponent<SkillEffect>().damage + " to " + playerChooseTargetScript.targetedEnemy.GetComponent<EnemyStats>().name);
                        playerLockInSkillScript.isSkillLockedIn = false;
                        playerChooseTargetScript.isTargetLockedIn = false;
                        if (this.GetComponent<PlayerLockInSkill>().isPerfectTiming == true)
                        {
                            actionTimerBarScript.startSelection = 20;
                            this.GetComponent<PlayerLockInSkill>().isPerfectTiming = false;
                        }
                        else
                        {
                            actionTimerBarScript.startSelection = 0;
                        }
                        
                        this.GetComponent<actionTimeBar>().isBarFull = false;
                        this.GetComponent<PlayerLockInSkill>().lockedInTimer = 0;
                        this.GetComponent<actionTimeBar>().fullTimer = 0;
                        battleStateManagerScript.gameState = BattleStateManager.GAMESTATE.CHOOSING_SKILL;
                        //actionTimerBarScript.startSelection = reward;
                    }
=======
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
>>>>>>> shaun

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
    public GameObject testSkill;
    public GameObject testEnemy;

    private void Awake()
    {

        actionTimerBarScript = this.GetComponent<actionTimeBar>();
        playerLockInSkillScript = this.GetComponent<PlayerLockInSkill>();
        playerChooseTargetScript = this.GetComponent<PlayerSkillChooseTarget>();
        skillList = this.GetComponent<Character_Skill_List>().skillHolder;

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
                playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[i].GetComponent<SkillEffect>().Execute(playerChooseTargetScript.targetedEnemy);
            }
            playerLockInSkillScript.isSkillLockedIn = false;
            playerChooseTargetScript.isTargetLockedIn = false;
            if (this.GetComponent<PlayerLockInSkill>().isPerfectTiming == true)
            {
                actionTimerBarScript.startSelection = 20;
                this.GetComponent<PlayerLockInSkill>().isPerfectTiming = false;
            }
            else
            {
                actionTimerBarScript.startSelection = 0;
            }
            this.GetComponent<actionTimeBar>().isBarFull = false;
            this.GetComponent<PlayerLockInSkill>().lockedInTimer = 0;
            this.GetComponent<actionTimeBar>().fullTimer = 0;   
            playerChooseTargetScript.targetedEnemy = null;
            actionTimerBarScript.selectionBar.fillAmount = 0;
            battleStateManager.gameState = BattleStateManager.GAMESTATE.CHOOSING_SKILL;
        }
    }
}

