﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
public class ResumeTabNav : MonoBehaviour
{
    EventSystem system;
	public List<UnityEngine.UI.InputField> fields = new List<UnityEngine.UI.InputField>();
	public int index = 500; //start index at something higher than list count so the first tab will jump to the first field
	public GameObject textObject;
	
    void Start()
    {
        //system = EventSystem.current;// EventSystemManager.currentSystem;
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
			if((index>=fields.Count) || (index == ((fields.Count)-1)))
			{
				index=0;
			}
			else 
			{
				index=index+1;
			}
			
			fields[index].ActivateInputField();
        }
		
		if (fields[0].isFocused == true)
		{
			textObject.transform.position= new Vector3(0,200,0);
		}
		if (fields[4].isFocused == true)
		{
			textObject.transform.position= new Vector3(0,850,0);
		}
		if (fields[7].isFocused == true)
		{
			textObject.transform.position= new Vector3(0,1400,0);
		}
    }
}
