using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {


    public void OnButtonPress()
    {
        GameMaster.Instance.Load();
        GameMaster.Instance.ChangeState(2);
    }
}
