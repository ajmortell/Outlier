using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Gets the current time and updates the in game PC Clock
/// </summary>
public class Clock : MonoBehaviour {

    string time;
    GameObject clock = null;

    void Awake () {
        time = DateTime.Now.ToShortTimeString();
        clock = gameObject;
        clock.GetComponent<Text>().text = time;
	}

	void Update () {
       time = DateTime.Now.ToShortTimeString();
       clock.GetComponent<Text>().text = time;
    }
}
