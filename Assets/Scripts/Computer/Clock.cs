using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {

    string time;
    GameObject clock = null;

    // Use this for initialization
    void Awake () {
        time = DateTime.Now.ToShortTimeString();
        clock = gameObject;
        clock.GetComponent<Text>().text = time;

        //UpdateClock();
	}
	
    public void UpdateClock()
    {
        
        
        
    }

	// Update is called once per frame
	void Update () {
		
	}
}
