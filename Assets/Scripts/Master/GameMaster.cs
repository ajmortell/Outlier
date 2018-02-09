using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class GameMaster : Singleton<GameMaster> {

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

    private void StartUp()
    {
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
        //BinaryFormatter formatter = new BinaryFormatter();
        //FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        //PlayerData data = new PlayerData();
        //data.Health = hp;
        //data.Experience = xp;
        //data.Level = lvl;
        //data.UserName = user;
        //data.UID = uid;

        //formatter.Serialize(file, data);
        //file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            //BinaryFormatter formatter = new BinaryFormatter();
            //FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            //PlayerData data = (PlayerData)formatter.Deserialize(file);
            //file.Close();
            //hp = data.Health;
            //xp = data.Experience;
            //lvl = data.Level;
            //user = data.UserName;
            //uid = data.UID;
        }
    }

    public void QuitGame() {
        gameState = GameState.QUIT;
    }

    public void CloseResume() {
        gameState = GameState.MEETING;
    }


    void OnGUI() {
        //GUI.Label(new Rect(320, 10, 150, 30), "Name: " + SoundManager.Instance._musicSource.volume);
        //GUI.Label(new Rect(100, 10, 150, 30), "FX Vol: " + SoundManager.Instance._fxSource.volume);
    }

    void Update() {
        CheckState();
    }

}