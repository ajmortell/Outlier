using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject FilePanel;
    public GameObject PlayerPanel;
    public GameObject OptionsPanel;

    public Button FileBtn;
    public Button PlayerBtn;
    public Button OptionsBtn;

    public void ResetPanels(params GameObject[] panels) {
        foreach (GameObject panel in panels) {
            panel.SetActive(false);
        }
    }

    void Start() {
        ResetPanels(FilePanel, PlayerPanel, OptionsPanel);
    }

    public void FileButtonPress() {
        ResetPanels(FilePanel, PlayerPanel, OptionsPanel);
        FilePanel.SetActive(true);
    }

    public void PlayerButtonPress() {
        ResetPanels(FilePanel, PlayerPanel, OptionsPanel);
        PlayerPanel.SetActive(true);
    }

    public void OptionsButtonPress() {
        ResetPanels(FilePanel, PlayerPanel, OptionsPanel);
        OptionsPanel.SetActive(true);
    }

}
