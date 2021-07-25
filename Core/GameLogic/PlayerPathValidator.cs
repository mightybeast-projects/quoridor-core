using System.Numerics;
using System;
using Pathfinding;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic
{
    internal class PlayerPathValidator
    {
        private Player _player;
        private AStar _algo;
        private Board _board;
        private Tile _playerPositionTile;
        private bool _pathToGoal;

        internal PlayerPathValidator()
        {
            _algo = new AStar();
        }

        internal bool CheckPathToGoalFor(Player player)
        {
            _player = player;
            _board = _player.board;
            _playerPositionTile = _board.grid[(int)_player.position.X, (int)_player.position.Y];
            _pathToGoal = false;

            Console.WriteLine(_playerPositionTile.position);
            foreach (Tile tile in _player.goal)
                CheckPathToTile(tile);

            return _pathToGoal;
        }

        private void CheckPathToTile(Tile tile)
        {
            _algo.DoAStar(_playerPositionTile, tile);
            if (_algo.path.Count > 0)
                _pathToGoal = true;
        }
    }
}