using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regen : RealTimeStatusEffect
{
    float tick = 0;
    private void Awake()
    {
        isActive = true;
        floatDuration = 15;
        type = "Good";
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public override void DoEffect()
    {
        if (floatDuration <= 0)
        {
            isActive = false;
            RemoveStatus();
        }
        if (isActive)
        {
            floatDuration -= Time.deltaTime;
            tick += Time.deltaTime;
        }
        if (tick >= 2)
        {
            float reg = user.GetComponent<PlayerStats>().health * 0.05f + GameObject.Find("SceneManager").GetComponent<NeutralVariable>().regenCasterMag;
            user.GetComponent<PlayerStats>().health += (int)reg;
            tick = 0;
        }
       
    }
    public override void RemoveStatus()
    {
        
    }
}

