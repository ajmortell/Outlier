using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeOptionButtons : MonoBehaviour {
	public UnityEngine.Canvas canvas;
	public UnityEngine.UI.Button targetBTN;
	public UnityEngine.UI.Button BTNoption1;
	public UnityEngine.UI.Button BTNoption2;
	public UnityEngine.UI.Button BTNoption3;
	
	// Use this for initialization
	void Start () 
	{
			canvas=this.GetComponent<Canvas>();
			
			BTNoption1.onClick.AddListener(op1);
			BTNoption2.onClick.AddListener(op2);
			BTNoption3.onClick.AddListener(op3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ActivateCanvas()
	{
		canvas.enabled =true;
	}
	public void DeactivateCanvas()
	{
		canvas.enabled =false;
	}
	
	void op1()
	{
		targetBTN.GetComponentInChildren<Text>().text = BTNoption1.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}
	void op2()
	{
		targetBTN.GetComponentInChildren<Text>().text = BTNoption2.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}
	void op3()
	{
		targetBTN.GetComponentInChildren<Text>().text = BTNoption3.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}
}