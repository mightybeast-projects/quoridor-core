using System.Collections.Generic;
using System.Numerics;

namespace Quoridor.Core.Player.WallPlacement
{
    public class WallPlacementController
    {
        public int wallCounter => _wallCounter;
        public List<Wall> placedWalls => _placedWalls;

        private Player _player;
        private WallValidator _wallValidator;
        private Vector2 _wallStartPosition;
        private Vector2 _wallEndPosition;
        private List<Wall> _placedWalls;
        private int _wallCounter = 10;

        internal WallPlacementController(Player player)
        {
            _player = player;
            _placedWalls = new List<Wall>();
            _wallValidator = new WallValidator(player);
        }

        internal void PlaceWall(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            if (_wallCounter == 0)
            {
                _player.output.DisplayNotEnoughWallsMessage();
                return;
            }

            _wallValidator.InitializeVectors(wallStartPosition, wallEndPosition);
            if (_wallValidator.WallDoesNotMeetTheRequirements())
            {
                _wallValidator.SendAppropriateMessage();
                return;
            }

            _wallStartPosition = wallStartPosition;
            _wallEndPosition = wallEndPosition;

            PlaceNewWall();
        }

        private void PlaceNewWall()
        {
            _wallCounter--;

            Wall newWall = new Wall(_wallStartPosition, _wallEndPosition);
            _placedWalls.Add(newWall);

            for (int i = (int)_wallStartPosition.X; i <= (int)_wallEndPosition.X; i++)
                for (int j = (int)_wallStartPosition.Y; j <= (int)_wallEndPosition.Y; j++)
                    InitializeTile(i, j);

            PlaceReversedWallOnBoard(_wallEndPosition, _wallStartPosition);
            PlaceReversedWallOnBoard(_wallStartPosition, _wallEndPosition);
        }

        private void PlaceReversedWallOnBoard(Vector2 start, Vector2 end)
        {
            for (int i = (int)start.X; i <= (int)end.X; i++)
                for (int j = (int)end.Y; j <= (int)start.Y; j++)
                    InitializeTile(i, j);
        }

        private void InitializeTile(int i, int j)
        {
            Tile tile = _player.board.grid[i, j];
            tile.isEmpty = false;
        }
    }
}