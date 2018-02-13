using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel = null;
    private bool canOpen = true;

    void Awake()
    {
        MainMenuPanel.SetActive(false);
    }

    /// <summary>
    /// Used for a button somewhere in the game to load the main menu
    /// </summary>
    public void OnButtonPress()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 2)
        {
            if (canOpen == true)
            {
                canOpen = false;
                MainMenuPanel.SetActive(true);
                Debug.Log("---------Main Menu Active");
            }
            else
            {
                canOpen = true;
                //SoundManager.Instance.Save();
                MainMenuPanel.SetActive(false);
                Debug.Log("---------Main Menu Closed");
            }
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 2)
        {
            if (Input.GetKeyDown("`"))
            {
                Debug.Log("PRESSED 'M' BUTTON ");
                OnButtonPress();
            }
        }
    }
}

