using System.Collections.Generic;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic
{
    public class GameConfig
    {
        public List<Player> players => _players;
        public Board board => _board;
        internal Player currentPlayer
        {
            get => _currentPlayer;
            set => _currentPlayer = value;
        }

        internal int currentPlayerIndex
        {
            get => _currentPlayerIndex;
            set => _currentPlayerIndex = value;
        }

        private List<Player> _players;
        private Board _board;
        private Player _currentPlayer;
        private int _currentPlayerIndex = -1;

        public GameConfig()
        {
            _players = new List<Player>();
            _board = new Board();
        }
    }
}