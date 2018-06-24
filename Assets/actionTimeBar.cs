using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actionTimeBar : MonoBehaviour

{
    public Image selectionBar;
    public float maxSelection;
    public float startSelection;
    public string playerButton;


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
        InvokeRepeating("IncreaseBar", 0f, 0.1f);

    }

    void Update()
    {
        /*if (Input.GetButtonUp(playerButton))
        {
            repeatBar();
        }*/
           
    }
    /*public void Update()
    {

        repeatBar();
    }*/

        //! Counting down the ATB
    void IncreaseBar()
    {
        startSelection +=  Time.deltaTime * this.GetComponent<PlayerStats>().speed;
        float calcSelection = startSelection / 100;
        setSelection(calcSelection);
    }

    //! Setting the amount
    void setSelection(float playerSelection)
    {

        selectionBar.fillAmount = playerSelection;
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


