using System;
using System.Numerics;

namespace Quoridor.Core.Player
{
    public class MovementController
    {
        public Vector2 position => _position;

        private Player _player;
        private Vector2 _position;
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
            try { MakeMove(moveVector); }
            catch (Exception) { RevertMove(moveVector); }
        }

        private void MakeMove(Vector2 moveVector)
        {
            ChangeCurrentPositionTileEmptyStatus(true);
            _position += moveVector;
            ChangeCurrentPositionTileEmptyStatus(false);
        }

        private void RevertMove(Vector2 moveVector)
        {
            if (_player.output != null)
                _player.output.DisplayEdgeMoveErrorMessage();
            _position -= moveVector;
            ChangeCurrentPositionTileEmptyStatus(false);
        }
    }
}