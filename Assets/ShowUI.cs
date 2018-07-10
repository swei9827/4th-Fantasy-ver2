using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowUI : MonoBehaviour
{
    public GameObject p1Select;
    public GameObject p1Check;
    public GameObject p1Upgrade;
    public GameObject p2Select;
    public GameObject p2Check;
    public GameObject p2Upgrade;
    public GameObject p1Back;
    public GameObject p2Back;

    SceneManager nextScene;

    public enum CAMPSITE_STATE
    {
        SELECTION = 0,
        STATUS_CHECK,
        SKILL_UPGRADE,
        READY
    }

    public CAMPSITE_STATE p1State;
    public CAMPSITE_STATE p2State;

    void Start()
    {
        p1State = CAMPSITE_STATE.SELECTION;
        p2State = CAMPSITE_STATE.SELECTION;
    }

    void Update()
    {
        if (p1State == CAMPSITE_STATE.SELECTION)
        {
            p1Select.SetActive(true);
            p1Check.SetActive(false);
            p1Upgrade.SetActive(false);
            p1Back.SetActive(false);
        }
        else if(p1State == CAMPSITE_STATE.STATUS_CHECK)
        {
            p1Select.SetActive(false);
            p1Check.SetActive(true);
            p1Upgrade.SetActive(false);
            p1Back.SetActive(true);
        }
        else if (p1State == CAMPSITE_STATE.SKILL_UPGRADE)
        {
            p1Select.SetActive(false);
            p1Check.SetActive(false);
            p1Upgrade.SetActive(true);
            p1Back.SetActive(true);
        }
        

        if (p2State == CAMPSITE_STATE.SELECTION)
        {
            p2Select.SetActive(true);
            p2Check.SetActive(false);
            p2Upgrade.SetActive(false);
            p2Back.SetActive(false);
        }
        else if (p2State == CAMPSITE_STATE.STATUS_CHECK)
        {
            p2Select.SetActive(false);
            p2Check.SetActive(true);
            p2Upgrade.SetActive(false);
            p2Back.SetActive(true);
        }
        else if (p2State == CAMPSITE_STATE.SKILL_UPGRADE)
        {
            p2Select.SetActive(false);
            p2Check.SetActive(false);
            p2Upgrade.SetActive(true);
            p2Back.SetActive(true);
        }

        if (p1State == CAMPSITE_STATE.READY && p2State == CAMPSITE_STATE.READY)
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        Application.LoadLevel(3);
    }
}