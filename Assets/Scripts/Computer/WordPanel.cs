using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPanel : MonoBehaviour {

    public GameObject panel = null;
    private bool canOpen = true;

    void Awake() {
        panel.SetActive(false);
    }

    public void OnBtnPress() {
        if (canOpen == true) {
            canOpen = false;
            panel.SetActive(true);
        } else {
            canOpen = true;
            panel.SetActive(false);
        }

    }
}
