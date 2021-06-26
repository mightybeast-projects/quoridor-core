using System;
using System.Numerics;

namespace Quoridor.Core
{
    public class Wall
    {
        public Vector2 startPosition => _startPosition;
        public Vector2 middlePosition => _middlePosition;
        public Vector2 endPosition => _endPosition;

        private Vector2 _startPosition;
        private Vector2 _middlePosition;
        private Vector2 _endPosition;

        public Wall(Vector2 startPosition, Vector2 endPosition)
        {
            _startPosition = startPosition;
            _endPosition = endPosition;
            CalculateMiddlePosition();
        }

        private void CalculateMiddlePosition()
        {
            _middlePosition.X = _endPosition.X - _startPosition.X;
            _middlePosition.Y = _endPosition.Y - startPosition.Y;

            if(_middlePosition.X == 0) _middlePosition.X = startPosition.X;
            if(_middlePosition.Y == 0) _middlePosition.Y = startPosition.Y;
        }
    }
}