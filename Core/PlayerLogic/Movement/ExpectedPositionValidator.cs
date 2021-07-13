using System;
using System.Numerics;
using Quoridor.Core.PlayerLogic.Movement.Exceptions;

namespace Quoridor.Core.PlayerLogic.Movement
{
    public class ExpectedPositionValidator
    {
        public Vector2 expectedPosition => _expectedPosition;

        private Player _player;
        private Vector2 _currentPosition;
        private Vector2 _moveVector;
        private Vector2 _expectedPosition;
        private int _expectedPositionX;
        private int _expectedPositionY;

        public ExpectedPositionValidator(Player player)
        {
            _player = player;
        }

        internal void CalculateExpectedPosition(Vector2 currentPosition, Vector2 moveVector)
        {
            _currentPosition = currentPosition;
            _moveVector = moveVector;
            _expectedPosition = _currentPosition + _moveVector;

            InitializeCoordinates();
        }

        internal void CheckExpectedPositionRequirements()
        {
            if (ExpectedPositionIsBeyondTheBoard())
                throw new MoveBeyondBoardException();
            if (WallIsOnTheWay())
                throw new WallOnTheWayException();
            if (WallIsBehindAnotherPlayer())
                throw new WallBehindAnotherPlayerException();
            
            if (MoveIsDiagonalButPlayerCannotMoveDiagonally())
                throw new CannotMoveDiagonallyException();
            if (MoveIsDiagonalAndPlayerCanMoveDiagonally())
                return;

            if (AnotherPlayerIsOnExpectedPosition())
            {
                _expectedPosition = _currentPosition + _moveVector * 2;

                if (ExpectedPositionIsBeyondTheBoard())
                    throw new MoveBeyondBoardException();
            }
        }

        private void InitializeCoordinates()
        {
            _expectedPositionX = (int)_expectedPosition.X;
            _expectedPositionY = (int)_expectedPosition.Y;
        }

        internal bool MoveIsDiagonalButPlayerCannotMoveDiagonally()
        {
            return MoveVectorIsDiagonal() && !PlayerCanMoveDiagonally();
        }

        internal bool MoveIsDiagonalAndPlayerCanMoveDiagonally()
        {
            return MoveVectorIsDiagonal() && PlayerCanMoveDiagonally();
        }

        private bool PlayerCanMoveDiagonally()
        {
            Vector2 expectedPositionTmp = _expectedPosition;
            Vector2 moveVectorTmp = _moveVector;

            bool firstTileHavePlayerAndWallBehind = 
                CheckExpectedPositionForPlayerAndWallBehind(new Vector2(0, moveVectorTmp.Y));
            bool secondTileHavePlayerAndWallBehind = 
                CheckExpectedPositionForPlayerAndWallBehind(new Vector2(moveVectorTmp.X, 0));

            bool wallIsOnFirstDiagonalMove = 
                WallIsOnDiagonalMovement(
                    _currentPosition + new Vector2(moveVectorTmp.X / 2, moveVectorTmp.Y));
            bool wallIsOnSecondDiagonalMove = 
                WallIsOnDiagonalMovement(
                    _currentPosition + new Vector2(moveVectorTmp.X, moveVectorTmp.Y / 2));

            _expectedPosition = expectedPositionTmp;
            _moveVector = moveVectorTmp;

            return (firstTileHavePlayerAndWallBehind && !wallIsOnFirstDiagonalMove) || 
                    (secondTileHavePlayerAndWallBehind && !wallIsOnSecondDiagonalMove);
        }

        private bool CheckExpectedPositionForPlayerAndWallBehind(Vector2 moveVector)
        {
            CalculateExpectedPosition(_currentPosition, moveVector);

            return AnotherPlayerIsOnExpectedPosition() && 
                    WallIsBehindAnotherPlayer();
        }

        private bool ExpectedPositionIsBeyondTheBoard()
        {
            return _expectedPosition.X > 16 || _expectedPosition.Y > 16 ||
                    _expectedPosition.X < 0 || _expectedPosition.Y < 0;
        }

        private bool AnotherPlayerIsOnExpectedPosition()
        {
            return !_player.board.grid[_expectedPositionX, _expectedPositionY].isEmpty;
        }

        private bool WallIsOnDiagonalMovement(Vector2 moveVector)
        {
            return !_player.board.grid[(int) moveVector.X, (int) moveVector.Y].isEmpty;
        }

        private bool WallIsOnTheWay()
        {
            Vector2 wallCheckVector = new Vector2(_moveVector.X / 2, _moveVector.Y / 2);
            int wallPositionX = (int)(wallCheckVector.X + _currentPosition.X);
            int wallPositionY = (int)(wallCheckVector.Y + _currentPosition.Y);

            return !_player.board.grid[wallPositionX, wallPositionY].isEmpty;
        }

        private bool WallIsBehindAnotherPlayer()
        {
            Vector2 wallBehindSecondPlayer = _currentPosition + _moveVector + _moveVector / 2;
            int wallX = (int) wallBehindSecondPlayer.X;
            int wallY = (int) wallBehindSecondPlayer.Y;
            
            try { return !_player.board.grid[wallX, wallY].isEmpty; }
            catch (IndexOutOfRangeException) { return false; }
        }
        internal bool MoveVectorIsDiagonal()
        {
            return Math.Abs(_moveVector.X) == Math.Abs(_moveVector.Y);
        }
    }
}