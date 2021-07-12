namespace Quoridor.Core.PlayerLogic.WallPlacement
{
    internal enum WallPlacementResult
    {
        SUCCESS,
        BEYOND_BOARD,
        USED_ALL_WALLS,
        NOT_ON_THE_SAME_LINE,
        TOO_LONG,
        HAVE_PAIR_COORDINATES,
        DOES_NOT_COVER_TWO_TILES,
        INTERCEPTS_WITH_OHER_WALL
    }
}