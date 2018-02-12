using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Resume : MonoBehaviour 
{
	//declare holder for playercontroller when we grab it
	public PlayerController playercontroller;
	
	//Links to input fields on resume screen
	public InputField IFplayerFirst;
	public InputField IFplayerLast;
	public UnityEngine.UI.Button BTNprofile;
	public InputField IFphone;
	public InputField IFemail;
	public UnityEngine.UI.Button BTNeduLevel;
	public InputField IFeduHName;
	public InputField IFeduUName;
	public UnityEngine.UI.Button BTNeduStudy;
	public InputField IFwrkName1;
	public InputField IFwrkName2;
	public InputField IFwrkName3;
	public UnityEngine.UI.Button BTNwrkPos1;
	public UnityEngine.UI.Button BTNwrkPos2;
	public UnityEngine.UI.Button BTNwrkPos3;
	
	//placeholder vars
	//store data from fields in these
	//then use these to pass info to playercontroller
	string playerFirst;
	string playerLast;
	string profile;
	string phone;
	string email;
	string eduLevel;
	string eduStudy;
	string eduHName;
	string eduUName;
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
		playerFirst = IFplayerFirst.text;
		playerLast = IFplayerLast.text;
		profile = BTNprofile.GetComponentInChildren<Text>().text;
		phone = IFphone.text;
		email = IFemail.text;
		eduLevel= BTNeduLevel.GetComponentInChildren<Text>().text;
		eduHName = IFeduHName.text;
		eduUName = IFeduUName.text;
		eduStudy = BTNeduStudy.GetComponentInChildren<Text>().text;
		wrkName1 = IFwrkName1.text;
		wrkName2 = IFwrkName2.text;
		wrkName3 = IFwrkName3.text;
		wrkPos1 = BTNwrkPos1.GetComponentInChildren<Text>().text;
		wrkPos2 = BTNwrkPos2.GetComponentInChildren<Text>().text;
		wrkPos3 = BTNwrkPos3.GetComponentInChildren<Text>().text;
		
		//pass the data to the playercontroller
		playercontroller.resumeUpdate
		(
		playerFirst,
		playerLast,
		profile,
		phone,
		email,
		eduLevel,
		eduHName,
		eduUName,
		eduStudy,
		wrkName1,
		wrkName2,
		wrkName3,
		wrkPos1,
		wrkPos2,
		wrkPos3
		);
		
		//exitScene();
	}
	
	void exitScene()
	{
		 SceneManager.LoadScene("InterviewScene", LoadSceneMode.Single);
	}
}
