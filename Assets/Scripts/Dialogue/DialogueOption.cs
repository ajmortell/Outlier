using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DialogueTree {

    public class DialogueOption {

        public string OptionText;
        public int DestinationNodeID;
  
        public DialogueOption() {
        }

        public DialogueOption(string text, int destination) {
            OptionText = text;
            DestinationNodeID = destination;
        }
    }
}