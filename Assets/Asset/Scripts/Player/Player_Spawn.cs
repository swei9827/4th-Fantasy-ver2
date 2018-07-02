using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spawn : MonoBehaviour {

    public List<int> characterIndex;
    public SceneManager sceneManager;
    public List<Transform> playerSpawnPoints;
    public List<GameObject> allCharactersList;
    public List<GameObject> allSkillList;
    public int skillOffset;

    private void Awake()
    {
        //! Instantiating characters based on characterIndex(Input from character selection)
        for (int i=0;i<2;i++)
        {
            if(characterIndex[i] == 1)
            {
                sceneManager.playerList.Add(Instantiate(allCharactersList[0], new Vector2(playerSpawnPoints[i].position.x, playerSpawnPoints[i].position.y), Quaternion.identity, playerSpawnPoints[i]));
            }
            else if (characterIndex[i] == 2)
            {
                sceneManager.playerList.Add(Instantiate(allCharactersList[1], new Vector2(playerSpawnPoints[i].position.x, playerSpawnPoints[i].position.y), Quaternion.identity, playerSpawnPoints[i]));
            }
            else if (characterIndex[i] == 3)
            {
                sceneManager.playerList.Add(Instantiate(allCharactersList[2], new Vector2(playerSpawnPoints[i].position.x, playerSpawnPoints[i].position.y), Quaternion.identity, playerSpawnPoints[i]));
            }
        }

        skillOffset = 5;
        //! For each player
        for(int i=0;i<sceneManager.playerList.Count;i++)
        {
            //! Loop to instantiate skills
            for(int j=0;j<sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillList.Count;j++)
            { 
                sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillHolder.Add(Instantiate(sceneManager.playerList[i].GetComponent<PlayerVariableManager>().skillList[j], new Vector2(sceneManager.playerList[i].transform.GetChild(1).transform.position.x - skillOffset + j, sceneManager.playerList[i].transform.GetChild(1).transform.position.y), Quaternion.identity, sceneManager.playerList[i].transform.GetChild(1)));
            }
        }
        
    }

    void Start()
    {

    }
}
