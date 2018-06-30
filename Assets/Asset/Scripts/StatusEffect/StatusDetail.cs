using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDetail : MonoBehaviour {

    public bool isActive;
    public bool effect = false;
    public GameObject user;
    public string type;

    private void Awake()
    {
        user = this.transform.parent.gameObject;
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

    public virtual void RemoveStatus()
    {
        
    }
}
