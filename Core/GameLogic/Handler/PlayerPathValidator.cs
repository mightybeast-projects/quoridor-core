using System;
using System.Linq;
using Pathfinding;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic.Handler
{
    internal class PlayerPathValidator : GameHandler
    {
        private AStar _algo;
        private Tile _playerPositionTile;
        private bool _pathToGoal;

        internal PlayerPathValidator(GameConfig gameConfig)
            : base(gameConfig)
        {
            _algo = new AStar();
        }

        internal void CheckPathsToGoal()
        {
            if (OneOfThePlayersDoNotHavePathToGoal())
            {
                _gameConfig.currentPlayer.RevertWallPlacement();
                throw new NoPathForPlayerException();
            }
        }

        private bool OneOfThePlayersDoNotHavePathToGoal()
        {
            return _gameConfig.players.Any(player => !PlayerHavePathToGoal(player));
        }

        private bool PlayerHavePathToGoal(Player player)
        {
            _playerPositionTile = _gameConfig.board.grid[(int) player.position.X, (int) player.position.Y];
            _pathToGoal = false;

            Console.WriteLine(_playerPositionTile.position);
            foreach (Tile tile in player.goal)
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