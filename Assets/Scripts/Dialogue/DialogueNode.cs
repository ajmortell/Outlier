using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DialogueTree {

    public class DialogueNode {

        public int DialogueNodeID = -1;
        public string DialogueText;
        //public bool Used; // determines if dialougue node has already been used

        public List<DialogueOption> Options;

        public DialogueNode()
        {
            Options = new List<DialogueOption>();
        }

        public DialogueNode(string text)
        {
            DialogueText = text;
            //Used = used;
            Options = new List<DialogueOption>();

        }
    }
}