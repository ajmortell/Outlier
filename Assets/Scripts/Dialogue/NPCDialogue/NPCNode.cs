using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DialogueTree {

    public class NPCNode {

        public int NPCNodeId;// user input on npc determins this. NPCs have IDs as well to pass
        public string NPCName;// NPC name is determined by the name of the GameObject. Could be used to further id.
        public List<DialogueNode> DialogueNodes;

        public NPCNode() {
            DialogueNodes = new List<DialogueNode>();
        }

        public NPCNode(string name) {

            NPCName = name;
            DialogueNodes = new List<DialogueNode>();
        }
    }
}
