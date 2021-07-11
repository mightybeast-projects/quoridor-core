using System;
using System.Numerics;

namespace Quoridor.Core.Player.Movement
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

        private void InitializeCoordinates()
        {
            _expectedPositionX = (int)_expectedPosition.X;
            _expectedPositionY = (int)_expectedPosition.Y;
        }

        internal MovementResult CheckExpectedPositionRequirements()
        {
            if (ExpectedPositionIsBeyondTheBoard())
                return MovementResult.MOVE_BEYOND_BOARD;
            if (WallIsOnTheWay())
                return MovementResult.WALL_ON_THE_WAY;
            if (WallIsBehindAnotherPlayer())
                return MovementResult.WALL_BEHIND_ANOTHER_PLAYER;
            
            if (MoveIsDiagonalButPlayerCannotMoveDiagonally())
                return MovementResult.CANNOT_MOVE_DIAGONALLY;
            if (MoveIsDiagonalAndPlayerCanMoveDiagonally())
                return MovementResult.SUCCESS;

            if (AnotherPlayerIsOnExpectedPosition())
            {
                _expectedPosition = _currentPosition + _moveVector * 2;
                if (ExpectedPositionIsBeyondTheBoard())
                    return MovementResult.MOVE_BEYOND_BOARD;
            }

            return MovementResult.SUCCESS;
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

            CalculateExpectedPosition(_currentPosition, new Vector2(0, moveVectorTmp.Y));
            bool firstTileHavePlayerAndWallBehind = 
                AnotherPlayerIsOnExpectedPosition() && WallIsBehindAnotherPlayer();
            CalculateExpectedPosition(_currentPosition, new Vector2(moveVectorTmp.X, 0));
            bool secondTileHavePlayerAndWallBehind = 
                AnotherPlayerIsOnExpectedPosition() && WallIsBehindAnotherPlayer();

            _expectedPosition = expectedPositionTmp;
            _moveVector = moveVectorTmp;

            return firstTileHavePlayerAndWallBehind || secondTileHavePlayerAndWallBehind;
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