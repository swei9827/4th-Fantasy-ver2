using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChooseTarget : MonoBehaviour {

    public List<GameObject> playerList;
    public bool isTargetChosen = false;
    public bool isSkillUsed = false;
    public GameObject hiAggroTarget;
    public GameObject loAggroTarget;
    public int randNum;
    public GameObject Target;
    public SceneManager SceneManager;
    // public Image cursor;

    private void Awake()
    {
        //enemySpawnScript = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Enemy_Spawn>();
        SceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>();
        playerList = SceneManager.playerList;
    }

    void Update()
    {
        if (!isTargetChosen && this.GetComponent<EnemyActionTimeBar>().ATBFull)
        {
            randNum = Random.Range(1, 101);
            if (playerList[0].GetComponent<PlayerStats>().aggro > playerList[1].GetComponent<PlayerStats>().aggro)
            {
                hiAggroTarget = playerList[0];
                loAggroTarget = playerList[1];
            }
            else if (playerList[1].GetComponent<PlayerStats>().aggro > playerList[0].GetComponent<PlayerStats>().aggro)
            {
                hiAggroTarget = playerList[1];
                loAggroTarget = playerList[0];
            }
            else if (playerList[0].GetComponent<PlayerStats>().aggro == playerList[1].GetComponent<PlayerStats>().aggro)
            {
                if(randNum <= 50)
                {
                    hiAggroTarget = playerList[0];
                    loAggroTarget = playerList[1];
                }
                if (randNum >= 51)
                {
                    hiAggroTarget = playerList[1];
                    loAggroTarget = playerList[0];
                }
            }
            isTargetChosen = true;
        }
        else
        {
            if (isSkillUsed)
            {
                isTargetChosen = false;
                isSkillUsed = false;
                this.GetComponent<EnemyActionTimeBar>().ATBFull = false;
            }
        }

        if (randNum <= 65)
        {
            Target = hiAggroTarget;
        }
        else
        {
            Target = loAggroTarget;
        }
    }

    private void Start()
    {

    }
}
