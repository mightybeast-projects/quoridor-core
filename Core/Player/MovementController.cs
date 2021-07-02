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
        private bool _wallIsOnTheWay;
        public MovementController(Player player)
        {
            _player = player;
        }

        internal void SetPosition(int x, int y)
        {
            ChangeCurrentPositionTileEmptyStatus(true);
            _position = new Vector2(x, y);
            ChangeCurrentPositionTileEmptyStatus(false);
        }

        internal void SetPosition(Vector2 newPosition)
        {
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

            try { CheckForWallOnTheWay(); }
            catch (Exception) { return; }

            if(_wallIsOnTheWay) return;
            
            try { MakeMove(); }
            catch (IndexOutOfRangeException) { RevertMove(); }
        }

        private void CheckForWallOnTheWay()
        {
            if(WallIsOnTheWay())
            {
                if(_player.output != null)
                    _player.output.DisplayWallIsOnTheWayMessage();
                _wallIsOnTheWay = true;
            }
        }

        private void MakeMove()
        {
            SetPosition(_position + _moveVector);
        }

        private void RevertMove()
        {
            if (_player.output != null)
                _player.output.DisplayEdgeMoveErrorMessage();
            _position -= _moveVector;
            ChangeCurrentPositionTileEmptyStatus(false);
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