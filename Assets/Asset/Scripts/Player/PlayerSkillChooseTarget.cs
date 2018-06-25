using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillChooseTarget : MonoBehaviour
{

    public List<Transform> playerTargetCursorPoints;
    public List<Transform> enemyTargetCursorPoints;
    public Enemy_Spawn enemySpawnScript;
    public Player_Spawn playerSpawnScript;
    public SceneManager sceneManagerScript;
    public BattleStateManager battleStateManagerScript;
    public GameObject targetCursor;
    public int offset;
    public string playerButton;
    public int cursorIndex;
    public float holdTimer;
    public float timeNeeded;
    public List<GameObject> targetedEnemy;
    public GameObject targetCursorBar;
    public float holdTimerInPercentage;
    public bool isTargetLockedIn;
    public bool isEffectTargetLockedIn = false;

    private void Awake()
    {
        //! Filling up reference
        enemySpawnScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Enemy_Spawn>();
        playerSpawnScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Player_Spawn>();
        sceneManagerScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        battleStateManagerScript = this.GetComponent<BattleStateManager>();

        //! Initializing the list of points that the target cursor can go to(enemy side)
        for (int i = 0; i < sceneManagerScript.enemyList.Count; i++)
        {
            enemyTargetCursorPoints.Add(enemySpawnScript.enemySpawnPoints[sceneManagerScript.enemyList[i].GetComponent<EnemyStats>().index]);
        }
        //! target cursor points for the player side
        for (int i = 0; i < playerSpawnScript.playerSpawnPoints.Count; i++)
        {
            playerTargetCursorPoints.Add(playerSpawnScript.playerSpawnPoints[i]);
        }

        //! Initializing the position of the target cursor
        //offset = 2;
        cursorIndex = 0;

        //! Filling up the reference for the playerButton
        if (this.transform.parent.name == "P1_Spawn_Point")
        {
            playerButton = "P1_Button";
        }
        else if (this.transform.parent.name == "P2_Spawn_Point")
        {
            playerButton = "P2_Button";
        }

        isTargetLockedIn = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SkillDetail sDetail = this.GetComponent<Character_Skill_List>().skillHolder[2].GetComponent<SkillDetail>();
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
            //isTargetLockedIn = true;
            if (isTargetLockedIn)
            {
                holdTimer = 0f;
                targetCursor.SetActive(false);
                targetCursorBar.SetActive(false);
                //battleStateManagerScript.gameState = BattleStateManager.GAMESTATE.EXECUTE_SKILL;
            }

        }
    }

    void ScrollTarget(int type)
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
                    targetedEnemy.Add(enemyTargetCursorPoints[cursorIndex].transform.GetChild(0).gameObject);
                }
                else if (type == 2)
                {
                    targetedEnemy.Add(playerTargetCursorPoints[cursorIndex].transform.GetChild(0).gameObject);
                }
                cursorIndex = 0;
                isTargetLockedIn = true;
            }
        }
        else
        {
            holdTimer = 0;
        }
    }
}