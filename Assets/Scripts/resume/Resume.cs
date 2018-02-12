using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Resume : MonoBehaviour {
    //Links to input fields on resume screen
    public InputField firstNameField;
    public InputField lastNameField;
    public Button profileBtn;
    public InputField phoneField;
    public InputField emailField;
    public Button eduLevelBtn;
    public InputField highschoolNameField;
    public InputField universityNameField;
    public Button eduStudyBtn;
    public InputField companyANameField;
    public InputField companyBNameField;
    public InputField companyCNameField;
    public Button jobTitleABtn;
    public Button jobTitleBBtn;
    public Button jobTitleCBtn;
    public Button awardABtn;
    public Button awardBBtn;
    public Button awardCBtn;

    string firstName;
    string lastName;
    string profile;
    string phone;
    string email;
    string eduLevel;
    string eduStudy;
    string highschoolName;
    string universityName;
    string companyAName;
    string companyBName;
    string companyCName;
    string jobTitleA;
    string jobTitleB;
    string jobTitleC;
    string awardA;
    string awardB;
    string awardC;

    public void UpdatePlayerData() {
        //load all the data from the fields into their placeholders
        firstName = firstNameField.text;
        lastName = lastNameField.text;
        profile = profileBtn.GetComponentInChildren<Text>().text;
        phone = phoneField.text;
        email = emailField.text;
        eduLevel = eduLevelBtn.GetComponentInChildren<Text>().text;
        highschoolName = highschoolNameField.text;
        universityName = universityNameField.text;
        eduStudy = eduStudyBtn.GetComponentInChildren<Text>().text;
        companyAName = companyANameField.text;
        companyBName = companyBNameField.text;
        companyCName = companyCNameField.text;
        jobTitleA = jobTitleABtn.GetComponentInChildren<Text>().text;
        jobTitleB = jobTitleBBtn.GetComponentInChildren<Text>().text;
        jobTitleC = jobTitleCBtn.GetComponentInChildren<Text>().text;
        awardA = awardABtn.GetComponentInChildren<Text>().text;
        awardB = awardBBtn.GetComponentInChildren<Text>().text;
        awardC = awardCBtn.GetComponentInChildren<Text>().text;
        //send data to GameMaster to save.
        GameMaster.Instance.ResumeUpdate
        (
        firstName,
        lastName,
        profile,
        phone,
        email,
        eduLevel,
        highschoolName,
        universityName,
        eduStudy,
        companyAName,
        companyBName,
        companyCName,
        jobTitleA,
        jobTitleB,
        jobTitleC,
        awardA,
        awardB,
        awardC
        );
    }
}