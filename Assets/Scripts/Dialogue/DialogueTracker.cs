using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DialogueTree
{
    public class DialogueTracker {

        public int BranchTracker;
        public int LieTracker;
        // Use this for initialization
        public DialogueTracker() {
        }

        public DialogueTracker(int branch, int lie) {
            BranchTracker = branch;
            LieTracker = lie;
        }
    }
}