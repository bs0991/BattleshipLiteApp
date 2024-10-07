using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Models
{
    public class Players
    {

        public string TargetID { get; set; }
        public bool IsHit { get; set; }

        public string PlayerID;
        public string Name;
        public List<string> GridSelections;
        public int HitCount;
        public List<string> AllTargetSelections;
        public List<string> HitTargets;
        public List<string> MissedTargets;
        
        public Players(string playerID, string name, List<string> gridSelections)
        {
            PlayerID = playerID;
            Name = name;
            GridSelections = gridSelections;
            HitCount = 0;
            HitTargets = new List<string>();
            MissedTargets = new List<string>();
            AllTargetSelections = new List<string>();
        }
    }
}

