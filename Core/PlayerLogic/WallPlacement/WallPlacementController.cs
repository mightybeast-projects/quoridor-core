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
            _wallCounter++;

            _player.board.placedWalls.Remove(lastPlacedWall);

            for (int i = (int) lastPlacedWall.startPosition.X; i <= (int) lastPlacedWall.endPosition.X; i++)
                for (int j = (int) lastPlacedWall.startPosition.Y; j <= (int) lastPlacedWall.endPosition.Y; j++)
                    RevertWallTile(i, j);

            RevertReversedWallOnBoard(_wallEndPosition, _wallStartPosition);
            RevertReversedWallOnBoard(_wallStartPosition, _wallEndPosition);
        }

        private void PlaceNewWall()
        {
            _wallCounter--;

            lastPlacedWall = new Wall(_wallStartPosition, _wallEndPosition);

            _player.board.placedWalls.Add(lastPlacedWall);

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

        private void RevertReversedWallOnBoard(Vector2 start, Vector2 end)
        {
            for (int i = (int) start.X; i <= (int) end.X; i++)
                for (int j = (int) end.Y; j <= (int) start.Y; j++)
                    RevertWallTile(i, j);
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