namespace Quoridor.Core.Player.Movement
{
    internal enum MovementResult
    {
        SUCCESS,
        MOVE_BEYOND_BOARD,
        WALL_ON_THE_WAY,
        WALL_BEHIND_ANOTHER_PLAYER,
    }
}