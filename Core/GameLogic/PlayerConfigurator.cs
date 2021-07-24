using System.Collections.Generic;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic
{
    public class PlayerConfigurator
    {
        private List<Player> _players;
        private Player _playerToConfig;
        private Board _board;
        private int _playerIndex;
        private int _startingPositionCoordinate;
        private int _goalIndex;

        public PlayerConfigurator(Board board, List<Player> players)
        {
            _board = board;
            _players = players;
        }

        internal void ConfigurePlayers()
        {
            SetPlayerWallCounter();

            for (int i = 0; i < _players.Count; i++)
            {
                _playerIndex = i;
                _playerToConfig = _players[_playerIndex];

                if (i == 0 || i == 2)
                    _startingPositionCoordinate = 0;
                else
                    _startingPositionCoordinate = 16;

                if (i == 0 || i == 2)
                    _goalIndex = 16;
                else
                    _goalIndex = 0;

                if (i < 2)
                    _playerToConfig.SetPosition(8, _startingPositionCoordinate);
                else
                    _playerToConfig.SetPosition(_startingPositionCoordinate, 8);

                if (i == 0 || i == 1)
                    for (int x = 0; x < _playerToConfig.goal.Length; x++)
                        _playerToConfig.goal[x] = _board.grid[x * 2, _goalIndex];
                else
                    for (int y = 0; y < _playerToConfig.goal.Length; y++)
                        _playerToConfig.goal[y] = _board.grid[_goalIndex, y * 2];
            }
        }

        private void SetPlayerWallCounter()
        {
            foreach (Player player in _players)
                player.SetStartingWallCounter(20 / _players.Count);
        }
    }
}