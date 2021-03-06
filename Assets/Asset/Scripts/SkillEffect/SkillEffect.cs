﻿using System.Collections;
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
}
