namespace Quoridor.Core
{
    public interface IOutput
    {
        void DisplayCantMoveErrorMessage();
        void DisplayPlacedAllAvailableWallsMessage();
        void DisplayWallIsTooLongMessage();
        void DisplayWallIsNotOnTheSameLine();
        void DisplayWallTilesHavePairCoordinates();
        void DisplayWallDoesNotCoverTwoSolidTiles();
        void DisplayWallInterceptsWithOtherWall();
        void DisplayWallIsOnTheWayMessage();
    }
}