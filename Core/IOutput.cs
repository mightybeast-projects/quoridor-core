namespace Quoridor.Core
{
    public interface IOutput
    {
        void DisplayEdgeMoveErrorMessage();
        void DisplayPlacedAllAvailableWallsMessage();
        void DisplayWallIsTooLongMessage();
        void DisplayWallIsNotOnTheSameLine();
        void DisplayWallTilesHavePairCoordinates();
        void DisplayWallDoesNotCoverTwoSolidTiles();
        void DisplayWallInterceptsWithOtherWall();
        void DisplayWallIsOnTheWayMessage();
    }
}