using System.Numerics;
using Quoridor.Core.PlayerLogic.Movement.Exceptions;

namespace Quoridor.Core.PlayerLogic.Movement.Validator
{
    internal class BasicExpectedPositionValidator : ExpectedPositionValidator
    {
        public BasicExpectedPositionValidator(Player player) : base(player) { }

        internal void CheckBasicExpectedPosition()
        {
            if (ExpectedPositionIsBeyondTheBoard())
                throw new MoveBeyondBoardException();
            if (WallIsOnTheWay())
                throw new WallOnTheWayException();
        }

        private bool WallIsOnTheWay()
        {
            Vector2 wallCheckVector = new Vector2(_moveVector.X / 2, _moveVector.Y / 2);
            int wallPositionX = (int)(wallCheckVector.X + _currentPosition.X);
            int wallPositionY = (int)(wallCheckVector.Y + _currentPosition.Y);

            return !_player.board.grid[wallPositionX, wallPositionY].isEmpty;
        }
    }
}