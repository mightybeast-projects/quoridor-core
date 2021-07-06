namespace Quoridor.Core
{
    public interface IOutput
    {
        void DisplayCantMoveErrorMessage();
        void DisplayNotEnoughWallsMessage();
        void DisplayWallIsTooLongMessage();
        void DisplayWallIsNotOnTheSameLine();
        void DisplayWallTilesHavePairCoordinates();
        void DisplayWallDoesNotCoverTwoSolidTiles();
        void DisplayWallInterceptsWithOtherWall();
        void DisplayWallIsOnTheWayMessage();
    }
}