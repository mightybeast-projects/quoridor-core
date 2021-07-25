using System.Numerics;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic.Handler
{
    internal class PlayerMovementHandler : GameHandler
    {
        private Vector2 _previousPosition;

        internal bool HandlePlayerMove(PlayerMove playerMove)
        {
            _previousPosition = _currentPlayer.position;

            ChooseMove(playerMove);

            if (PlayerMadeWrongMove())
                return false;
            else
                return true;
        }

        private void ChooseMove(PlayerMove playerMove)
        {
            switch (playerMove)
            {
                case PlayerMove.MOVE_UP:
                    _currentPlayer.MoveUp();
                    break;
                case PlayerMove.MOVE_DOWN:
                    _currentPlayer.MoveDown();
                    break;
                case PlayerMove.MOVE_RIGHT:
                    _currentPlayer.MoveRight();
                    break;
                case PlayerMove.MOVE_LEFT:
                    _currentPlayer.MoveLeft();
                    break;
                case PlayerMove.MOVE_DIAGONALLY_TOP_RIGHT:
                    _currentPlayer.MoveDiagonallyTopRight();
                    break;
                case PlayerMove.MOVE_DIAGONALLY_TOP_LEFT:
                    _currentPlayer.MoveDiagonallyTopLeft();
                    break;
                case PlayerMove.MOVE_DIAGONALLY_BOTOM_RIGHT:
                    _currentPlayer.MoveDiagonallyBottomRight();
                    break;
                case PlayerMove.MOVE_DIAGONALLY_BOTTOM_LEFT:
                    _currentPlayer.MoveDiagonallyBottomLeft();
                    break;
            }
        }

        private bool PlayerMadeWrongMove()
        {
            return _currentPlayer.position == _previousPosition;
        }
    }
}