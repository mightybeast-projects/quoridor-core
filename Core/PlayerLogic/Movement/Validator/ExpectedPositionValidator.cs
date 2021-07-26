using System;
using System.Numerics;

namespace Quoridor.Core.PlayerLogic.Movement.Validator
{
    public abstract class ExpectedPositionValidator
    {
        protected Player _player;
        protected Vector2 _currentPosition;
        protected Vector2 _moveVector;
        protected Vector2 _expectedPosition;
        protected int _expectedPositionX;
        protected int _expectedPositionY;
        private Vector2 _wallBehindSecondPlayer;
        private int _wallX;
        private int _wallY;

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
            _wallBehindSecondPlayer = _currentPosition + _moveVector + _moveVector / 2;
            _wallX = (int)_wallBehindSecondPlayer.X;
            _wallY = (int)_wallBehindSecondPlayer.Y;

            try { return !_player.board.grid[_wallX, _wallY].isEmpty; }
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