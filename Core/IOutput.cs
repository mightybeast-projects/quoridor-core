namespace Quoridor.Core
{
    public interface IOutput
    {
        void DisplayCantMoveErrorMessage();
        void DisplayNotEnoughWallsMessage();
        void DisplayWallIsTooLongMessage();
        void DisplayWallIsNotOnTheSameLineMessage();
        void DisplayWallTilesHavePairCoordinatesMessage();
        void DisplayWallDoesNotCoverTwoSolidTilesMessage();
        void DisplayWallInterceptsWithOtherWallMessage();
        void DisplayWallIsOnTheWayMessage();
        void DisplayWallHasPositionBeyondBoardMessage();
        void DisplayWallIsBehindAnotherPlayerMessage();
    }
}