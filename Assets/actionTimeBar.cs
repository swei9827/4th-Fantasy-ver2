using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actionTimeBar : MonoBehaviour

{
    public Image selectionBar;
    private Color oriColor;
    public float maxSelection;
    public float startSelection;
    public string playerButton;
    public float fullTimer;
    public float timeTest;
    public bool isBarFull = false;



    private void Awake()
    {
        if (this.transform.parent.name == "P1_Spawn_Point")
        {
            playerButton = "P1_Button";
        }
        if (this.transform.parent.name == "P2_Spawn_Point")
        {
            playerButton = "P2_Button";
        }
    }

    // Use this for initialization
    void Start()
    {
        startSelection = 0;
        //maxSelection = this.GetComponent<PlayerStats>().timeNeeded;
        //InvokeRepeating("IncreaseBar", 0f, 0.1f);

    }

    void Update()
    {
        if(startSelection>= 100)
        {
            if (!isBarFull && this.GetComponent<PlayerLockInSkill>().isSkillLockedIn && this.GetComponent<PlayerLockInSkill>().lockedInTimer <= 0.5)
            {
                Debug.Log("Success");
                this.GetComponent<PlayerLockInSkill>().isPerfectTiming = true;
            }
            else
            {
                isBarFull = true;
                fullTimer += Time.deltaTime;
            }
            if(isBarFull && this.GetComponent<PlayerLockInSkill>().isSkillLockedIn && fullTimer <= 0.5)
            {
                Debug.Log("Success");
                this.GetComponent<PlayerLockInSkill>().isPerfectTiming = true;
            }
        }
            
        startSelection +=  Time.deltaTime * this.GetComponent<PlayerStats>().speed;
        float calcSelection = startSelection / 100;
        setSelection(calcSelection);
        
    }
    /*public void Update()
    {

        repeatBar();
    }*/

        //! Counting down the ATB
    void IncreaseBar()
    {
        timeTest += Time.deltaTime;
    }

    //! Setting the amount
    void setSelection(float playerSelection)
    {
        float timeRequire = 1 / (this.GetComponent<PlayerStats>().speed / 100); //10
        float beforePerfect = timeRequire - this.GetComponent<PlayerLockInSkill>().timeNeeded - 0.5f; //9
        float perfectArea = beforePerfect / timeRequire ;
        selectionBar.fillAmount = playerSelection;
        if(selectionBar.fillAmount >= perfectArea && selectionBar.fillAmount < 1)
        {
            if(selectionBar.color != Color.yellow)
            {
                oriColor = selectionBar.color;
            }
            selectionBar.color = Color.yellow;
        }
        else if(selectionBar.fillAmount == 1)
        {
            selectionBar.color = oriColor;
        }
    }

    //reset back to normal;
    void repeatBar()
    {
        if (startSelection >= 100f)
        {
            startSelection = 0;
            setSelection(1);
        }
    }



}


