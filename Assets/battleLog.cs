using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleLog : MonoBehaviour

{
    // private VARS
    private List<string> eventList = new List<string>();
    private new string guiText = "";

    // public vars
    public int maxLines = 4; //hpw many lines to add in the log
    public string playerButton;

    void OnGUI()
    {
        GUI.Label(new Rect(20, 10, Screen.width, (Screen.height / 12) - 10), guiText, GUI.skin.textArea);
    }

    //get component 
    public battleLog eventLog;
    private readonly string playerLockInSkillScript;

    void Update()
    {
        //GetKey(KeyCode.Joystick1Button0)
        if (Input.GetKeyDown("a")) ///player actions
        {
            // Debug.Log("HELLOOO");
            ///AddEvent(this.GetComponent<PlayerStats>().name + " dealt " + playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[0].GetComponent<SkillEffect>().damage + " to " + playerChooseTargetScript.targetedEnemy.GetComponent<EnemyStats>().name);
            AddEvent("XXXX");
            //AddEvent("LOGGGG");
            // AddEvent("Player used healing on player 2");
        }
        if (Input.GetKeyDown("l")) ///player actions
        {
            // Debug.Log("HELLOOO");
            ///AddEvent(this.GetComponent<PlayerStats>().name + " dealt " + playerLockInSkillScript.lockInSkill.GetComponent<SkillDetail>().skillExecutionHolder[0].GetComponent<SkillEffect>().damage + " to " + playerChooseTargetScript.targetedEnemy.GetComponent<EnemyStats>().name);
            AddEvent("lllll");
            //AddEvent("LOGGGG");
            // AddEvent("Player used healing on player 2");
        }
    }



    public void AddEvent(string playerLockInSkillScript)
    {
        eventList.Add(playerLockInSkillScript);

        if (eventList.Count >= maxLines)
            eventList.RemoveAt(0);

        guiText = "";///insert the action

        //foreach (string logEvent in eventList)
        foreach (string logEvent in eventList)
        {
            guiText += logEvent;
            guiText += "\n";//next lne
        }
    }

}