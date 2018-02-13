using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuitGame : MonoBehaviour
{

    public void OnButtonPress()
    {
        UnityAction YesBtnAction = new UnityAction(OnYes);
        UnityAction NoBtnAction = new UnityAction(OnNo);
        ModalPanel.Instance.CreatePanel(YesBtnAction, NoBtnAction,
            new Vector2(900, 760), new Vector2(100, 100), Color.white,
            Color.black, "Are you sure you want to quit? All unsaved data will be lost.", 1, 1, 1);
    }

    void OnYes() {
        Debug.Log("QUITTING GAME");
        GameMaster.Instance.QuitGame();
        ModalPanel.Instance.Refresh();
    }

    void OnNo() {
        Debug.Log("NO BTN PRESSED");
        ModalPanel.Instance.Refresh();
    }
}
