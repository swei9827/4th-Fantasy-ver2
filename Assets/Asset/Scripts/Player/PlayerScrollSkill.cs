using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScrollSkill : PlayerVariableManager {

    private void Awake()
    {
        /*if(this.transform.parent.name == "P1_Spawn_Point")
        {
            playerButton = "P1_Button";
        }
        else if(this.transform.parent.name == "P2_Spawn_Point")
        {
            playerButton = "P2_Button";
        }
        skillListScript = this.GetComponent<Character_Skill_List>();

        offset = 5;*/
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<PlayerVariableManager>().battleStateManagerScript.gameState == BattleStateManager.GAMESTATE.CHOOSING_SKILL)
        {
            Scroll();
        }
    }

    void Scroll()
    {
        //! adjusting the position of the skill
        for (int i=0;i< this.GetComponent<PlayerVariableManager>().skillHolder.Count;i++)
        {
            this.GetComponent<PlayerVariableManager>().skillHolder[i].transform.position = new Vector2(this.transform.GetChild(1).transform.position.x - this.GetComponent<PlayerVariableManager>().offset + (i*0.6f) , this.transform.GetChild(1).transform.position.y-0.65f);
        }

        if(Input.GetButtonUp(this.GetComponent<PlayerVariableManager>().playerButton))
        {
            this.GetComponent<PlayerVariableManager>().tempSkill = this.GetComponent<PlayerVariableManager>().skillHolder[4];
            for(int i=0;i< this.GetComponent<PlayerVariableManager>().skillHolder.Count - 1;i++)
            {
                this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count - 1 - i] = this.GetComponent<PlayerVariableManager>().skillHolder[this.GetComponent<PlayerVariableManager>().skillHolder.Count - 1 - i - 1];
            }
            this.GetComponent<PlayerVariableManager>().skillHolder[0] = this.GetComponent<PlayerVariableManager>().tempSkill;
        }
    }
}
