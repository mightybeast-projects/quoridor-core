using System;
using System.Numerics;

namespace Quoridor.Core.Player
{
    public class WallValidator
    {
        private Vector2 _wallStartPosition;
        private Vector2 _wallMiddlePosition;
        private Vector2 _wallEndPosition;
        private Player _player;

        public WallValidator(Player player)
        {
            _player = player;
        }

        public void InitializeVectors(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _wallStartPosition = wallStartPosition;
            _wallEndPosition = wallEndPosition;
        }

        public bool WallDoesNotMeetTheRequirements()
        {
            SendAppropriateMessageIfWallDoesNotMeetTheRequirements();

            if (WallIsNotOnTheSameLine() ||
                WallIsTooLong() ||
                WallTilesHavePairCoordinates() ||
                WallDoesNotCoverTwoSolidTiles())
                return true;

            return false;
        }

        private void SendAppropriateMessageIfWallDoesNotMeetTheRequirements()
        {
            if (_player.output != null)
            {
                if (WallIsNotOnTheSameLine())
                    _player.output.DisplayWallIsNotOnTheSameLine();
                if (WallIsTooLong())
                    _player.output.DisplayWallIsTooLongMessage();
                if (WallTilesHavePairCoordinates())
                    _player.output.DisplayWallTilesHavePairCoordinates();
                if (WallDoesNotCoverTwoSolidTiles())
                    _player.output.DisplayWallDoesNotCoverTwoSolidTiles();
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
    }
}