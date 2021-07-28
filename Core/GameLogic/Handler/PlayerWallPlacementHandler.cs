using System.Collections.Generic;
using System.Numerics;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic.Handler
{
    internal class PlayerWallPlacementHandler : GameHandler
    {
        private GameConfig _gameConfig;
        private PlayerPathValidator _pathValidator;
        private int _previousWallCounter;

        internal PlayerWallPlacementHandler(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
            _pathValidator = new PlayerPathValidator();
        }

        internal bool HandleWallPlacement(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _currentPlayer = _gameConfig.currentPlayer;
            _previousWallCounter = _currentPlayer.wallCounter;

            _currentPlayer.PlaceWall(wallStartPosition, wallEndPosition);

            if (PlayerPlacedWrongWall())
                return false;
            if (OneOfThePlayersDoNotHavePathToGoal())
            {
                _currentPlayer.RevertWallPlacement();
                _currentPlayer.output?.DisplayExceptionMessage(new NoPathForPlayerException());
                return false;
            }

            return true;
        }

        private bool OneOfThePlayersDoNotHavePathToGoal()
        {
            foreach (Player player in _gameConfig.players)
                if (!PlayerHavePathToGoal(player))
                    return true;

            return false;
        }

        private bool PlayerHavePathToGoal(Player player)
        {
            return _pathValidator.CheckPathToGoalFor(player);
        }

        private bool PlayerPlacedWrongWall()
        {
            return _currentPlayer.wallCounter == _previousWallCounter;
        }
    }
}