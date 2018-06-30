using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : RealTimeStatusEffect
{
    float tick = 0;
    private void Awake()
    {
        isActive = true;
        floatDuration = 30;
        type = "Bad";
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
        }
        if (isActive)
        {
            floatDuration -= Time.deltaTime;
            tick += Time.deltaTime;
        }
        if (tick >= 2)
        {
            float Dmg = user.GetComponent<PlayerStats>().health * 0.01f;
            user.GetComponent<PlayerStats>().health -= (int)Dmg;
            tick = 0;
        }
        
    }
    public override void RemoveStatus()
    {
        
    }
}

