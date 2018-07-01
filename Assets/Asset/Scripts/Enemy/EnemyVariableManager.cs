using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyVariableManager : MonoBehaviour {

    //! Enemy Action Time Bar Variable
    [Header("Enemy Action Timer Bar")]
    public float curCooldown;
    public float maxCooldown;
    public Image actionBar;
    public bool ATBFull = false;

    //! Enemy Status List
    [Header("Enemy Status Effect List")]
    public List<StatusDetail> actionCounterStatusList;
    public List<StatusDetail> realTimeStatusList;
    public List<StatusDetail> damageCounterStatusList;

    //! Enemy Stats
    [Header("Enemy Stats")]
    public EnemyStats enemyStats;

    //! Enemy Health Bar
    [Header("Enemy Health Bar")]
    public Slider healthBar;
    public float healthInPercentage;

    //! Enemy Choose Target
    [Header("Enemy Choose Target")]
    public List<GameObject> playerList;
    public bool isTargetChosen = false;
    public bool isSkillUsed = false;
    public GameObject hiAggroTarget;
    public GameObject loAggroTarget;
    public int randNum;
    public GameObject Target;
    public SceneManager SceneManager;

    //! Enemy Choose Skill
    [Header("Enemy Choose Skill")]
    public int randNo;
    //public enemyTarget eT;
    public List<GameObject> enemyList;
    public bool UltiUsed = false;
    public bool canUseUlti = false;
    public List<GameObject> skillList;
    public List<int> skillPercentageUpperLimit;
    public GameObject skillToUse;

    //! Enemy Execute Skill
    [Header("Enemy Execute Skill")]
    public int something;

    private void Awake()
    {
        enemyStats = this.GetComponent<EnemyStats>();
        playerList = GameObject.FindWithTag("SceneManager").GetComponent<SceneManager>().playerList;
    }

}
