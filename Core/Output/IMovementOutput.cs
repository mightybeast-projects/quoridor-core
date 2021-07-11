namespace Quoridor.Core.Output
{
    public interface IMovementOutput
    {
        void DisplayCantMoveErrorMessage();
        void DisplayCannotMoveDiagonallyMessage();
        void DisplayWallIsOnTheWayMessage();
        void DisplayWallIsBehindAnotherPlayerMessage();
    }
}