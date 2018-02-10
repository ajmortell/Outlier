using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

/// <summary>
/// holds a list of the each branch node the NPC has. 
/// then deserializes the actual XML
/// </summary>
namespace DialogueTree {

    public class CherrylDialogueTree {

        public List<CherrylBranchNode> CherrylBranchNodes;
        public CherrylDialogueTree() {
            CherrylBranchNodes = new List<CherrylBranchNode>();
        }
        public static CherrylDialogueTree LoadDialogue(string path) {
            XmlSerializer xml = new XmlSerializer(typeof(CherrylDialogueTree));
            StreamReader reader = new StreamReader(path);
            CherrylDialogueTree dia = (CherrylDialogueTree)xml.Deserialize(reader);
            return dia;
        }

    }
}