using System.Collections.Generic;
using System.Numerics;

namespace Quoridor.Core.Player
{
    public class WallPlacementController
    {
        public int wallCounter => _wallCounter;
        public List<Wall> placedWalls => _placedWalls;
        
        private Player _player;
        private int _wallCounter = 10;

        private Vector2 _wallStartPosition;
        private Vector2 _wallEndPosition;

        private List<Wall> _placedWalls;
        private WallValidator _wallValidator;

        internal WallPlacementController(Player player)
        {
            _player = player;
            _placedWalls = new List<Wall>();
            _wallValidator = new WallValidator(player);
        }

        internal void PlaceWall(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            if(_wallCounter == 0)
            {
                _player.output.DisplayPlacedAllAvailableWallsMessage();
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

        internal void SetOutput(IOutput output)
        {
            _wallValidator.SetOutput(output);
        }

        private void PlaceNewWall()
        {
            _wallCounter--;

            Wall newWall = new Wall(_wallStartPosition, _wallEndPosition);
            _placedWalls.Add(newWall);

            for (int i = (int)_wallStartPosition.X; i <= (int)_wallEndPosition.X; i++)
                for (int j = (int)_wallStartPosition.Y; j <= (int)_wallEndPosition.Y; j++)
                    InitializeTile(i, j);
        }

        private void InitializeTile(int i, int j)
        {
            Tile tile = _player.board.grid[i, j];
            tile.isEmpty = false;
        }
    }
}