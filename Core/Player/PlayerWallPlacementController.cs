using System.Collections.Generic;
using System.Numerics;

namespace Quoridor.Core.Player
{
    public class PlayerWallPlacementController
    {
        public int wallCounter => _wallCounter;
        public List<Wall> placedWalls => _placedWalls;
        
        private Player _player;
        private int _wallCounter = 10;

        private Vector2 _wallStartPosition;
        private Vector2 _wallEndPosition;
        private int _wallStartPositionX;
        private int _wallStartPositionY;
        private int _wallEndPositionX;
        private int _wallEndPositionY;

        private List<Wall> _placedWalls;

        public PlayerWallPlacementController(Player player)
        {
            _player = player;
            _placedWalls = new List<Wall>();
        }

        public bool PlaceWall(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _wallStartPosition = wallStartPosition;
            _wallEndPosition = wallEndPosition;

            _wallStartPositionX = (int)wallStartPosition.X;
            _wallStartPositionY = (int)wallStartPosition.Y;
            _wallEndPositionX = (int)wallEndPosition.X;
            _wallEndPositionY = (int)wallEndPosition.Y;

            if (WallIsTooLong()) return false;
            if (WallIsNotOnTheSameLine()) return false;
            if (WallTilesHavePairCoordinates()) return false;

            _wallCounter--;

            Wall newWall = new Wall(wallStartPosition, wallEndPosition);
            _placedWalls.Add(newWall);

            for (int i = _wallStartPositionX; i <= _wallEndPositionX; i++)
            {
                for (int j = _wallStartPositionY; j <= _wallEndPositionY; j++)
                {
                    Tile tile = _player.board.grid[i, j];
                    tile.isEmpty = false;
                }
            }

            return true;
        }

        private bool WallIsTooLong()
        {
            return _wallEndPosition.X - _wallStartPosition.X > 2 ||
                    _wallEndPosition.Y - _wallStartPosition.Y > 2;
        }

        private bool WallIsNotOnTheSameLine()
        {
            return _wallStartPosition.X != _wallEndPosition.X &&
                    _wallStartPosition.Y != _wallEndPosition.Y;
        }

        private bool WallTilesHavePairCoordinates()
        {
            int middlePositionX = (_wallEndPositionX + _wallStartPositionX) / 2;
            int middlePositionY = (_wallEndPositionY + _wallStartPositionY) / 2;

            if (_wallStartPositionX % 2 == 0 && _wallStartPositionY % 2 == 0) return true;
            if (middlePositionX % 2 == 0 && middlePositionY % 2 == 0) return true;

            return false;
        }
    }
}