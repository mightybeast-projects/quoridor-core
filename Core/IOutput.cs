namespace Quoridor.Core
{
    public interface IOutput
    {
        void DisplayEdgeMoveErrorMessage();
        void DisplayWallIsTooLongMessage();
        void DisplayWallIsNotOnTheSameLine();
        void DisplayWallTilesHavePairCoordinates();
        void DisplayWallDoesNotCoverTwoSolidTiles();
    }
}