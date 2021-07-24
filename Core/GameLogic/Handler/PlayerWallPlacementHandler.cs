using System.Collections.Generic;
using System.Numerics;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic.Handler
{
    class PlayerWallPlacementHandler : GameHandler
    {
        private List<Player> _players;
        private PlayerPathValidator _pathValidator;
        private int _previousWallCounter;


        public PlayerWallPlacementHandler(List<Player> players)
        {
            _players = players;
            _pathValidator = new PlayerPathValidator();
        }

        internal bool HandleWallPlacement(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
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
            foreach (Player player in _players)
                if (!PlayerHavePathToGoal(player))
                    return true;

            return false;
        }

        private bool PlayerHavePathToGoal(Player player)
        {
            bool pathAvailable = _pathValidator.CheckPathToGoalFor(player);
            return pathAvailable;
        }

        private bool PlayerPlacedWrongWall()
        {
            return _currentPlayer.wallCounter == _previousWallCounter;
        }
    }
}