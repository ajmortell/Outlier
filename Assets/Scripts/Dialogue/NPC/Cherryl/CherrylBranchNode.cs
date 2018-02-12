using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DialogueTree {

    public class CherrylBranchNode {
  
        public List<DialogueNode> DialogueNodes;

        public CherrylBranchNode() {
            DialogueNodes = new List<DialogueNode>();
        }

        public CherrylBranchNode(string name) {
            DialogueNodes = new List<DialogueNode>();
        }
    }
}
