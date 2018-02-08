using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// text allows 200 characters safely

public class ModalPanel : Singleton<ModalPanel> {

    private UnityAction YesBtnAction;
    private UnityAction NoBtnAction;
    private UnityAction SaveBtnAction;
    private UnityAction CancelBtnAction;
    private UnityAction OKBtnAction;
    private UnityAction NextBtnAction;
    private UnityAction SkipBtnAction;

    private Camera cam;

    public GameObject modalPanel;
    public GameObject backgroundObject;
    public Button modalBtn_A;
    public Button modalBtn_B;
    public Image modalImage;
    public Text questionText;
    public Text infoText;
    public Text dialogueText;

    private RectTransform panelRect;
    private Canvas currentCanvas;

    public void Refresh() {
        modalPanel.SetActive(false);
        modalBtn_A.gameObject.SetActive(false);
        modalBtn_B.gameObject.SetActive(false);
        questionText.gameObject.SetActive(false);
        infoText.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        if (modalImage != null) {
            modalImage.gameObject.SetActive(false);
        }
    }

    public override void Awake() {
        base.Awake();
        Refresh();
        currentCanvas = GetComponent<Canvas>();
        cam = Camera.main;
    }

    public void CreatePanel(UnityAction btn_action_A, UnityAction btn_action_B, Vector2 size, Vector2 pos, Color bg_stroke, Color bg_color, Image img, string txt, int layout_config, int text_config, int button_A_config, int button_B_config) {

        modalPanel.transform.SetParent(currentCanvas.transform, false);//1/ Set to Canvas      
        panelRect = (RectTransform)modalPanel.transform;//2/ Get Panel Rect and Panel Rect Size
        panelRect.sizeDelta = size;
        modalPanel.transform.localPosition = pos;//3/ Set Panel Position      
        modalPanel.GetComponent<Image>().color = bg_stroke;//4/ Set Panel Outline and Background
        backgroundObject.GetComponent<Image>().color = bg_color;
        modalImage = img;//5/ Set Image         
        ConfigureLayoutType(layout_config);//6/ Set Button Layout Type        
        ConfigureTextType(text_config, txt);//7/ Set Text Layout     
        ConfigureButtonAType(button_A_config, btn_action_A);//8/ Configure the name type of the button --
        ConfigureButtonBType(button_B_config, btn_action_B);
        modalPanel.transform.SetAsLastSibling();
        modalPanel.SetActive(true);
    }

    /// <summary>
    /// Used to set the Button Layout Configuration Type
    /// </summary>
    /// <param name="config"></param>
    private void ConfigureLayoutType(int config)
    {
        modalBtn_A.gameObject.SetActive(false);
        modalBtn_B.gameObject.SetActive(false);
        switch (config)
        {
            case 1: /*DOUBLE*/
                modalBtn_A.gameObject.SetActive(true);
                modalBtn_B.gameObject.SetActive(true);
                break;
            case 2: /*SINGLE*/
                modalBtn_B.gameObject.SetActive(true);
                break;
            case 3: /*CENTER*/
                modalBtn_A.gameObject.SetActive(true);
                break;
        }
    }

    /// <summary>
    /// Used to set the Text Option Configuration Type
    /// </summary>
    /// <param name="config"></param>
    private void ConfigureTextType(int config, string txt)
    {
        questionText.gameObject.SetActive(false);
        infoText.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
        switch (config)
        {
            case 1: /*QUESTION*/
                questionText.gameObject.SetActive(true);
                questionText.text = txt;
                break;
            case 2: /*INFO*/
                infoText.gameObject.SetActive(true);
                infoText.text = txt;
                break;
            case 3: /*DIALOGUE*/
                dialogueText.gameObject.SetActive(true);
                dialogueText.text = txt;
                break;
        }
    }

    /// <summary>
    /// Used to set the Button A Type and Unity Action
    /// </summary>
    /// <param name="config"></param>
    private void ConfigureButtonAType(int config, UnityAction action)
    {
        switch (config)
        {

            case 1:
                YesBtnAction = new UnityAction(action);
                Yes(YesBtnAction, "YES");
                break;
            case 2:
                SaveBtnAction = new UnityAction(action);
                Save(SaveBtnAction, "SAVE");
                break;
            case 3:
                OKBtnAction = new UnityAction(action);
                OK(OKBtnAction, "OK");
                break;
        }
    }

    /// <summary>
    /// Used to set the Button B Type and Unity Action
    /// </summary>
    /// <param name="config"></param>
    private void ConfigureButtonBType(int config, UnityAction action)
    {
        switch (config)
        {

            case 1:
                NoBtnAction = new UnityAction(action);
                No(NoBtnAction, "NO");
                break;
            case 2:
                CancelBtnAction = new UnityAction(action);
                Cancel(CancelBtnAction, "CANCEL");
                break;
            case 3:
                NextBtnAction = new UnityAction(action);
                Next(NextBtnAction, "NEXT");
                break;
            case 4:
                SkipBtnAction = new UnityAction(action);
                Skip(SkipBtnAction, "SKIP");
                break;
        }
    }

    // STATES
    private void Yes(UnityAction YesBtnAction, string btn_txt)
    {
        modalBtn_A.onClick.RemoveAllListeners();
        modalBtn_A.onClick.AddListener(YesBtnAction);
        modalBtn_A.GetComponentInChildren<Text>().text = btn_txt;
    }
    private void No(UnityAction NoBtnAction, string btn_txt)
    {
        modalBtn_B.onClick.RemoveAllListeners();
        modalBtn_B.onClick.AddListener(NoBtnAction);
        modalBtn_B.GetComponentInChildren<Text>().text = btn_txt;
    }
    private void Save(UnityAction SaveBtnAction, string btn_txt)
    {
        modalBtn_A.onClick.RemoveAllListeners();
        modalBtn_A.onClick.AddListener(SaveBtnAction);
        modalBtn_A.GetComponentInChildren<Text>().text = btn_txt;
    }
    private void Cancel(UnityAction CancelBtnAction, string btn_txt)
    {
        modalBtn_B.onClick.RemoveAllListeners();
        modalBtn_B.onClick.AddListener(CancelBtnAction);
        modalBtn_B.GetComponentInChildren<Text>().text = btn_txt;
    }
    private void OK(UnityAction OKBtnAction, string btn_txt)
    {
        modalBtn_A.onClick.RemoveAllListeners();
        modalBtn_A.onClick.AddListener(OKBtnAction);
        modalBtn_A.GetComponentInChildren<Text>().text = btn_txt;
    }
    private void Next(UnityAction NextBtnAction, string btn_txt)
    {
        modalBtn_B.onClick.RemoveAllListeners();
        modalBtn_B.onClick.AddListener(NextBtnAction);
        modalBtn_B.GetComponentInChildren<Text>().text = btn_txt;
    }
    private void Skip(UnityAction SkipBtnAction, string btn_txt)
    {
        modalBtn_B.onClick.RemoveAllListeners();
        modalBtn_B.onClick.AddListener(SkipBtnAction);
        modalBtn_B.GetComponentInChildren<Text>().text = btn_txt;
    }

    // BUTTON ACTIONS
    void OnYesBtn()
    {
        Debug.Log("YES BUTTON PRESSED");
        Refresh();
    }
    void OnNoBtn()
    {
        Debug.Log("NO BUTTON PRESSED");
        Refresh();
    }
    void OnSaveBtn()
    {
        Debug.Log("SAVE BUTTON PRESSED");
        GameMaster.Instance.Save();
        Refresh();
    }
    void OnCancelBtn()
    {
        Debug.Log("CANCEL BUTTON PRESSED");
        Refresh();
    }
    void OnOkBtn()
    {
        Debug.Log("OK BUTTON PRESSED");
        Refresh();
    }
    void OnNextBtn()
    {
        Debug.Log("NEXT BUTTON PRESSED");
    }
    void OnSkipBtn()
    {
        Debug.Log("SKIP BUTTON PRESSED");
    }
}
