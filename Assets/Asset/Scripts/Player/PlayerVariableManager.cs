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

    private void Awake()
    {
        playerStats = this.GetComponent<PlayerStats>();
    }
}
