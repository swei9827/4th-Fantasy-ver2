using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVariableManager : MonoBehaviour {

    //!Player Status List
    public List<StatusDetail> actionCounterStatusList;
    public List<StatusDetail> realTimeStatusList;
    public List<StatusDetail> damageCounterStatusList;

    //! Player Stats
    public PlayerStats playerStats;

    //! Player Scroll Skill
    public string playerButton;
    public GameObject tempSkill;
    public Character_Skill_List skillListScript;
    public int offset;
    public BattleStateManager battleStateManager;

    //! Character Skill List
    public List<GameObject> skillList;
    public List<GameObject> skillHolder;

    //! Player Lock In Skill
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

    //! Player Skill Choose Target
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
    }
}
