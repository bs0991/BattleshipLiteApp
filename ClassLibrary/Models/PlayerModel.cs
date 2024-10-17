using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Models
{
    public class PlayerModel
    {
        public string PlayerID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public GridModel PlayerGrid { get; set; }
    }
}

