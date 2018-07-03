using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillEffect : MonoBehaviour {

    public List<GameObject> playerList;
    public List<GameObject> enemyList;
    public List<GameObject> status;
    public GameObject user;
    public string effectDescription;
    public SKILL_EFFECT_TYPE effectType;
    public int damage;
    public GameObject PopUpPrefab;
    public int numOfTarget;
    public enum SKILL_EFFECT_TYPE
    {
        OFFENSIVE = 0,
        SUPPORTIVE,
        DEBUFF,
        HEAL
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Execute(GameObject targetedEnemy)
    {

    }

    protected void Assign()
    {
        playerList = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().playerList;
        enemyList = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager>().enemyList;
        user = transform.parent.parent.parent.gameObject;
    }

    public void PopUpDamage(GameObject target, int damage)
    {
        GameObject newPopUp = Instantiate(PopUpPrefab, target.transform.position, Quaternion.identity);
        newPopUp.SetActive(true);
        newPopUp.GetComponent<PopUpDamageController>().SetText(damage.ToString());
        Destroy(newPopUp.gameObject, 1f);
    }
}
