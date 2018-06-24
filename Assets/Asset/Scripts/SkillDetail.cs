using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDetail : MonoBehaviour {

    public string skillName;
    public string skillDescription;
    public int skillCooldown;
    public int maxSkillCooldown;
    public GameObject user;
    public List<GameObject> skillExecutionList;
    public List<GameObject> skillExecutionHolder;

    private void Awake()
    {
        user = this.transform.parent.parent.gameObject;
        for (int i = 0; i < skillExecutionList.Count; i++)
        {
            skillExecutionHolder.Add(Instantiate(skillExecutionList[i], new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity, this.gameObject.transform));
        }
        for (int i=0;i< skillExecutionHolder.Count;i++)
        {
            skillExecutionHolder[i].GetComponent<SkillEffect>().user = this.transform.parent.parent.gameObject;
        }
        
    }

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
