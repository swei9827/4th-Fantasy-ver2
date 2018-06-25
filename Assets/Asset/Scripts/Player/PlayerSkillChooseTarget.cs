using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillChooseTarget : MonoBehaviour {

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
    public GameObject targetedEnemy;
    public GameObject targetCursorBar;
    public float holdTimerInPercentage;
    public bool isTargetLockedIn;

    private void Awake()
    {
        //! Filling up reference
        enemySpawnScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Enemy_Spawn>();
        playerSpawnScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Player_Spawn>();
        sceneManagerScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        battleStateManagerScript = this.GetComponent<BattleStateManager>();

        //! Initializing the list of points that the target cursor can go to
        for (int i=0;i<sceneManagerScript.enemyList.Count;i++)
        {
            enemyTargetCursorPoints.Add(enemySpawnScript.enemySpawnPoints[sceneManagerScript.enemyList[i].GetComponent<EnemyStats>().index]);
        }
        //! target cursor points for the player side
        for(int i=0;i<sceneManagerScript.playerList.Count;i++)
        {
            playerTargetCursorPoints.Add(playerSpawnScript.playerSpawnPoints[i]);
        }

        //! Initializing the position of the target cursor
        //offset = 2;
        cursorIndex = 0;
        targetCursor.transform.position = new Vector2(enemyTargetCursorPoints[cursorIndex].position.x - offset, enemyTargetCursorPoints[cursorIndex].position.y);
        targetCursorBar.transform.position = new Vector2(enemyTargetCursorPoints[cursorIndex].position.x - offset, enemyTargetCursorPoints[cursorIndex].position.y);

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
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //! Arranging the position of the cursor by its cursorIndex
        targetCursor.transform.position = new Vector2(enemyTargetCursorPoints[cursorIndex].position.x - offset, enemyTargetCursorPoints[cursorIndex].position.y);
        targetCursorBar.transform.position = new Vector2(enemyTargetCursorPoints[cursorIndex].position.x - offset, enemyTargetCursorPoints[cursorIndex].position.y);

        //! Checking if the state of the player is choosing target
        if (battleStateManagerScript.gameState == BattleStateManager.GAMESTATE.CHOOSING_TARGET)
        {
            targetCursor.SetActive(true);
            targetCursorBar.SetActive(true);

            //!Scrolling the list of enemies
            if (Input.GetButtonUp(playerButton))
            {
                cursorIndex++;
                if(cursorIndex > enemyTargetCursorPoints.Count - 1)
                {
                    cursorIndex = 0;
                }
            }

            //! Confirming skill target
            if (Input.GetButton(playerButton))
            {
                holdTimer += Time.deltaTime;
                holdTimerInPercentage = holdTimer / timeNeeded;
                targetCursorBar.transform.localScale = new Vector3(Mathf.Clamp(holdTimerInPercentage, 0, 0.5f), targetCursorBar.transform.localScale.y, targetCursorBar.transform.localScale.z);
                if (holdTimer >= timeNeeded)
                {
                    targetedEnemy = enemyTargetCursorPoints[cursorIndex].transform.GetChild(0).gameObject;
                    holdTimer = 0f;
                    targetCursor.SetActive(false);
                    targetCursorBar.SetActive(false);
                    cursorIndex = 0;
                    isTargetLockedIn = true;
                    battleStateManagerScript.gameState = BattleStateManager.GAMESTATE.EXECUTE_SKILL;
                }
            }
            else
            {
                holdTimer = 0;
            }
        }
    }
}
