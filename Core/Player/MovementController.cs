using System;
using System.Numerics;

namespace Quoridor.Core.Player
{
    public class MovementController
    {
        private Player _player;

        public MovementController(Player player)
        {
            _player = player;
        }

        public void ChangeCurrentPositionTileEmptyStatus(bool isEmpty)
        {
            int playerPositionX = (int)_player.position.X;
            int playerPositionY = (int)_player.position.Y;
            _player.board.grid[playerPositionX, playerPositionY].isEmpty = isEmpty;
        }

        public void Move(Vector2 moveVector)
        {
            try { MakeMove(moveVector); }
            catch (Exception) { RevertMove(moveVector); }
        }

        private void MakeMove(Vector2 moveVector)
        {
            ChangeCurrentPositionTileEmptyStatus(true);
            _player.position += moveVector;
            ChangeCurrentPositionTileEmptyStatus(false);
        }

        private void RevertMove(Vector2 moveVector)
        {
            if (_player.output != null)
                _player.output.DisplayEdgeMoveErrorMessage();
            _player.position -= moveVector;
            ChangeCurrentPositionTileEmptyStatus(false);
        }
    }
}