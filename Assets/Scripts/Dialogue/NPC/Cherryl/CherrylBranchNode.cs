using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DialogueTree {

    public class CherrylBranchNode {

        public int CherrylNodeId;
        public string NPCName;
        public List<DialogueNode> DialogueNodes;

        public CherrylBranchNode() {
            DialogueNodes = new List<DialogueNode>();
        }

        public CherrylBranchNode(string name) {
            NPCName = name;
            DialogueNodes = new List<DialogueNode>();
        }
    }
}
