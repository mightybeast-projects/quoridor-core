using System;
using System.Numerics;

namespace Quoridor.Core.PlayerLogic.Movement
{
    public abstract class ExpectedPositionValidator
    {
        protected Player _player;
        protected Vector2 _currentPosition;
        protected Vector2 _moveVector;
        protected Vector2 _expectedPosition;
        protected int _expectedPositionX;
        protected int _expectedPositionY;
        protected ExpectedPositionValidator(Player player)
        {
            _player = player;
        }

        internal virtual void CalculateExpectedPosition(Vector2 currentPosition, Vector2 moveVector)
        {
            _currentPosition = currentPosition;
            _moveVector = moveVector;
            _expectedPosition = _currentPosition + _moveVector;

            InitializeExpectedPositionCoordinates();
        }

        protected bool WallIsBehindAnotherPlayer()
        {
            Vector2 wallBehindSecondPlayer = _currentPosition + _moveVector + _moveVector / 2;
            int wallX = (int) wallBehindSecondPlayer.X;
            int wallY = (int) wallBehindSecondPlayer.Y;
            
            try { return !_player.board.grid[wallX, wallY].isEmpty; }
            catch (IndexOutOfRangeException) { return false; }
        }

        protected void InitializeExpectedPositionCoordinates()
        {
            _expectedPositionX = (int)_expectedPosition.X;
            _expectedPositionY = (int)_expectedPosition.Y;
        }

        protected bool ExpectedPositionIsBeyondTheBoard()
        {
            return _expectedPosition.X > 16 || _expectedPosition.Y > 16 ||
                    _expectedPosition.X < 0 || _expectedPosition.Y < 0;
        }

        protected bool AnotherPlayerIsOnExpectedPosition()
        {
            return !_player.board.grid[_expectedPositionX, _expectedPositionY].isEmpty;
        }
    }
}