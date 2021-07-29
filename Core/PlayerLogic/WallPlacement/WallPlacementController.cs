using System;
using System.Numerics;

namespace Quoridor.Core.PlayerLogic.WallPlacement
{
    internal class WallPlacementController
    {
        public int wallCounter
        {
            get => _wallCounter;
            internal set => _wallCounter = value;
        }
        public Wall lastPlacedWall => _lastPlacedWall;

        private Player _player;
        private WallValidator _wallValidator;
        private Wall _lastPlacedWall;
        private Vector2 _wallStartPosition;
        private Vector2 _wallEndPosition;
        private int _wallCounter = 10;

        internal WallPlacementController(Player player)
        {
            _player = player;
            _wallValidator = new WallValidator(player);
        }

        internal void PlaceWall(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _wallStartPosition = wallStartPosition;
            _wallEndPosition = wallEndPosition;
            
            _wallValidator.InitializeWallPositions(wallStartPosition, wallEndPosition);
            
            _wallValidator.CheckWallRequirements();

            PlaceNewWall();
        }

        internal void RevertLastPlacedWall()
        {
            for (int i = (int) _lastPlacedWall.startPosition.X; i <= (int) _lastPlacedWall.endPosition.X; i++)
                for (int j = (int) _lastPlacedWall.startPosition.Y; j <= (int) _lastPlacedWall.endPosition.Y; j++)
                    RevertWallTile(i, j);

            _player.board.placedWalls.Remove(_lastPlacedWall);

            _wallCounter++;
        }

        private void PlaceNewWall()
        {
            _wallCounter--;

            _lastPlacedWall = new Wall(_wallStartPosition, _wallEndPosition);

            _player.board.placedWalls.Add(_lastPlacedWall);

            for (int i = (int) _wallStartPosition.X; i <= (int) _wallEndPosition.X; i++)
                for (int j = (int) _wallStartPosition.Y; j <= (int) _wallEndPosition.Y; j++)
                    InitializeWallTile(i, j);

            PlaceReversedWallOnBoard(_wallEndPosition, _wallStartPosition);
            PlaceReversedWallOnBoard(_wallStartPosition, _wallEndPosition);
        }

        private void PlaceReversedWallOnBoard(Vector2 start, Vector2 end)
        {
            for (int i = (int) start.X; i <= (int) end.X; i++)
                for (int j = (int) end.Y; j <= (int) start.Y; j++)
                    InitializeWallTile(i, j);
        }

        private void InitializeWallTile(int i, int j)
        {
            Tile tile = _player.board.grid[i, j];
            tile.isEmpty = false;
        }

        private void RevertWallTile(int i, int j)
        {
            Tile tile = _player.board.grid[i, j];
            tile.isEmpty = true;
        }
    }
}