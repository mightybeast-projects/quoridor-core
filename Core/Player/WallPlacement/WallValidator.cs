using System;
using System.Collections.Generic;
using System.Numerics;

namespace Quoridor.Core.Player.WallPlacement
{
    public class WallValidator
    {
        private Vector2 _wallStartPosition;
        private Vector2 _wallMiddlePosition;
        private Vector2 _wallEndPosition;
        private Player _player;

        internal WallValidator(Player player)
        {
            _player = player;
        }

        internal void InitializeVectors(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _wallStartPosition = wallStartPosition;
            _wallEndPosition = wallEndPosition;
        }

        internal bool WallDoesNotMeetTheRequirements()
        {
            if (WallPositionIsBeyondBoard()||
                PlayerUsedAllAvailableWalls()||
                WallIsNotOnTheSameLine() ||
                WallIsTooLong() ||
                WallTilesHavePairCoordinates() ||
                WallDoesNotCoverTwoSolidTiles() ||
                WallInterceptsWithOtherWall())
                return true;

            return false;
        }

        internal void SendAppropriateMessage()
        {
            if (WallPositionIsBeyondBoard())
                _player.output?.DisplayWallHasPositionBeyondBoardMessage();
            if (PlayerUsedAllAvailableWalls())
                _player.output?.DisplayNotEnoughWallsMessage();
            if (WallIsNotOnTheSameLine())
                _player.output?.DisplayWallIsNotOnTheSameLineMessage();
            if (WallIsTooLong())
                _player.output?.DisplayWallIsTooLongMessage();
            if (WallTilesHavePairCoordinates())
                _player.output?.DisplayWallTilesHavePairCoordinatesMessage();
            if (WallDoesNotCoverTwoSolidTiles())
                _player.output?.DisplayWallDoesNotCoverTwoSolidTilesMessage();
            if (WallInterceptsWithOtherWall())
                _player.output?.DisplayWallInterceptsWithOtherWallMessage();
        }

        private bool WallPositionIsBeyondBoard()
        {
            return PositionIsBeyondBoard(_wallStartPosition) ||
                    PositionIsBeyondBoard(_wallEndPosition);
        }

        private bool PlayerUsedAllAvailableWalls()
        {
            return _player.wallCounter == 0;
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
            foreach (Wall placedWall in _player.placedWalls)
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

        private bool PositionIsBeyondBoard(Vector2 position)
        {
            return position.X > 16 || position.Y > 16 ||
                    position.X < 0 || position.Y < 0;
        }
    }
}