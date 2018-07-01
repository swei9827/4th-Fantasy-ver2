using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritDown : ActionCounterStatusEffect
{
    public void Awake()
    {
        isActive = true;
        intDuration = 5;
        type = "Bad";
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void DoEffect()
    {
        if (intDuration <= 0)
        {
            isActive = false;
            RemoveStatus();
        }
        if (!effect)
        {
            user.GetComponent<PlayerStats>().spirit -= (int)(user.GetComponent<PlayerStats>().baseSpirit * 0.3f);
            effect = true;
        }
        intDuration--;


    }
    public override void RemoveStatus()
    {
        user.GetComponent<PlayerStats>().spirit += (int)(user.GetComponent<PlayerStats>().baseSpirit * 0.3f);
        effect = false;
    }
}
