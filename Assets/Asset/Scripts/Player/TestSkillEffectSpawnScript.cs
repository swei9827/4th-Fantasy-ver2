using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSkillEffectSpawnScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	    for(int i=0;i<this.GetComponent<Character_Skill_List>().skillHolder[0].GetComponent<SkillDetail>().skillExecutionList.Count;i++)
        {

            Instantiate(this.GetComponent<Character_Skill_List>().skillHolder[0].GetComponent<SkillDetail>().skillExecutionList[i], Vector3.zero, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
