using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace DialogueTree {

    public class CherrylDialogueTree {

        public List<CherrylBranchNode> CherrylBranchNodes;
  
        public CherrylDialogueTree() {
            CherrylBranchNodes = new List<CherrylBranchNode>();           
        }
        /// <summary>
        /// Holds a list of each branch node the NPC has 
        /// then deserializes the actual XML.
        /// </summary>
        public static CherrylDialogueTree LoadDialogue(string path) {
            XmlSerializer xml = new XmlSerializer(typeof(CherrylDialogueTree));
            StreamReader reader = new StreamReader(path);
            CherrylDialogueTree dia = (CherrylDialogueTree)xml.Deserialize(reader);
            return dia;
        }

    }
}