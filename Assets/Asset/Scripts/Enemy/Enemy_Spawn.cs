﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour {

    public List<int> enemyIndexStage;
    public List<Transform> enemySpawnPoints;
    public List<GameObject> allEnemyList;
    public SceneManager sceneManager;
    public int indexInList;

    private void Awake()
    {
        //! DON'T FORGET TO DO THIS AFTER POC(Getting the enemyIndex from the character selection screen)

        //! Instantiating enemies on specific spawn points based on the size of the enemyIndexStage list.
        /*if (characterIndex[i] == 1)
        {
            sceneManager.playerList.Add(Instantiate(allCharactersList[0], new Vector2(playerSpawnPoints[i].position.x, playerSpawnPoints[i].position.y), Quaternion.identity, playerSpawnPoints[i]));
        }*/
        indexInList = 0;
        if (enemyIndexStage.Count == 1)
        {
            sceneManager.enemyList.Add(Instantiate(allEnemyList[enemyIndexStage[0] - 1], new Vector2(enemySpawnPoints[1].position.x, enemySpawnPoints[1].position.y), Quaternion.identity, enemySpawnPoints[1]));
            sceneManager.enemyList[0].GetComponent<EnemyStats>().index = 1;
        }
        else if (enemyIndexStage.Count == 2)
        {
            for(int i=0;i<enemyIndexStage.Count;i++)
            {
                sceneManager.enemyList.Add(Instantiate(allEnemyList[enemyIndexStage[i] - 1], new Vector2(enemySpawnPoints[i*2].position.x, enemySpawnPoints[i * 2].position.y), Quaternion.identity, enemySpawnPoints[i * 2]));
                sceneManager.enemyList[i].GetComponent<EnemyStats>().index = i*2;
            }
        }
        else if (enemyIndexStage.Count == 3 || enemyIndexStage.Count == 5)
        {
            for (int i = 0; i < enemyIndexStage.Count; i++)
            {
                sceneManager.enemyList.Add(Instantiate(allEnemyList[enemyIndexStage[i] - 1], new Vector2(enemySpawnPoints[i].position.x, enemySpawnPoints[i].position.y), Quaternion.identity, enemySpawnPoints[i]));
                sceneManager.enemyList[i].GetComponent<EnemyStats>().index = i;
            }
        }
        else if (enemyIndexStage.Count == 4)
        {
            for (int i = 0; i < enemyIndexStage.Count / 2; i++)
            {
                sceneManager.enemyList.Add(Instantiate(allEnemyList[enemyIndexStage[i] - 1], new Vector2(enemySpawnPoints[i * 2].position.x, enemySpawnPoints[i * 2].position.y), Quaternion.identity, enemySpawnPoints[i * 2]));
                sceneManager.enemyList[i].GetComponent<EnemyStats>().index = i*2;
            }
            for (int i = 2; i < enemyIndexStage.Count; i++)
            {
                sceneManager.enemyList.Add(Instantiate(allEnemyList[enemyIndexStage[i] - 1], new Vector2(enemySpawnPoints[i + 1].position.x, enemySpawnPoints[i + 1].position.y), Quaternion.identity, enemySpawnPoints[i + 1]));
                sceneManager.enemyList[i].GetComponent<EnemyStats>().index = i + 1;
            }
        }
    }

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
