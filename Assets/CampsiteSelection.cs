using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CampsiteSelection : MonoBehaviour
{
    EventSystem campsiteES;
    public Button p1StatusCheck;
    public Button p1UpgradeSkill;
    public Button p2StatusCheck;
    public Button p2UpgradeSkill;
    public float timeNeeded = 1;
    public float p1Hold,p2Hold;

    void OnEnable()
    {
        campsiteES = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            if(p1StatusCheck.GetComponent<Image>().color == Color.red)
            {
                p1StatusCheck.GetComponent<Image>().color = Color.white;
                p1UpgradeSkill.GetComponent<Image>().color = Color.red;
            }
            else
            {
                p1StatusCheck.GetComponent<Image>().color = Color.red;
                p1UpgradeSkill.GetComponent<Image>().color = Color.white;
            }
        }

        if (Input.GetKeyUp("l"))
        {
            if (p2StatusCheck.GetComponent<Image>().color == Color.blue)
            {
                p2StatusCheck.GetComponent<Image>().color = Color.white;
                p2UpgradeSkill.GetComponent<Image>().color = Color.blue;
            }
            else
            {
                p2StatusCheck.GetComponent<Image>().color = Color.blue;
                p2UpgradeSkill.GetComponent<Image>().color = Color.white;
            }
        }

        if(Input.GetKey("a"))
        {
            p1Hold += Time.deltaTime;
            if (p1Hold > timeNeeded)
            {
                if (p1StatusCheck.GetComponent<Image>().color == Color.red)
                {
                    this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.STATUS_CHECK;
                }
                else
                {
                    this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.SKILL_UPGRADE;
                }
            }
        }
        else
        {
            p1Hold = 0;
        }

        if (Input.GetKey("l"))
        {
            p2Hold += Time.deltaTime;
            if (p2Hold > timeNeeded)
            {
                if (p2StatusCheck.GetComponent<Image>().color == Color.blue)
                {
                    this.GetComponent<ShowUI>().p2State = ShowUI.CAMPSITE_STATE.STATUS_CHECK;
                }
                else
                {
                    this.GetComponent<ShowUI>().p2State = ShowUI.CAMPSITE_STATE.SKILL_UPGRADE;
                }
            }
        }
        else
        {
            p2Hold = 0;
        }
    }
}
