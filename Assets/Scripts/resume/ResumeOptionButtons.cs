using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeOptionButtons : MonoBehaviour {
	public UnityEngine.Canvas canvas;
	public UnityEngine.UI.Button targetBTN;
	
	public int numOfOptions;
	public UnityEngine.UI.Button BTNoption1;
	public UnityEngine.UI.Button BTNoption2;
	public UnityEngine.UI.Button BTNoption3;
	public UnityEngine.UI.Button BTNoption4;
	public UnityEngine.UI.Button BTNoption5;
	public UnityEngine.UI.Button BTNoption6;
	public UnityEngine.UI.Button BTNoption7;
	
	// Use this for initialization
	void Start () 
	{
			canvas=this.GetComponent<Canvas>();
			
			switch(numOfOptions)
			{
				case 0:
					break;
				case 1:
					BTNoption1.onClick.AddListener(op1);
					break;
				case 2:
					BTNoption1.onClick.AddListener(op1);
					BTNoption2.onClick.AddListener(op2);
					break;
				case 3:
					BTNoption1.onClick.AddListener(op1);
					BTNoption2.onClick.AddListener(op2);
					BTNoption3.onClick.AddListener(op3);
					break;
				case 4:
					BTNoption1.onClick.AddListener(op1);
					BTNoption2.onClick.AddListener(op2);
					BTNoption3.onClick.AddListener(op3);
					BTNoption4.onClick.AddListener(op4);
					break;
				case 5:
					BTNoption1.onClick.AddListener(op1);
					BTNoption2.onClick.AddListener(op2);
					BTNoption3.onClick.AddListener(op3);
					BTNoption4.onClick.AddListener(op4);
					BTNoption5.onClick.AddListener(op5);
					break;
				case 6:
					BTNoption1.onClick.AddListener(op1);
					BTNoption2.onClick.AddListener(op2);
					BTNoption3.onClick.AddListener(op3);
					BTNoption4.onClick.AddListener(op4);
					BTNoption5.onClick.AddListener(op5);
					BTNoption6.onClick.AddListener(op6);
					break;
				case 7:
					BTNoption1.onClick.AddListener(op1);
					BTNoption2.onClick.AddListener(op2);
					BTNoption3.onClick.AddListener(op3);
					BTNoption4.onClick.AddListener(op4);
					BTNoption5.onClick.AddListener(op5);
					BTNoption6.onClick.AddListener(op6);
					BTNoption7.onClick.AddListener(op7);
					break;
				default:
					Debug.Log("Exceeded max number of options!");
					break;
			}
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
	void op4()
	{
		targetBTN.GetComponentInChildren<Text>().text = BTNoption4.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}
	void op5()
	{
		targetBTN.GetComponentInChildren<Text>().text = BTNoption5.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}
	void op6()
	{
		targetBTN.GetComponentInChildren<Text>().text = BTNoption6.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}
	void op7()
	{
		targetBTN.GetComponentInChildren<Text>().text = BTNoption7.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}
}