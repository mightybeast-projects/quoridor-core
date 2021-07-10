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

            _expectedPositionX = (int)_expectedPosition.X;
            _expectedPositionY = (int)_expectedPosition.Y;
        }

        internal bool ExpectedPositionDoesNotMeetRequirements()
        {
            return CheckForBeyondBoardMovement() ||
                    CheckForPlayerOnTheWay() ||
                    CheckForWallOnTheWay() ||
                    CheckForWallBehindAnotherPlayer();
        }

        private bool CheckForBeyondBoardMovement()
        {
            if (ExpectedPositionIsBeyondTheBoard())
            {
                if (_player.output != null)
                    _player.output.DisplayCantMoveErrorMessage();
                return true;
            }
            return false;
        }

        private bool CheckForPlayerOnTheWay()
        {
            if (AnotherPlayerIsOnExpectedPosition())
                _expectedPosition = _currentPosition + _moveVector * 2;

            if (CheckForBeyondBoardMovement()) return true;

            return false;
        }

        private bool CheckForWallOnTheWay()
        {
            if (WallIsOnTheWay())
            {
                if (_player.output != null)
                    _player.output.DisplayWallIsOnTheWayMessage();
                return true;
            }
            return false;
        }

        private bool CheckForWallBehindAnotherPlayer()
        {
            if (WallIsBehindAnotherPlayer())
            {
                if (_player.output != null)
                    _player.output.DisplayWallIsBehindSecondPlayerMessage();
                return true;
            }
            return false;
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
            Vector2 wallBehindSecondPlayer = _currentPosition + _moveVector +_moveVector / 2;
            int wallX = (int) wallBehindSecondPlayer.X;
            int wallY = (int) wallBehindSecondPlayer.Y;
            Console.WriteLine(wallBehindSecondPlayer);
            
            try { return !_player.board.grid[wallX, wallY].isEmpty; } 
            catch (IndexOutOfRangeException) { return false; }
        }
    }
}