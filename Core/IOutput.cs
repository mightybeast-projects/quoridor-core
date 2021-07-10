namespace Quoridor.Core
{
    public interface IOutput
    {
        void DisplayCantMoveErrorMessage();
        void DisplayCannotMoveDiagonallyMessage();
        void DisplayWallIsOnTheWayMessage();
        void DisplayWallIsBehindAnotherPlayerMessage();

        void DisplayNotEnoughWallsMessage();
        void DisplayWallIsTooLongMessage();
        void DisplayWallIsNotOnTheSameLineMessage();
        void DisplayWallTilesHavePairCoordinatesMessage();
        void DisplayWallDoesNotCoverTwoSolidTilesMessage();
        void DisplayWallInterceptsWithOtherWallMessage();
        void DisplayWallHasPositionBeyondBoardMessage();
    }
}