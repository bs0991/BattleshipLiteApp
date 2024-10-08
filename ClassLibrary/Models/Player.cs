using System.Collections.Generic;

namespace ClassLibrary.Models
{
    /// <summary>
    /// The players object in the game
    /// </summary>
    public class Player // This should be singular.  You only create one player at a time.
    {
        /// <summary>
        /// I would document all of the variables in this class
        /// <remarks>You should also think about using the builder method to build your player objects</remarks>
        /// </summary>
        public List<string> AllTargetSelections;
        public List<string> GridSelections;
        public int HitCount;
        public List<string> HitTargets;
        public bool IsHit { get; set; }
        public string PlayerID;
        public List<string> MissedTargets;
        public string Name;
        public string TargetID { get; set; }

        /// <summary>
        /// Constructs the player object
        /// </summary>
        /// <param name="playerID">Unique identifier of the player</param>
        /// <param name="name">Name chosen but the user, not unique</param>
        /// <param name="gridSelections">The selected location of the player</param>
        public Player(string playerID, string name, List<string> gridSelections)
        {
            PlayerID = playerID;
            Name = name;
            GridSelections = gridSelections;
            HitCount = 0;
            HitTargets = new List<string>();
            MissedTargets = new List<string>();
            AllTargetSelections = new List<string>();
        }

        /// <summary>
        /// Builder method to create a player object
        /// </summary>
        public class Builder
        {
            private string playerID;
            private string name;
            private List<string> gridSelections;

            /// <summary>
            /// Use documentation to explain the builder method
            /// </summary>
            public Builder()
            {
                // Set default values if needed
                playerID = "";
                name = "";
                gridSelections = new List<string>();
            }

            public Builder WithPlayerID(string playerID)
            {
                this.playerID = playerID;
                return this;
            }

            public Builder WithName(string name)
            {
                this.name = name;
                return this;
            }

            public Builder WithGridSelections(List<string> gridSelections)
            {
                this.gridSelections = gridSelections;
                return this;
            }

            public Player Build()
            {
                return new Player(playerID, name, gridSelections);
            }
        }
    }
}

