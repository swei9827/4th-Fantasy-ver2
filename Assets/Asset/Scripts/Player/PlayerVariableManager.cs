using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVariableManager : MonoBehaviour {

    //!Player Status List
    [Header("Player Status List")]
    public List<StatusDetail> actionCounterStatusList;
    public List<StatusDetail> realTimeStatusList;
    public List<StatusDetail> damageCounterStatusList;

    //! Player Stats
    [Header("Player Stats List")]
    public PlayerStats playerStats;

    //! Player Scroll Skill
    [Header("Player Scroll Skill")]
    public string playerButton;
    public GameObject tempSkill;
    public Character_Skill_List skillListScript;
    public float offset;

    //! Character Skill List
    [Header("Character Skill List")]
    public List<GameObject> skillList;
    public List<GameObject> skillHolder;

    //! Player Lock In Skill
    [Header("Player Lock In Skill")]
    //public BattleStateManager battleStateManager;
    public GameObject lockInSkill;
    //public List<GameObject> skillList;
    //public string playerButton;
    public float holdTimer;
    public float timeNeeded;
    public bool isSkillLockedIn;
    public float lockedInTimer;
    public Image chooseSkillBar;
    public float holdTimerInPercentage;
    public bool isPerfectTiming;

    //! Player Skill Execution
    [Header("Player Skill Execution")]
    public actionTimeBar actionTimerBarScript;
    public GameObject testSkill;
    public GameObject testEnemy;

    //! Player Skill Choose Target
    [Header("Player Skill Choose Target")]
    public List<Transform> playerTargetCursorPoints;
    public List<Transform> enemyTargetCursorPoints;
    public Enemy_Spawn enemySpawnScript;
    public Player_Spawn playerSpawnScript;
    public SceneManager sceneManagerScript;
    public BattleStateManager battleStateManagerScript;
    public GameObject targetCursor;
    public int cursorIndex;
    public float chooseTargetHoldTimer;
    public float chooseTargetTimeNeeded;
    public GameObject targetedEnemy;
    public GameObject targetCursorBar;
    public float chooseTargetHoldTimerInPercentage;
    public bool isTargetLockedIn;
    public bool isEffectTargetLockedIn = false;

    private void Awake()
    {
        playerStats = this.GetComponent<PlayerStats>();
        enemySpawnScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Enemy_Spawn>();
        playerSpawnScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Player_Spawn>();
        sceneManagerScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        battleStateManagerScript = this.GetComponent<BattleStateManager>();
        if (this.transform.parent.name == "P1_Spawn_Point")
        {
            playerButton = "P1_Button";
        }
        else if (this.transform.parent.name == "P2_Spawn_Point")
        {
            playerButton = "P2_Button";
        }
        skillListScript = this.GetComponent<Character_Skill_List>();

        offset = 3.6f;
        timeNeeded = 0.5f;
        isSkillLockedIn = false;
        lockedInTimer = 0f;
        isPerfectTiming = false;
        isTargetLockedIn = false;
        //actionTimerBarScript = 
    }
    private void Start()
    {

    }
}
