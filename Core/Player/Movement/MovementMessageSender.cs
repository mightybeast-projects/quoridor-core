using System;

namespace Quoridor.Core.Player.Movement
{
    public class MovementMessageSender
    {
        private Player _player;

        public MovementMessageSender(Player player)
        {
            _player = player;
        }

        internal void SendAppropriateMessage(MovementResult result)
        {
            switch (result)
            {
                case MovementResult.MOVE_BEYOND_BOARD :
                    _player.output?.DisplayCantMoveErrorMessage();
                break;
                case MovementResult.WALL_ON_THE_WAY :
                    _player.output?.DisplayWallIsOnTheWayMessage();
                break;
                case MovementResult.CANNOT_MOVE_DIAGONALLY :
                    _player.output?.DisplayCannotMoveDiagonallyMessage();
                break;
                case MovementResult.WALL_BEHIND_ANOTHER_PLAYER :
                    _player.output?.DisplayWallIsBehindAnotherPlayerMessage();
                break;
            }
        }
    }
}