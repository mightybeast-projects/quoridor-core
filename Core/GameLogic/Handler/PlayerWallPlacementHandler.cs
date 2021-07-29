using System.Numerics;

namespace Quoridor.Core.GameLogic.Handler
{
    internal class PlayerWallPlacementHandler : GameHandler
    {
        private PlayerPathValidator _pathValidator;

        internal PlayerWallPlacementHandler(GameConfig gameConfig) : 
            base(gameConfig)
        {
            _pathValidator = new PlayerPathValidator(gameConfig);
        }

        internal void HandleWallPlacement(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _gameConfig.currentPlayer.PlaceWall(wallStartPosition, wallEndPosition);

            _pathValidator.CheckPathsToGoal();

            _gameConfig.SwitchCurrentPlayer();
        }
    }
}