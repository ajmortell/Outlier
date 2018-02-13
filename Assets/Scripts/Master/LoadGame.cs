using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoadGame : MonoBehaviour {
    public void OnButtonPress() {
        UnityAction LoadBtnAction = new UnityAction(OnLoad);
        UnityAction CancelBtnAction = new UnityAction(OnCancel);
        ModalPanel.Instance.CreatePanel(LoadBtnAction, CancelBtnAction, new Vector2(900, 760), new Vector2(100, 100), Color.white, Color.black, "Load most recent save?", 1, 1, 2);
    }

    void OnLoad() {
        Debug.Log("Load BTN PRESSED");
        GameMaster.Instance.Load();
        ModalPanel.Instance.Refresh();
    }

    void OnCancel() {
        Debug.Log("Cancel BTN PRESSED");
        ModalPanel.Instance.Refresh();
    }
}
