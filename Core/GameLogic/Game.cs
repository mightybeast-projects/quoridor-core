using System.Collections.Generic;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic
{
    public class Game
    {
        public List<Player> players => _players;
        public Board board => _board;
        public Player currentPlayer => _currentPlayer;

        private List<Player> _players;
        private Board _board;
        private Player _currentPlayer;

        public Game(Board board, List<Player> players)
        {
            _board = board;
            _players = players;

            _players[0].SetPosition(8, 0);
            _players[1].SetPosition(8, 16);

            _players[0].SetGoal(8, 16);
            _players[1].SetGoal(8, 0);

            _currentPlayer = _players[0];
        }

        public void SetPlayersOutput(IOutput output)
        {
            foreach (Player player in _players)
                player.SetOutput(output);
        }
    }
}