using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScrollSkill : PlayerVariableManager {

    private void Awake()
    {
        if(this.transform.parent.name == "P1_Spawn_Point")
        {
            playerButton = "P1_Button";
        }
        else if(this.transform.parent.name == "P2_Spawn_Point")
        {
            playerButton = "P2_Button";
        }
        skillListScript = this.GetComponent<Character_Skill_List>();

        offset = 5;
        battleStateManager = this.GetComponent<BattleStateManager>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(battleStateManager.gameState == BattleStateManager.GAMESTATE.CHOOSING_SKILL)
        {
            Scroll();
        }
    }

    void Scroll()
    {
        //! adjusting the position of the skill
        for (int i=0;i<skillListScript.skillHolder.Count;i++)
        {
            skillListScript.skillHolder[i].transform.position = new Vector2(this.transform.GetChild(1).transform.position.x +3.8f -( offset + (i*0.6f)), this.transform.GetChild(1).transform.position.y-0.65f);
        }

        if(Input.GetButtonUp(playerButton))
        {
            tempSkill = skillListScript.skillHolder[4];
            for(int i=0;i< skillListScript.skillHolder.Count - 1;i++)
            {
                skillListScript.skillHolder[skillListScript.skillHolder.Count - 1 - i] = skillListScript.skillHolder[skillListScript.skillHolder.Count - 1 - i - 1];
            }
            skillListScript.skillHolder[0] = tempSkill;
        }
    }
}
