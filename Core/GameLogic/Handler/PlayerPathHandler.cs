using System;
using Pathfinding;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic.Handler
{
    public class PlayerPathHandler
    {
        private Player _player;
        private AStar _algo;

        internal PlayerPathHandler()
        {
            _algo = new AStar();
        }

        internal bool CheckPathToGoalFor(Player player)
        {
            _player = player;
            Board board = _player.board;
            Tile playerPositionTile
                = board.grid[(int)_player.position.X, (int)_player.position.Y];
            bool pathToGoal = false;

            Console.WriteLine(playerPositionTile.position);
            foreach (Tile tile in _player.goal)
            {
                _algo.DoAStar(playerPositionTile, tile);
                if (_algo.path.Count > 0)
                    pathToGoal = true;
            }

            return pathToGoal;
        }
    }
}