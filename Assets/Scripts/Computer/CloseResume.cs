using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CloseResume : MonoBehaviour {

    public void OnButtonPress()
    {
        UnityAction YesBtnAction = new UnityAction(OnYes);
        UnityAction NoBtnAction = new UnityAction(OnNo);
        ModalPanel.Instance.CreatePanel(YesBtnAction, NoBtnAction, new Vector2(900, 760), new Vector2(100, 100), Color.white, Color.black, "Would you like to save and continue?", 1, 1, 1);
    }

    void OnYes()
    {
        Debug.Log("Entering Interview Scene");
        GameMaster.Instance.CloseResume();
        ModalPanel.Instance.Refresh();
    }

    void OnNo()
    {
        Debug.Log("Save Canceled");
        ModalPanel.Instance.Refresh();
    }
}
