using System.Collections.Generic;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic
{
    internal class GameConfig
    {
        internal List<Player> players => _players;
        internal Board board => _board;
        internal Player currentPlayer { get; set; }
        internal int currentPlayerIndex { get; set; }

        private List<Player> _players;
        private Board _board;

        public GameConfig()
        {
            _players = new List<Player>();
            _board = new Board();
            currentPlayerIndex = -1;
        }

        internal void AddNewPlayers()
        {
            if (_players.Count < 4)
            {
                _players.Add(new Player(_board));
                _players.Add(new Player(_board));
            }
        }

        internal void SwitchCurrentPlayer()
        {
            currentPlayerIndex++;

            if (currentPlayerIndex > players.Count - 1)
                currentPlayerIndex = 0;
            
            currentPlayer = players[currentPlayerIndex];
        }
    }
}