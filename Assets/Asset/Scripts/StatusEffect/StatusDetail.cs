using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDetail : MonoBehaviour {

    public DURATION_TYPE durationType;
    public int intDuration;
    public float floatDuration;
    bool isActive;

    public enum DURATION_TYPE
    {
        REAL_TIME = 0,
        ACTION_COUNTER
    }
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void DoEffect()
    {

    }

    public void RemoveStatus()
    {
        //! check duration
        //! pop
        //! set stats to normal
    }
}
