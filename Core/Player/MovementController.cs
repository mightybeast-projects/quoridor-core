using System;
using System.Numerics;

namespace Quoridor.Core.Player
{
    public class MovementController
    {
        public Vector2 position => _position;

        private Player _player;
        private Vector2 _position;
        private Vector2 _moveVector;
        private Vector2 _expectedPosition;
        private int _expectedPositionX;
        private int _expectedPositionY;
        private bool _wallIsOnTheWay;
        public MovementController(Player player)
        {
            _player = player;
        }

        internal void SetPosition(int x, int y)
        {
            if (PositionIsNotSolidTile(x, y))
                return;
            ChangeCurrentPositionTileEmptyStatus(true);
            _position = new Vector2(x, y);
            ChangeCurrentPositionTileEmptyStatus(false);
        }

        internal void SetPosition(Vector2 newPosition)
        {
            if (PositionIsNotSolidTile((int) newPosition.X, (int) newPosition.Y)) 
                return;
            ChangeCurrentPositionTileEmptyStatus(true);
            _position = newPosition;
            ChangeCurrentPositionTileEmptyStatus(false);
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

            CalculateExpectedPosition();

            if (ExpectedPositionDoesNotMeetRequirements()) return;

            MakeMove();
        }

        private bool ExpectedPositionDoesNotMeetRequirements()
        {
            return CheckForExpectedPosition() || CheckForPlayerOnTheWay() || CheckForWallOnTheWay();
        }

        private void CalculateExpectedPosition()
        {
            _expectedPosition = _position + _moveVector;

            _expectedPositionX = (int)_expectedPosition.X;
            _expectedPositionY = (int)_expectedPosition.Y;
        }

        private bool CheckForPlayerOnTheWay()
        {
            if (AnotherPlayerIsOnExpectedPosition())
                _expectedPosition = _position + _moveVector * 2;

            if (CheckForExpectedPosition()) return true;

            return false;
        }

        private bool CheckForExpectedPosition()
        {
            if (ExpectedPositionIsBeyondTheBoard())
            {
                if (_player.output != null)
                    _player.output.DisplayCantMoveErrorMessage();
                return true;
            }
            return false;
        }

        private bool ExpectedPositionIsBeyondTheBoard()
        {
            return _expectedPosition.X > 16 || _expectedPosition.Y > 16 || 
                    _expectedPosition.X < 0 || _expectedPosition.Y < 0;
        }

        private static bool PositionIsNotSolidTile(int x, int y)
        {
            return x % 2 != 0 || y % 2 != 0;
        }

        private bool CheckForWallOnTheWay()
        {
            if(WallIsOnTheWay())
            {
                if(_player.output != null)
                    _player.output.DisplayWallIsOnTheWayMessage();
                return true;
            }
            return false;
        }

        private void MakeMove()
        {
            SetPosition(_expectedPosition);
        }

        private bool AnotherPlayerIsOnExpectedPosition()
        {
            return !_player.board.grid[_expectedPositionX, _expectedPositionY].isEmpty;
        }

        private bool WallIsOnTheWay()
        {
            Vector2 wallCheckVector = new Vector2(_moveVector.X / 2, _moveVector.Y / 2);
            int wallPositionX = (int) (wallCheckVector.X + _position.X);
            int wallPositionY = (int) (wallCheckVector.Y + _position.Y);

            return !_player.board.grid[wallPositionX, wallPositionY].isEmpty;
        }
    }
}