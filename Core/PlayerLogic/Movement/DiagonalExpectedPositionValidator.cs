using System;
using System.Numerics;
using Quoridor.Core.PlayerLogic.Movement.Exceptions;

namespace Quoridor.Core.PlayerLogic.Movement
{
    public class DiagonalExpectedPositionValidator : ExpectedPositionValidator
    {
        public DiagonalExpectedPositionValidator(Player player) : base(player) {}

        public void CheckDiagonalExpectedPosition()
        {
            if (MoveIsDiagonalButPlayerCannotMoveDiagonally())
                throw new CannotMoveDiagonallyException();
            if (MoveIsDiagonalAndPlayerCanMoveDiagonally())
                return;
        }

        private bool MoveIsDiagonalButPlayerCannotMoveDiagonally()
        {
            return MoveVectorIsDiagonal() && !PlayerCanMoveDiagonally();
        }

        private bool MoveIsDiagonalAndPlayerCanMoveDiagonally()
        {
            return MoveVectorIsDiagonal() && PlayerCanMoveDiagonally();
        }

        private bool PlayerCanMoveDiagonally()
        {
            Vector2 expectedPositionTmp = _expectedPosition;
            Vector2 moveVectorTmp = _moveVector;

            bool firstDirectionHavePlayerAndWallBehind = 
                CheckExpectedPositionForPlayerAndWallBehind(new Vector2(0, moveVectorTmp.Y));
            bool secondDirectionHavePlayerAndWallBehind = 
                CheckExpectedPositionForPlayerAndWallBehind(new Vector2(moveVectorTmp.X, 0));
            
            bool firstDirectionHasTwoPlayers =
                CheckExpectedPositionForTwoPlayers(new Vector2(0, moveVectorTmp.Y));
            bool secondDirectionHasTwoPlayers =
                CheckExpectedPositionForTwoPlayers(new Vector2(moveVectorTmp.X, 0));

            bool wallIsOnFirstDiagonalMove = 
                WallIsOnDiagonalMovement(
                    _currentPosition + new Vector2(moveVectorTmp.X / 2, moveVectorTmp.Y));
            bool wallIsOnSecondDiagonalMove = 
                WallIsOnDiagonalMovement(
                    _currentPosition + new Vector2(moveVectorTmp.X, moveVectorTmp.Y / 2));

            _expectedPosition = expectedPositionTmp;
            _moveVector = moveVectorTmp;

            return ((firstDirectionHavePlayerAndWallBehind && !wallIsOnFirstDiagonalMove) || 
                    (secondDirectionHavePlayerAndWallBehind && !wallIsOnSecondDiagonalMove)) ||
                    ((firstDirectionHasTwoPlayers && !wallIsOnFirstDiagonalMove) ||
                     (secondDirectionHasTwoPlayers && !wallIsOnSecondDiagonalMove));
        }

        private bool CheckExpectedPositionForPlayerAndWallBehind(Vector2 moveVector)
        {
            CalculateExpectedPosition(_currentPosition, moveVector);

            return AnotherPlayerIsOnExpectedPosition() && 
                    WallIsBehindAnotherPlayer();
        }

        private bool CheckExpectedPositionForTwoPlayers(Vector2 moveVector)
        {
            CalculateExpectedPosition(_currentPosition, moveVector);
            bool firstPlayerOnExpectedPosition = AnotherPlayerIsOnExpectedPosition();
            CalculateExpectedPosition(_currentPosition, moveVector * 2);
            bool secondPlayerOnExpectedPosition = false;
            try { secondPlayerOnExpectedPosition = 
                    AnotherPlayerIsOnExpectedPosition(); }
            catch (Exception) {}

            return firstPlayerOnExpectedPosition && secondPlayerOnExpectedPosition;
        }

        private bool MoveVectorIsDiagonal()
        {
            return Math.Abs(_moveVector.X) == Math.Abs(_moveVector.Y);
        }

        private bool WallIsOnDiagonalMovement(Vector2 moveVector)
        {
            return !_player.board.grid[(int) moveVector.X, (int) moveVector.Y].isEmpty;
        }
    }
}