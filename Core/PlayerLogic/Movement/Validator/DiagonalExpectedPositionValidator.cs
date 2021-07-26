using System;
using System.Numerics;
using Quoridor.Core.PlayerLogic.Movement.Exceptions;

namespace Quoridor.Core.PlayerLogic.Movement.Validator
{
    public class DiagonalExpectedPositionValidator : ExpectedPositionValidator
    {
        private Vector2 _expectedPositionTmp;
        private Vector2 _moveVectorTmp;
        private bool _firstDirectionHavePlayerAndWallBehind;
        private bool _secondDirectionHavePlayerAndWallBehind;
        private bool _firstDirectionHasTwoPlayers;
        private bool _secondDirectionHasTwoPlayers;
        private bool _wallIsOnFirstDiagonalMove;
        private bool _wallIsOnSecondDiagonalMove;

        public DiagonalExpectedPositionValidator(Player player) : base(player) { }

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
            _expectedPositionTmp = _expectedPosition;
            _moveVectorTmp = _moveVector;

            AssignPlayerAndWallBehindBools();
            AssignTwoPlayerBools();
            AssignWallOnDiagonalMoveBools();

            _expectedPosition = _expectedPositionTmp;
            _moveVector = _moveVectorTmp;

            return ThereIsPlayerWithWallBehindHimAndNoWallOnDiagonalMove() ||
                    ThereAreTwoPlayersAndNoWallOnDiagonalMove();
        }

        private bool ThereAreTwoPlayersAndNoWallOnDiagonalMove()
        {
            return _firstDirectionHasTwoPlayers && !_wallIsOnFirstDiagonalMove ||
                    _secondDirectionHasTwoPlayers && !_wallIsOnSecondDiagonalMove;
        }

        private bool ThereIsPlayerWithWallBehindHimAndNoWallOnDiagonalMove()
        {
            return _firstDirectionHavePlayerAndWallBehind && !_wallIsOnFirstDiagonalMove ||
                    _secondDirectionHavePlayerAndWallBehind && !_wallIsOnSecondDiagonalMove;
        }

        private void AssignWallOnDiagonalMoveBools()
        {
            _wallIsOnFirstDiagonalMove =
                WallIsOnDiagonalMovement(_currentPosition + new Vector2(_moveVectorTmp.X / 2, _moveVectorTmp.Y));
            _wallIsOnSecondDiagonalMove =
                WallIsOnDiagonalMovement(_currentPosition + new Vector2(_moveVectorTmp.X, _moveVectorTmp.Y / 2));
        }

        private void AssignTwoPlayerBools()
        {
            _firstDirectionHasTwoPlayers =
                CheckExpectedPositionForTwoPlayers(new Vector2(0, _moveVectorTmp.Y));
            _secondDirectionHasTwoPlayers =
                CheckExpectedPositionForTwoPlayers(new Vector2(_moveVectorTmp.X, 0));
        }

        private void AssignPlayerAndWallBehindBools()
        {
            _firstDirectionHavePlayerAndWallBehind =
                CheckExpectedPositionForPlayerAndWallBehind(new Vector2(0, _moveVectorTmp.Y));
            _secondDirectionHavePlayerAndWallBehind =
                CheckExpectedPositionForPlayerAndWallBehind(new Vector2(_moveVectorTmp.X, 0));
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
            try { secondPlayerOnExpectedPosition = AnotherPlayerIsOnExpectedPosition(); }
            catch (Exception) { }

            return firstPlayerOnExpectedPosition && secondPlayerOnExpectedPosition;
        }

        private bool MoveVectorIsDiagonal()
        {
            return Math.Abs(_moveVector.X) == Math.Abs(_moveVector.Y);
        }

        private bool WallIsOnDiagonalMovement(Vector2 moveVector)
        {
            return !_player.board.grid[(int)moveVector.X, (int)moveVector.Y].isEmpty;
        }
    }
}