using System.Collections.Generic;
using System.Numerics;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic.Handler
{
    public class PlayerWallPlacementHandler
    {
        internal Player currentPlayer
        {
            get => _currentPlayer;
            set => _currentPlayer = value;
        }

        private Player _currentPlayer;
        private List<Player> _players;
        private PlayerPathHandler _pathHandler;
        private int _previousWallCounter;


        public PlayerWallPlacementHandler(List<Player> players)
        {
            _players = players;
            _pathHandler = new PlayerPathHandler();
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
            bool pathAvailable = _pathHandler.CheckPathToGoalFor(player);
            return pathAvailable;
        }

        private bool PlayerPlacedWrongWall()
        {
            return _currentPlayer.wallCounter == _previousWallCounter;
        }
    }
}