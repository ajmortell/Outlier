using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogueTree {

    public class Dialogue {

        public List<NPCNode> NPCNodes;
        public Dialogue() {
            NPCNodes = new List<NPCNode>();
        }
        public static Dialogue LoadDialogue(string path) {
            XmlSerializer xml = new XmlSerializer(typeof(Dialogue));
            StreamReader reader = new StreamReader(path);
            Dialogue dia = (Dialogue)xml.Deserialize(reader);
            return dia;
        }

    }
}