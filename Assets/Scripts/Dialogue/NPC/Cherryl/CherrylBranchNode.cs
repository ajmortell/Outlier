using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DialogueTree {

    public class CherrylBranchNode {

        public int CherrylNodeId;
        public string NPCName;
        public DialogueTracker DialogueTracker;
        public List<DialogueNode> DialogueNodes;

        public CherrylBranchNode() {
            DialogueNodes = new List<DialogueNode>();
            DialogueTracker = new DialogueTracker();
        }

        public CherrylBranchNode(string name) {
            NPCName = name;
            DialogueTracker = new DialogueTracker();
            DialogueNodes = new List<DialogueNode>();
        }
    }
}
