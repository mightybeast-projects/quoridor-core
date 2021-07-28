using System.Numerics;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic.Handler
{
    internal class PlayerWallPlacementHandler : GameHandler
    {
        private PlayerPathValidator _pathValidator;
        private int _previousWallCounter;

        internal PlayerWallPlacementHandler(GameConfig gameConfig) : 
            base(gameConfig)
        {
            _pathValidator = new PlayerPathValidator();
        }

        internal void HandleWallPlacement(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _previousWallCounter = _gameConfig.currentPlayer.wallCounter;

            _gameConfig.currentPlayer.PlaceWall(wallStartPosition, wallEndPosition);

            if (PlayerPlacedWrongWall())
                return;
            if (OneOfThePlayersDoNotHavePathToGoal())
            {
                _gameConfig.currentPlayer.RevertWallPlacement();
                _gameConfig.currentPlayer.output?.DisplayExceptionMessage(new NoPathForPlayerException());
                return;
            }

            _gameConfig.SwitchCurrentPlayer();
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
            return _gameConfig.currentPlayer.wallCounter == _previousWallCounter;
        }
    }
}