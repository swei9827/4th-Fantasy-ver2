using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillChooseTarget : PlayerVariableManager
{
    private void Awake()
    {
        /*//! Filling up reference
        enemySpawnScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Enemy_Spawn>();
        playerSpawnScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Player_Spawn>();
        sceneManagerScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        battleStateManagerScript = this.GetComponent<BattleStateManager>();

        //! Filling up the reference for the playerButton
        if (this.transform.parent.name == "P1_Spawn_Point")
        {
            playerButton = "P1_Button";
        }
        else if (this.transform.parent.name == "P2_Spawn_Point")
        {
            playerButton = "P2_Button";
        }

        isTargetLockedIn = false;*/

    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*SkillDetail sDetail = this.GetComponent<Character_Skill_List>().skillHolder[2].GetComponent<SkillDetail>();
        
        //! Checking if the state of the player is choosing target
        if (battleStateManagerScript.gameState == BattleStateManager.GAMESTATE.CHOOSING_TARGET)
        {
            //! for each skill effect in the skill execution holder
            targetCursor.SetActive(true);
            targetCursorBar.SetActive(true);

            if (sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().effectType == SkillEffect.SKILL_EFFECT_TYPE.OFFENSIVE)
            {
                targetCursor.transform.position = new Vector2(enemyTargetCursorPoints[cursorIndex].position.x, enemyTargetCursorPoints[cursorIndex].position.y + 2);
                targetCursorBar.transform.position = new Vector2(enemyTargetCursorPoints[cursorIndex].position.x, enemyTargetCursorPoints[cursorIndex].position.y + 2);
            }
            else if (sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().effectType == SkillEffect.SKILL_EFFECT_TYPE.HEAL || sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().effectType == SkillEffect.SKILL_EFFECT_TYPE.SUPPORTIVE)
            {
                targetCursor.transform.position = new Vector2(playerTargetCursorPoints[cursorIndex].position.x, playerTargetCursorPoints[cursorIndex].position.y + 2);
                targetCursorBar.transform.position = new Vector2(playerTargetCursorPoints[cursorIndex].position.x, playerTargetCursorPoints[cursorIndex].position.y + 2);
            }
            if (sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().numOfTarget == 1)
            {
                if (sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().effectType == SkillEffect.SKILL_EFFECT_TYPE.OFFENSIVE)
                {
                    ScrollTarget(1);
                    ConfirmTarget(1);
                }
                else if (sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().effectType == SkillEffect.SKILL_EFFECT_TYPE.HEAL || sDetail.skillExecutionHolder[0].GetComponent<SkillEffect>().effectType == SkillEffect.SKILL_EFFECT_TYPE.SUPPORTIVE)
                {
                    ScrollTarget(2);
                    ConfirmTarget(2);
                }
            }
            else
            {
                isTargetLockedIn = true;
            }
            //isTargetLockedIn = true;
            if (isTargetLockedIn)
            {
                holdTimer = 0f;
                targetCursor.SetActive(false);
                targetCursorBar.SetActive(false);
            }

        }*/

        //! Need to if its AOE
        if(!this.GetComponent<PlayerVariableManager>().isTargetLockedIn)
        {
            for (int i = 0; i < this.GetComponent<PlayerVariableManager>().enemySpawnScript.enemySpawnPoints.Count; i++)
            {
                if (this.GetComponent<PlayerVariableManager>().enemySpawnScript.enemySpawnPoints[i].transform.childCount != 0)
                {
                    this.GetComponent<PlayerVariableManager>().targetedEnemy = this.GetComponent<PlayerVariableManager>().enemySpawnScript.enemySpawnPoints[i].GetChild(0).gameObject;
                    Debug.Log(i);
                    break;
                }
            }
            this.GetComponent<PlayerVariableManager>().isTargetLockedIn = true;
        }
        
    }

    /*void ScrollTarget(int type)
    {
        if (Input.GetButtonUp(playerButton))
        {
            cursorIndex++;
            if (type == 1)
            {
                if (cursorIndex >= enemyTargetCursorPoints.Count)
                {
                    cursorIndex = 0;
                }
            }
            else if (type == 2)
            {
                if (cursorIndex >= playerTargetCursorPoints.Count)
                {
                    cursorIndex = 0;
                }
            }
        }
    }

    void ConfirmTarget(int type)
    {
        if (Input.GetButton(playerButton))
        {
            holdTimer += Time.deltaTime;
            holdTimerInPercentage = holdTimer / timeNeeded;
            targetCursorBar.transform.localScale = new Vector3(Mathf.Clamp(holdTimerInPercentage, 0, 0.5f), targetCursorBar.transform.localScale.y, targetCursorBar.transform.localScale.z);
            if (holdTimer >= timeNeeded)
            {
                //! Here also needs changing
                if (type == 1)
                {
                    targetedEnemy=enemyTargetCursorPoints[cursorIndex].transform.GetChild(0).gameObject;
                }
                else if (type == 2)
                {
                    targetedEnemy=playerTargetCursorPoints[cursorIndex].transform.GetChild(0).gameObject;
                }
                cursorIndex = 0;
                isTargetLockedIn = true;
            }
        }
        else
        {
            holdTimer = 0;
        }
    }*/
}