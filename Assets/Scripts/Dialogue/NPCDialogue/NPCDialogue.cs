using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using DialogueTree;

public class NPCDialogue : MonoBehaviour
{

    // NPC
    private GameObject npc;
    private NPC npcScript;
    private string npcName;
    private int npcId;

    private GameObject avatarImgPanel;
    private Image avatarImg;
    private int selected_npc = -2;
    // Dialogue
    private GameObject node_text;
    private GameObject option_1;
    private GameObject option_2;
    private GameObject option_3;
    private GameObject exit;
    private int selected_dialogue_node = -2;
    private int selected_option = -2;
    private int dialogueDestinationNode = 0;
    private GameObject dialoguePanel;
    public GameObject DialoguePanelPrefab;
    // Data
    private Dialogue dialogue;
    public string DialogueDataFilePath;
    public const string path = "Assets/Resources/Dialogue/dialogues.xml";

    void Start()
    {
        // Dialogue
        dialogue = Dialogue.LoadDialogue(path);// loads XML
        GameObject canvas = GameObject.Find("MainCanvas"); // gets the main canvas reference        
        dialoguePanel = Instantiate<GameObject>(DialoguePanelPrefab);// instantiates the panel
        dialoguePanel.transform.SetParent(canvas.transform);// sets the panel to the main canvas. bringToFront used on panel
        RectTransform dialoguePanelTransform = (RectTransform)dialoguePanel.transform;
        dialoguePanelTransform.localPosition = new Vector3(0, 0, 0);// set all to center
        node_text = GameObject.Find("DialogueText"); // this is the NPC talking
        option_1 = GameObject.Find("option_1Btn");// these are player options + exit
        option_2 = GameObject.Find("option_2Btn");
        option_3 = GameObject.Find("option_3Btn");
        exit = GameObject.Find("nextBtn");
        exit.GetComponent<Button>().onClick.RemoveAllListeners();
        exit.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(-1); });
        //NPC
        npc = gameObject;// this script is attached to an NPC
        npcScript = npc.GetComponent<NPC>(); // make sure we have the NPC script access on this npc
        npcId = npcScript.Id; // NPC ID. which NPC the player is speaking to
        npcName = npcScript.getName(); // NPC name for Identification and display from npc script
        // AVATAR
        avatarImgPanel = GameObject.Find("NPCAvatarPanel");// the image panel for the NPC dialogue Avatar
        avatarImgPanel.GetComponentInChildren<Image>().sprite = npcScript.getAvatarImg();// take the NPC clicked base image and applies it to the dia av
        avatarImgPanel.GetComponentInChildren<Image>().rectTransform.sizeDelta = (npcScript.getAvatarImg().textureRect.size);

        dialoguePanel.SetActive(false);
    }

    public void RunDialogue()
    {
        StartCoroutine(initiate_npc_node(dialogue.NPCNodes[npcId]));
    }

    private IEnumerator initiate_npc_node(NPCNode node)
    {
        dialoguePanel.SetActive(true);
        int node_id = 0;

        while (node_id != -1)
        { //
            display_node(node.DialogueNodes[node_id]);
            selected_option = -2;

            while (selected_option == -2)
            { //      
                yield return new WaitForSeconds(0.25f);
            }//
            node_id = selected_option;
        }
        dialoguePanel.SetActive(false);
        unSelectedNPC();
    }

    private void unSelectedNPC()
    {
        selected_npc = -1;
    }

    private void display_node(DialogueNode node)
    {
        node_text.GetComponent<Text>().text = node.DialogueText;

        string newString = node_text.GetComponent<Text>().text.Replace("[NPC_NAME]", npcName).Replace("[PLAYER_NAME]", "Adam Mortell");
        node_text.GetComponent<Text>().text = newString;

        option_1.SetActive(false);
        option_2.SetActive(false);
        option_3.SetActive(false);

        for (int i = 0; i < node.Options.Count || i < 1; i++)
        {
            switch (i)
            {
                case 0:
                    set_option_button(option_1, node.Options[i]);
                    break;
                case 1:
                    set_option_button(option_2, node.Options[i]);
                    break;
                case 2:
                    set_option_button(option_3, node.Options[i]);
                    break;
            }
        }
    }

    private void set_option_button(GameObject button, DialogueOption option)
    {
        button.SetActive(true);// sets sent btn ON
        button.GetComponentInChildren<Text>().text = option.OptionText;// fills text with xml option txt
        string newString = button.GetComponentInChildren<Text>().text.Replace("[PLAYER_NAME]", "Adam Mortell").Replace("[NPC_NAME]", npcName);
        button.GetComponentInChildren<Text>().text = newString;

        button.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(option.DestinationNodeID); });
        print("OPTION Destination Node: " + option.DestinationNodeID);
    }

    private void SetSelectedOption(int x)
    {
        selected_option = x;
    }
}