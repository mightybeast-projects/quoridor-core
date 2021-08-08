using System.Numerics;
using Quoridor.Core.PlayerLogic.WallPlacement.Exceptions;

namespace Quoridor.Core.PlayerLogic.WallPlacement
{
    internal class WallValidator
    {
        private Vector2 _wallStartPosition;
        private Vector2 _wallMiddlePosition;
        private Vector2 _wallEndPosition;
        private Player _player;

        public WallValidator(Player player)
        {
            _player = player;
        }

        internal void InitializeWallPositions(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _wallStartPosition = wallStartPosition;
            _wallEndPosition = wallEndPosition;
        }

        internal void CheckWallRequirements()
        {
            if (WallPositionIsBeyondBoard()) 
                throw new WallIsBeyondBoardException();
            if (PlayerUsedAllAvailableWalls()) 
                throw new PlayerUsedWallsException();
            if (WallIsNotOnTheSameLine())
                throw new WallIsNotOnTheSameLineException();
            if (WallIsTooLong()) 
                throw new WallIsTooLongException();
            if (WallTilesHavePairCoordinates()) 
                throw new WallTilesHavePairCoordinatesException();
            if (WallDoesNotCoverTwoSolidTiles() || WallTilesAreAtTheSameSpot())
                throw new WallDoesNotCoverSolidTilesException();
            if (WallInterceptsWithOtherWall())
                throw new WallInterceptsWithOtherWallException();
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

        private bool WallTilesAreAtTheSameSpot()
        {
            return _wallStartPosition == _wallEndPosition;
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
            foreach (Wall placedWall in _player.board.placedWalls)
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