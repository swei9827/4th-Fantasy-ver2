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
    public Text p1Ready;
    public Text p2Ready;
    public Text p1Back;
    public Text p2Back;
    public float timeNeeded = 1;
    public float p1Hold,p2Hold;

    void OnEnable()
    {
        campsiteES = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        Select();
        if(Input.GetKey("a"))
        {
            p1Hold += Time.deltaTime;
            if (p1Hold > timeNeeded)
            {
                if(this.GetComponent<ShowUI>().p1State != ShowUI.CAMPSITE_STATE.READY)
                {
                    if (p1StatusCheck.GetComponent<Image>().color == Color.red)
                    {
                        this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.STATUS_CHECK;
                    }
                    else if(p1UpgradeSkill.GetComponent<Image>().color == Color.red)
                    {
                        this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.SKILL_UPGRADE;
                    }
                    else if(p1Ready.GetComponent<Text>().color == Color.yellow)
                    {
                        p1Ready.GetComponent<Text>().color = Color.green;
                        this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.READY;
                        p1Hold = 0;
                    }
                }
                else if(this.GetComponent<ShowUI>().p1State == ShowUI.CAMPSITE_STATE.READY)
                {
                    p1Ready.GetComponent<Text>().color = Color.yellow;
                    this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.SELECTION;
                    p1Hold = 0;
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
                if (this.GetComponent<ShowUI>().p2State != ShowUI.CAMPSITE_STATE.READY)
                {
                    if (p2StatusCheck.GetComponent<Image>().color == Color.blue)
                    {
                        this.GetComponent<ShowUI>().p2State = ShowUI.CAMPSITE_STATE.STATUS_CHECK;
                    }
                    else if (p2UpgradeSkill.GetComponent<Image>().color == Color.blue)
                    {
                        this.GetComponent<ShowUI>().p2State = ShowUI.CAMPSITE_STATE.SKILL_UPGRADE;
                    }
                    else if (p2Ready.GetComponent<Text>().color == Color.yellow)
                    {
                        p2Ready.GetComponent<Text>().color = Color.green;
                        this.GetComponent<ShowUI>().p2State = ShowUI.CAMPSITE_STATE.READY;
                        p2Hold = 0;
                    }
                }
                else if (this.GetComponent<ShowUI>().p2State == ShowUI.CAMPSITE_STATE.READY)
                {
                    p2Ready.GetComponent<Text>().color = Color.yellow;
                    this.GetComponent<ShowUI>().p2State = ShowUI.CAMPSITE_STATE.SELECTION;
                    p2Hold = 0;
                }
            }
        }
        else
        {
            p2Hold = 0;
        }
    }

    private void Select()
    {
        if (Input.GetKeyUp("a"))
        {
            if (p1StatusCheck.GetComponent<Image>().color == Color.red)
            {
                p1StatusCheck.GetComponent<Image>().color = Color.white;
                p1UpgradeSkill.GetComponent<Image>().color = Color.red;
            }
            else if (p1UpgradeSkill.GetComponent<Image>().color == Color.red)
            {
                p1UpgradeSkill.GetComponent<Image>().color = Color.white;
                p1Ready.GetComponent<Text>().color = Color.yellow;
            }
            else if (p1Ready.GetComponent<Text>().color == Color.yellow)
            {
                p1StatusCheck.GetComponent<Image>().color = Color.red;
                p1Ready.color = Color.red;
            }
        }

        if (Input.GetKeyUp("l"))
        {
            if (p2StatusCheck.GetComponent<Image>().color == Color.blue)
            {
                p2StatusCheck.GetComponent<Image>().color = Color.white;
                p2UpgradeSkill.GetComponent<Image>().color = Color.blue;
            }
            else if (p2UpgradeSkill.GetComponent<Image>().color == Color.blue)
            {
                p2UpgradeSkill.GetComponent<Image>().color = Color.white;
                p2Ready.GetComponent<Text>().color = Color.yellow;
            }
            else if (p2Ready.GetComponent<Text>().color == Color.yellow)
            {
                p2StatusCheck.GetComponent<Image>().color = Color.blue;
                p2Ready.color = Color.red;
            }
        }
    }

    void Back()
    {
        if(this.GetComponent<ShowUI>().p2State == ShowUI.CAMPSITE_STATE.STATUS_CHECK || this.GetComponent<ShowUI>().p2State == ShowUI.CAMPSITE_STATE.SKILL_UPGRADE)
        {
            if (Input.GetKey("a"))
            {
                p1Hold += Time.deltaTime;
                if (p1Hold > timeNeeded)
                {
                    if (this.GetComponent<ShowUI>().p1State != ShowUI.CAMPSITE_STATE.READY)
                    {
                        if (p1StatusCheck.GetComponent<Image>().color == Color.red)
                        {
                            this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.STATUS_CHECK;
                        }
                        else if (p1UpgradeSkill.GetComponent<Image>().color == Color.red)
                        {
                            this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.SKILL_UPGRADE;
                        }
                        else if (p1Ready.GetComponent<Text>().color == Color.yellow)
                        {
                            p1Ready.GetComponent<Text>().color = Color.green;
                            this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.READY;
                            p1Hold = 0;
                        }
                    }
                    else if (this.GetComponent<ShowUI>().p1State == ShowUI.CAMPSITE_STATE.READY)
                    {
                        p1Ready.GetComponent<Text>().color = Color.yellow;
                        this.GetComponent<ShowUI>().p1State = ShowUI.CAMPSITE_STATE.SELECTION;
                        p1Hold = 0;
                    }

                }
            }
            else
            {
                p1Hold = 0;
            }
        }
    }
}
