using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGame : MonoBehaviour {

    public void OnButtonPress() {
        GameMaster.Instance.Load();
        GameMaster.Instance.ChangeState(4);
    }
}
