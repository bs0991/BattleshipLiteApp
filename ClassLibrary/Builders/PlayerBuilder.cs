using ClassLibrary.Models;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class PlayerBuilder
    {
        private PlayerModel _player = new PlayerModel();

        public PlayerBuilder AddPlayerID(string playerID)
        {
            _player.PlayerID = playerID;
            return this;
        }

        public PlayerBuilder AddPlayerName(string playerName)
        {
            _player.Name = playerName;
            return this;
        }

        public PlayerBuilder AddPlayerGrid(GridModel grid)
        {
            _player.PlayerGrid = grid;
            return this;
        }

        public PlayerModel Build()
        {
            return _player;
        }
    }
}
