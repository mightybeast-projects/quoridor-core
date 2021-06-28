using System;
using System.Collections.Generic;
using System.Numerics;

namespace Quoridor.Core.Player
{
    public class WallValidator
    {
        private Vector2 _wallStartPosition;
        private Vector2 _wallMiddlePosition;
        private Vector2 _wallEndPosition;
        private Player _player;
        private IOutput _output;

        internal WallValidator(Player player)
        {
            _player = player;
        }

        internal void InitializeVectors(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _wallStartPosition = wallStartPosition;
            _wallEndPosition = wallEndPosition;
        }

        internal void SetOutput(IOutput output)
        {
            _output = output;
        }

        internal bool WallDoesNotMeetTheRequirements()
        {
            if (WallIsNotOnTheSameLine() ||
                WallIsTooLong() ||
                WallTilesHavePairCoordinates() ||
                WallDoesNotCoverTwoSolidTiles() ||
                WallInterceptsWithOtherWall())
                return true;

            return false;
        }

        internal void SendAppropriateMessage()
        {
            if (_output != null)
            {
                if (WallIsNotOnTheSameLine())
                    _output.DisplayWallIsNotOnTheSameLine();
                if (WallIsTooLong())
                    _output.DisplayWallIsTooLongMessage();
                if (WallTilesHavePairCoordinates())
                    _output.DisplayWallTilesHavePairCoordinates();
                if (WallDoesNotCoverTwoSolidTiles())
                    _output.DisplayWallDoesNotCoverTwoSolidTiles();
                if(WallInterceptsWithOtherWall())
                    _output.DisplayWallInterceptsWithOtherWall();
            }
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
            _wallMiddlePosition.X = (_wallEndPosition.X + _wallStartPosition.X) / 2;
            _wallMiddlePosition.Y = (_wallEndPosition.Y + _wallStartPosition.Y) / 2;

            if (_wallStartPosition.X % 2 == 0 && _wallStartPosition.Y % 2 == 0) return true;
            if (_wallMiddlePosition.X % 2 == 0 && _wallMiddlePosition.Y % 2 == 0) return true;

            return false;
        }

        private bool WallDoesNotCoverTwoSolidTiles()
        {
            return _wallStartPosition.X % 2 != 0 && _wallStartPosition.Y % 2 != 0;
        }

        private bool WallInterceptsWithOtherWall()
        {
            foreach(Wall placedWall in _player.placedWalls)
                if (CurrentWallContainsSameTilesOf(placedWall))
                    return true;

            return false;
        }

        private bool CurrentWallContainsSameTilesOf(Wall placedWall)
        {
            return CurrentWallContainsPlacedWallTile(placedWall.startPosition) ||
                    CurrentWallContainsPlacedWallTile(placedWall.middlePosition) ||
                    CurrentWallContainsPlacedWallTile(placedWall.endPosition);
        }

        private bool CurrentWallContainsPlacedWallTile(Vector2 tilePosition)
        {
            return TilePositionsAreEqual(tilePosition, _wallStartPosition) || 
                    TilePositionsAreEqual(tilePosition, _wallMiddlePosition) || 
                    TilePositionsAreEqual(tilePosition, _wallEndPosition);
        }

        private bool TilePositionsAreEqual(Vector2 firstTile, Vector2 secondTile)
        {
            return firstTile == secondTile;
        }
    }
}