﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using DialogueTree;

public class CherrylDialogue : MonoBehaviour {

    // NPC
    private GameObject npc;
    private string npcName;
    private int branchID;
    private int selected_npc = -2;
    // Dialogue
    private GameObject node_text;
    private GameObject option_1;
    private GameObject option_2;
    private GameObject option_3;
    private GameObject exit;

    private int selected_option = -2;
    private int dialogueDestinationNode = 0;
    private GameObject dialoguePanel;
    public GameObject DialoguePanelPrefab;
    // Data
    private CherrylDialogueTree dialogue_tree;
    public string DialogueDataFilePath;
    public const string path = "Assets/Resources/XML/Dialogues/NPC/cherrylDialogueTree.xml";

    void Start() {

        dialogue_tree = CherrylDialogueTree.LoadDialogue(path);// loads XML
        GameObject canvas = GameObject.Find("MainCanvas"); // gets the main canvas reference        
        dialoguePanel = Instantiate<GameObject>(DialoguePanelPrefab);// instantiates the panel
        dialoguePanel.transform.SetParent(canvas.transform);// sets the panel to the main canvas. bringToFront used on panel
        RectTransform dialoguePanelTransform = (RectTransform)dialoguePanel.transform;
        node_text = GameObject.Find("DialogueText"); // this is the NPC talking
        option_1 = GameObject.Find("dialougueOptionA");// these are player options + exit
        option_2 = GameObject.Find("dialougueOptionB");
        option_3 = GameObject.Find("dialougueOptionC");
        npc = gameObject;// this script is attached to an NPC
        npcName = npc.name;
        branchID = 0;
        dialoguePanel.SetActive(false);
        RunDialogue();// THIS IS ONLY HERE FOR TEST IT IS WHAT INITIATES THE DIALOGUE. CAN BE CALLED FROM CLASS OBJECT ELSEWHERE
    }

    public void RunDialogue() {
        StartCoroutine(InitiateBranchNode(dialogue_tree.CherrylBranchNodes[branchID]));
    }

    //public int RetrieveBranchID()
    //{
        
    //    return
    //}

    private IEnumerator InitiateBranchNode(CherrylBranchNode node) {
     
        dialoguePanel.SetActive(true);
        int node_id = 0;

        while (node_id != -1) { //
            Display_Node(node.DialogueNodes[node_id]);
            selected_option = -2;
           
            while (selected_option == -2) { //      
                yield return new WaitForSeconds(0.25f);
            }//
            node_id = selected_option;
        }

        dialoguePanel.SetActive(false);
        UnSelectedNPC();
    }

    private void UnSelectedNPC() {
        Debug.Log("SELECTED NPC: "+ selected_npc);
        selected_npc = -1;
    }

    private void Display_Node(DialogueNode node) {

        
        node_text.GetComponent<Text>().text = node.DialogueText;
        string newString = node_text.GetComponent<Text>().text.Replace("[NPC_NAME]", npcName).Replace("[PLAYER_FIRSTNAME]", GameMaster.Instance._firstName).Replace("[PLAYER_LASTNAME]", GameMaster.Instance._lastName).Replace("[UNIVERSITY_NAME]", GameMaster.Instance._universityName);
        node_text.GetComponent<Text>().text = newString;

        option_1.SetActive(false);
        option_2.SetActive(false);
        option_3.SetActive(false);
        
        for (int i = 0; i < node.Options.Count || i < 1; i++) {
            switch (i) {
                case 0:
                    Set_Option_Button(option_1, node.Options[i]);
                    break;
                case 1:
                    Set_Option_Button(option_2, node.Options[i]);
                    break;
                case 2:
                    Set_Option_Button(option_3, node.Options[i]);
                    break;
            }
        }
    }

    private void Set_Option_Button(GameObject button, DialogueOption option) {
        button.SetActive(true);// sets sent btn ON
        button.GetComponentInChildren<Text>().text = option.OptionText;// fills text with xml option txt
        string newString = button.GetComponentInChildren<Text>().text.Replace("[NPC_NAME]", npcName).Replace("[PLAYER_FIRSTNAME]", GameMaster.Instance._firstName).Replace("[PLAYER_LASTNAME]", GameMaster.Instance._lastName).Replace("[UNIVERSITY_NAME]", GameMaster.Instance._universityName);
        button.GetComponentInChildren<Text>().text = newString;

        button.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(option.DestinationNodeID); });
        print("OPTION Destination Node: " + option.DestinationNodeID);
    }

    private void SetSelectedOption(int x) {
        selected_option = x;
    }
}