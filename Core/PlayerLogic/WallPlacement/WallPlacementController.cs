using System.Numerics;

namespace Quoridor.Core.PlayerLogic.WallPlacement
{
    internal class WallPlacementController
    {
        internal int wallCounter 
        { 
            get => _wallCounter; 
            set => _wallCounter = value; 
        }
        internal Wall lastPlacedWall { get; private set; }

        private Player _player;
        private WallValidator _wallValidator;
        private Vector2 _wallStartPosition;
        private Vector2 _wallEndPosition;
        private int _wallCounter = 10;
        private bool _isEmptyStatus;

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

        private void PlaceNewWall()
        {
            _wallCounter--;

            lastPlacedWall = new Wall(_wallStartPosition, _wallEndPosition);

            _player.board.placedWalls.Add(lastPlacedWall);

            _isEmptyStatus = false;
            ChangeWallStatus();
        }

        internal void RevertLastPlacedWall()
        {
            _wallCounter++;

            _player.board.placedWalls.Remove(lastPlacedWall);

            _isEmptyStatus = true;
            ChangeWallStatus();
        }

        private void ChangeWallStatus()
        {
            ChangeSimpleWallStatus();
            ChangeReverseWallStatus();
        }

        private void ChangeSimpleWallStatus()
        {
            for (int i = (int) _wallStartPosition.X; i <= (int) _wallEndPosition.X; i++)
                for (int j = (int) _wallStartPosition.Y; j <= (int) _wallEndPosition.Y; j++)
                    ChangeTileEmptyStatus(i, j);
        }

        private void ChangeReverseWallStatus()
        {
            ChangeReverseWallVariationStatus(_wallEndPosition, _wallStartPosition);
            ChangeReverseWallVariationStatus(_wallStartPosition, _wallEndPosition);
        }

        private void ChangeReverseWallVariationStatus(Vector2 start, Vector2 end)
        {
            for (int i = (int) start.X; i <= (int) end.X; i++)
                for (int j = (int) end.Y; j <= (int) start.Y; j++)
                    ChangeTileEmptyStatus(i, j);
        }

        private void ChangeTileEmptyStatus(int i, int j)
        {
            Tile tile = _player.board.grid[i, j];
            tile.isEmpty = _isEmptyStatus;
        }
    }
}