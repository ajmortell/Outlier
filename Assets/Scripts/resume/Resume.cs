using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Resume : MonoBehaviour 
{
	//declare holder for playercontroller when we grab it
	PlayerController playercontroller;
	
	//Links to input fields on resume screen
	public InputField IFplayerName;
	public InputField IFphone;
	public InputField IFemail;
	public UnityEngine.UI.Dropdown IFeduLevel;
	public InputField IFeduName;
	public UnityEngine.UI.Dropdown IFeduStudy;
	public InputField IFwrkName1;
	public InputField IFwrkName2;
	public InputField IFwrkName3;
	public UnityEngine.UI.Dropdown IFwrkPos1;
	public UnityEngine.UI.Dropdown IFwrkPos2;
	public UnityEngine.UI.Dropdown IFwrkPos3;
	
	//placeholder vars
	//store data from fields in these
	//then use these to pass info to playercontroller
	string playerName;
	string phone;
	string email;
	string eduLevel;
	string eduStudy;
	string eduName;
	string wrkName1;
	string wrkName2;
	string wrkName3;
	string wrkPos1;
	string wrkPos2;
	string wrkPos3;
	
	void Awake()
	{
		//grab the playercontroller ref off the gamemaster
		playercontroller=GameObject.Find("GameMaster").GetComponent<PlayerController>();
	}
	
	public void UpdatePlayerData()
	{
		//load all the data from the fields into their placeholders
		playerName = IFplayerName.text;
		phone = IFphone.text;
		email = IFemail.text;
		eduLevel= IFeduLevel.options[IFeduLevel.value].text;
		eduName = IFeduName.text;
		eduStudy = IFeduStudy.options[IFeduStudy.value].text;
		wrkName1 = IFwrkName1.text;
		wrkName2 = IFwrkName2.text;
		wrkName3 = IFwrkName3.text;
		wrkPos1 = IFwrkPos1.options[IFwrkPos1.value].text;
		wrkPos2 = IFwrkPos2.options[IFwrkPos2.value].text;
		wrkPos3 = IFwrkPos3.options[IFwrkPos3.value].text;
		//pass the data to the playercontroller
		playercontroller.resumeUpdate(playerName,phone,email,eduLevel,eduName,eduStudy,wrkName1,wrkName2,wrkName3,wrkPos1,wrkPos2,wrkPos3);
		
		exitScene();
	}
	
	void exitScene()
	{
		 SceneManager.LoadScene("InterviewScene", LoadSceneMode.Single);
	}
}
