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
            _middlePosition.X = (_endPosition.X + _startPosition.X) / 2;
            _middlePosition.Y = (_endPosition.Y + startPosition.Y) / 2;
        }
    }
}