namespace Quoridor.Core.Output
{
    public interface IWallPlacementOutput
    {
        void DisplayNotEnoughWallsMessage();
        void DisplayWallIsTooLongMessage();
        void DisplayWallIsNotOnTheSameLineMessage();
        void DisplayWallTilesHavePairCoordinatesMessage();
        void DisplayWallDoesNotCoverTwoSolidTilesMessage();
        void DisplayWallInterceptsWithOtherWallMessage();
        void DisplayWallHasPositionBeyondBoardMessage();
    }
}