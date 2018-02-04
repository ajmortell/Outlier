using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController> 
{
	public string playerName;
	public string contactPhone;
	public string contactEmail;
	public string eduLevel;
	public string eduName;
	public string eduStudy;
	public string work1Name;
	public string work2Name;
	public string work3Name;
	public string work1Pos;
	public string work2Pos;
	public string work3Pos;
	
	public void resumeUpdate (string pname, string phone, string email,string eduLevel, string eduN,string eduStudy, string w1n, string w2n, string w3n,string w1p,string w2p,string w3p)
	{
		updatePlayerName(pname);
		updatePhoneName(phone);
		updateEmailName(email);
		updateEduLevel(eduLevel);
		updateEduName(eduN);
		updateEduStudy(eduStudy);
		updateWorkName1(w1n);
		updateWorkName2(w2n);
		updateWorkName3(w3n);
		updateWorkPos1(w1p);
		updateWorkPos2(w2p);
		updateWorkPos3(w3p);
		
	}
	
	//setters for chaning vars
	void updatePlayerName(string newName)
	{
		playerName = newName;
	}
	void updatePhoneName(string newName)
	{
		contactEmail=newName;
	}
	void updateEmailName(string newName)
	{
		contactPhone=newName;
	}
	void updateEduLevel(string newName)
	{
		eduLevel=newName;
	}
	void updateEduName(string newName)
	{
		eduName=newName;
	}
	void updateEduStudy(string newName)
	{
		eduStudy=newName;
	}
	void updateWorkName1(string newName)
	{
		work1Name=newName;
	}
	void updateWorkName2(string newName)
	{
		work2Name=newName;
	}
	void updateWorkName3(string newName)
	{
		work3Name=newName;
	}
	void updateWorkPos1(string newName)
	{
		work1Pos=newName;
	}
	void updateWorkPos2(string newName)
	{
		work2Pos=newName;
	}
	void updateWorkPos3(string newName)
	{
		work3Pos=newName;
	}
	
	
	void OnGUI()
    {

        //GUI.Label(new Rect(320, 10, 150, 30), "Playername: " + PlayerData.PlayerName);
        //GUI.Label(new Rect(100, 10, 150, 30), "FX Vol: " + SoundManager.Instance._fxSource.volume);
    }
}
