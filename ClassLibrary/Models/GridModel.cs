using System.Collections.Generic;


namespace ClassLibrary
{
    public class GridModel
    {
        public string[][] Grid { get; set; }
        public List<string> GridSelections { get; set; } = new List<string>();
        public List<string> HitTargets { get; set; } = new List<string>();
        public List<string> MissedTargets { get; set; } = new List<string>();
        public List<string> AllTargetSelections { get; set; } = new List<string>();
    }
}
