using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusList : MonoBehaviour
{

    public List<GameObject> actionStatusList;
    public List<GameObject> secondsStatusList;
    public List<GameObject> damageCountStatusList;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for(int i =0;i<actionStatusList.Count;i++)
        {
            actionStatusList[i].GetComponent<StatusDetail>().user = gameObject;
            actionStatusList[i].GetComponent<StatusDetail>().userType = StatusDetail.UserType.PLAYER;
        }
        for (int i = 0; i < secondsStatusList.Count; i++)
        {
            secondsStatusList[i].GetComponent<StatusDetail>().user = gameObject;
            secondsStatusList[i].GetComponent<StatusDetail>().userType = StatusDetail.UserType.PLAYER;
        }
        for (int i = 0; i < damageCountStatusList.Count; i++)
        {
            damageCountStatusList[i].GetComponent<StatusDetail>().user = gameObject;
            damageCountStatusList[i].GetComponent<StatusDetail>().userType = StatusDetail.UserType.PLAYER;
        }
    }
}
