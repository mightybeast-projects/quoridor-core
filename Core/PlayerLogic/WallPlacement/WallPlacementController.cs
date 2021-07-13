using System;
using System.Collections.Generic;
using System.Numerics;

namespace Quoridor.Core.PlayerLogic.WallPlacement
{
    public class WallPlacementController
    {
        public int wallCounter => _wallCounter;

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
            _wallValidator.InitializeVectors(wallStartPosition, wallEndPosition);
            
            try { _wallValidator.CheckWallRequirements(); }
            catch (Exception e) 
            {
                _player.output?.DisplayExceptionMessage(e);
                return;
            }

            PlaceNewWall();
        }

        private void PlaceNewWall()
        {
            _wallCounter--;

            Wall newWall = new Wall(_wallStartPosition, _wallEndPosition);

            _player.board.placedWalls.Add(newWall);

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