using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeOptionButtons : MonoBehaviour {

    public Canvas canvas;
	public Button targetBtn;
	
	public int numOfOptions;
	public Button optionABtn;
	public Button optionBBtn;
	public Button optionCBtn;
	public Button optionDBtn;
	public Button optionEBtn;
	public Button optionFBtn;
	public Button optionGBtn;
	
	// Use this for initialization
	void Start () 
	{
			canvas=this.GetComponent<Canvas>();
			
			switch(numOfOptions)
			{
				case 0:
					break;
				case 1:
                optionABtn.onClick.AddListener(OptionA);
					break;
				case 2:
                optionABtn.onClick.AddListener(OptionA);
                optionBBtn.onClick.AddListener(OptionB);
					break;
				case 3:
                optionABtn.onClick.AddListener(OptionA);
                optionBBtn.onClick.AddListener(OptionB);
                optionCBtn.onClick.AddListener(OptionC);
					break;
				case 4:
                optionABtn.onClick.AddListener(OptionA);
                optionBBtn.onClick.AddListener(OptionB);
                optionCBtn.onClick.AddListener(OptionC);
                optionDBtn.onClick.AddListener(OptionD);
					break;
				case 5:
                optionABtn.onClick.AddListener(OptionA);
                optionBBtn.onClick.AddListener(OptionB);
                optionCBtn.onClick.AddListener(OptionC);
                optionDBtn.onClick.AddListener(OptionD);
                optionEBtn.onClick.AddListener(OptionE);
					break;
				case 6:
                optionABtn.onClick.AddListener(OptionA);
                optionBBtn.onClick.AddListener(OptionB);
                optionCBtn.onClick.AddListener(OptionC);
                optionDBtn.onClick.AddListener(OptionD);
                optionEBtn.onClick.AddListener(OptionE);
                optionFBtn.onClick.AddListener(OptionF);
					break;
				case 7:
                optionABtn.onClick.AddListener(OptionA);
                optionBBtn.onClick.AddListener(OptionB);
                optionCBtn.onClick.AddListener(OptionC);
                optionDBtn.onClick.AddListener(OptionD);
                optionEBtn.onClick.AddListener(OptionE);
                optionFBtn.onClick.AddListener(OptionF);
                optionGBtn.onClick.AddListener(OptionG);
					break;
				default:
					Debug.Log("Exceeded max number of options!");
					break;
			}
	}

    public void ActivateCanvas() {
        canvas.enabled = true;
    }
	public void DeactivateCanvas() {
		canvas.enabled =false;
	}
	
	void OptionA() {
		targetBtn.GetComponentInChildren<Text>().text = optionABtn.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}
	void OptionB() {
        targetBtn.GetComponentInChildren<Text>().text = optionBBtn.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}

	void OptionC() {
        targetBtn.GetComponentInChildren<Text>().text = optionCBtn.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}

	void OptionD() {
        targetBtn.GetComponentInChildren<Text>().text = optionDBtn.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}

	void OptionE() {
        targetBtn.GetComponentInChildren<Text>().text = optionEBtn.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}

	void OptionF() {
        targetBtn.GetComponentInChildren<Text>().text = optionFBtn.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}

	void OptionG() {
        targetBtn.GetComponentInChildren<Text>().text = optionGBtn.GetComponentInChildren<Text>().text;
		DeactivateCanvas();
	}
}