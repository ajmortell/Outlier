using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class GameMaster : Singleton<GameMaster> {

    // GAME DATA
    public string _firstName;
    public string _lastName;
    public string _phone;
    public string _email;
    public string _eduLevel;
    public string _highschoolName;
    public string _universityName;
    public string _eduStudy;
    public string _companyAName;
    public string _companyBName;
    public string _companyCName;
    public string _jobTitleA;
    public string _jobTitleB;
    public string _jobTitleC;
    public string _awardA;
    public string _awardB;
    public string _awardC;

    //private SoundContainer sound;
    private enum GameState { NONE = 0, STARTUP = 1, SPLASH = 2, CUT = 3, COMPUTER = 4, MEETING = 5, FAIL = 6, QUIT = 7 };
    private GameState gameState;
    private GameState currentGameState;

    public override void Awake() {
        base.Awake();
        //sound = GetComponent<SoundContainer>();
        gameState = GameState.NONE;
        currentGameState = gameState;
        StartUp();
    }

    // STATE METHODS //////////////////////////////////////////////////////////

    private void StartUp() {
        gameState = GameState.STARTUP;
        StartCoroutine(Splash());
    }

    IEnumerator Splash()
    {
        yield return new WaitForSeconds(1.5f);

        yield return new WaitForSeconds(1.5f);
        gameState = GameState.SPLASH;
        StartCoroutine(TransitionScene(1));
        //SoundManager.Instance.PlayMusic(sound.SplashClip_A);
    }

    private void Cut()
    {
        StartCoroutine(TransitionScene(2));
    }

    private void Computer()
    {
        StartCoroutine(TransitionScene(3));
        //SoundManager.Instance.PlayMusic(sound.SplashClip_A);
    }

    private void Meeting() {
        StartCoroutine(TransitionScene(4));
        //SoundManager.Instance.PlayMusic(sound.SplashClip_A);
    }

    private void Fail()
    {
        StartCoroutine(TransitionScene(5));
        //SoundManager.Instance.PlayMusic(sound.SplashClip_A);
    }

    private void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    /////////////////////////////////////////////////////////////////////////

    IEnumerator TransitionScene(int scene)
    {
        //float fadeTime = GetComponent<SceneFading>().BeginFade(1);
        //yield return new WaitForSeconds(fadeTime);
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(scene);
    }

    private void GameStateChanged() {
        switch (gameState) {
            case GameState.STARTUP:
                break;
            case GameState.SPLASH:
                break;
            case GameState.CUT:
                Cut();
                break;
            case GameState.COMPUTER:
                Computer();
                break;
            case GameState.MEETING:
                Meeting();
                break;
            case GameState.FAIL:
                Fail();
                break;
            case GameState.QUIT:
                Quit();
                break;
        }
    }

    public void ChangeState(int state)
    {
        switch (state)
        {
            case 0:
                gameState = GameState.STARTUP;
                break;
            case 1:
                gameState = GameState.SPLASH;
                break;
            case 2:
                gameState = GameState.CUT;
                break;
            case 3:
                gameState = GameState.COMPUTER;
                break;
            case 4:
                gameState = GameState.MEETING;
                break;
            case 5:
                gameState = GameState.FAIL;
                break;
            case 6:
                gameState = GameState.QUIT;
                break;
        }
    }

    private void CheckState()
    {
        if (currentGameState != gameState)
        {
            currentGameState = gameState;
            GameStateChanged();
        }
    }

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();

        data.FirstName = _firstName;
        data.LastName = _lastName;
        data.Phone = _phone;
        data.Email = _email;
        data.EduLevel = _eduLevel;
        data.HighschoolName = _highschoolName;
        data.UniversityName = _universityName;
        data.CompanyAName = _companyAName;
        data.CompanyBName = _companyBName;
        data.CompanyCName = _companyCName;
        data.JobTitleA = _jobTitleA;
        data.JobTitleB = _jobTitleB;
        data.JobTitleC = _jobTitleC;
        data.AwardA = _awardA;
        data.AwardB = _awardB;
        data.AwardC = _awardC;

        formatter.Serialize(file, data);
        file.Close();
    }

    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerData data = (PlayerData)formatter.Deserialize(file);
            file.Close();

            _firstName = data.FirstName;
            _lastName = data.LastName;
            _phone = data.Phone;
            _email = data.Email;
            _eduLevel = data.EduLevel;
            _highschoolName = data.HighschoolName;
            _universityName = data.UniversityName;
            _companyAName = data.CompanyAName;
            _companyBName = data.CompanyBName;
            _companyCName = data.CompanyCName;
            _jobTitleA = data.JobTitleA;
            _jobTitleB = data.JobTitleB;
            _jobTitleC = data.JobTitleC;
            _awardA = data.AwardA;
            _awardB = data.AwardB;
            _awardC = data.AwardC;
        }
    }

    public void ResumeUpdate
    (
    string firstName,
    string lastName,
    string profile,
    string phone,
    string email,
    string level,
    string higschool,
    string university,
    string study,
    string companyA,
    string companyB,
    string companyC,
    string jobA,
    string jobB,
    string jobC
    )
    {
        Debug.Log("RESUME DATA UPDATING...." + " :: NAME: "+firstName);
        _firstName = firstName;
        _lastName = lastName;
        _phone = phone;
        _email = email;
        _eduLevel = level;
        _highschoolName = higschool;
        _universityName = university;
        _companyAName = firstName;
        _companyBName = firstName;
        _companyCName = firstName;
        _jobTitleA = firstName;
        _jobTitleB = firstName;
        _jobTitleC = firstName;
        _awardA = firstName;
        _awardB = firstName;
        _awardC = firstName;
    }

    public void QuitGame() {
        gameState = GameState.QUIT;
    }

    public void CloseResume() {
        gameState = GameState.MEETING;
        Save();
    }

    void OnGUI() {
        GUI.Label(new Rect(320, 10, 150, 30), "Name: " + _firstName+" "+_lastName);
        GUI.Label(new Rect(100, 10, 150, 30), "University: " + _universityName);
    }

    void Update() {
        CheckState();
    }

}