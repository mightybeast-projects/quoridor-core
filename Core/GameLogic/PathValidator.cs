using System;
using Pathfinding;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic
{
    public class PathValidator
    {
        private Player _player;
        private AStar _algo;

        public PathValidator()
        {
            _algo = new AStar();
        }

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        internal bool CheckPathToGoal()
        {
            Board board = _player.board;
            Tile playerPositionTile = board.grid[(int) _player.position.X, (int) _player.position.Y];

            foreach (Tile tile in _player.goal)
            {
                _algo.DoAStar(playerPositionTile, tile);
                if(_algo.path.Count == 0) return false;
            }

            return true;
        }
    }
}