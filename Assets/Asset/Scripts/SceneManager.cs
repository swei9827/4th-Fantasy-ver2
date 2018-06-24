using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public List<GameObject> playerList;
    public List<GameObject> enemyList;

    private void Update()
    {
        for(int i=0;i<enemyList.Count;i++)
        {
            if(enemyList[i].GetComponent<EnemyStats>().health <= 0)
            {
                enemyList[i].SetActive(false);
            }
        }
    }
}
