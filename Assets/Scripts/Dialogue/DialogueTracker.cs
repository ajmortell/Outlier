using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace DialogueTree
{
    public class DialogueTracker {

        public int BranchTrackerID;
        public int LieTrackerID;
        // Use this for initialization
        public DialogueTracker() {
        }

        public DialogueTracker(int branchID, int lieID) {
            BranchTrackerID = branchID;
            LieTrackerID = lieID;
        }
    }
}