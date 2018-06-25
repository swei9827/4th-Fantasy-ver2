﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLockInSkill : MonoBehaviour
{

    public BattleStateManager battleStateManager;
    public GameObject lockInSkill;
    public List<GameObject> skillList;
    public string playerButton;
    public float holdTimer;
    public float timeNeeded;
    public bool isSkillLockedIn;
    public float lockedInTimer;
    public Image chooseSkillBar;
    public float holdTimerInPercentage;
    public bool isPerfectTiming;

    private void Awake()
    {
        chooseSkillBar.transform.localScale = new Vector3(chooseSkillBar.transform.localScale.x, 0, chooseSkillBar.transform.localScale.z);
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
<<<<<<< HEAD
    void Start () {
        Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update ()
=======
    void Start()
>>>>>>> shaun
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (battleStateManager.gameState == BattleStateManager.GAMESTATE.CHOOSING_SKILL)
        {
<<<<<<< HEAD
           
=======

>>>>>>> shaun
            if (Input.GetButton(playerButton))
            {
                holdTimer += Time.deltaTime;
                holdTimerInPercentage = holdTimer / timeNeeded;
                //chooseActionBar.transform.localScale = new Vector3(chooseActionBar.transform.localScale.x, Mathf.Clamp(chooseActionBarInPercentage, 0, 1), chooseActionBar.transform.localScale.z);
                chooseSkillBar.transform.localScale = new Vector3(chooseSkillBar.transform.localScale.x, Mathf.Clamp(holdTimerInPercentage, 0, 1), chooseSkillBar.transform.localScale.z);
                if (holdTimer >= timeNeeded)
                {
                    lockInSkill = skillList[2];
                    isSkillLockedIn = true;
                    holdTimer = 0f;
                    battleStateManager.gameState = BattleStateManager.GAMESTATE.CHOOSING_TARGET;
                }
<<<<<<< HEAD
                
=======

>>>>>>> shaun
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
<<<<<<< HEAD

   
      
 }
=======
}
>>>>>>> shaun
