using System;
using System.Numerics;

namespace Quoridor.Core.Player.Movement
{
    public class MovementController
    {
        public Vector2 position => _position;

        private Player _player;
        private Vector2 _newPosition;
        private Vector2 _position;
        private Vector2 _moveVector;
        private ExpectedPositionValidator _positionValidator;

        public MovementController(Player player)
        {
            _player = player;
            _positionValidator = new ExpectedPositionValidator(_player);
        }

        internal void SetPosition(int x, int y)
        {
            _newPosition = new Vector2(x, y);
            SetNewPosition();
        }

        internal void SetPosition(Vector2 newPosition)
        {
            _newPosition = newPosition;
            SetNewPosition();
        }

        internal void ChangeCurrentPositionTileEmptyStatus(bool isEmpty)
        {
            int playerPositionX = (int)_player.position.X;
            int playerPositionY = (int)_player.position.Y;
            _player.board.grid[playerPositionX, playerPositionY].isEmpty = isEmpty;
        }

        internal void Move(Vector2 moveVector)
        {
            _moveVector = moveVector;
            _positionValidator.CalculateExpectedPosition(_position, _moveVector);

            if (_positionValidator.ExpectedPositionDoesNotMeetRequirements()) return;

            SetPosition(_positionValidator.expectedPosition);
        }

        private void SetNewPosition()
        {
            if (PositionIsNotSolidTile((int) _newPosition.X, (int) _newPosition.Y))
                return;
            ChangeCurrentPositionTileEmptyStatus(true);
            _position = _newPosition;
            ChangeCurrentPositionTileEmptyStatus(false);
        }

        private bool PositionIsNotSolidTile(int x, int y)
        {
            return x % 2 != 0 || y % 2 != 0;
        }
    }
}