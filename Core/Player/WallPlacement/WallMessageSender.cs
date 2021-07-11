namespace Quoridor.Core.Player.WallPlacement
{
    public class WallMessageSender
    {
        private Player _player;

        public WallMessageSender(Player player)
        {
            _player = player;
        }

        internal void SendAppropriateMessage(WallPlacementResult result)
        {
            switch (result)
            {
                case WallPlacementResult.BEYOND_BOARD :
                    _player.output?.DisplayWallHasPositionBeyondBoardMessage();
                break;
                case WallPlacementResult.PLAYER_USED_ALL_WALLS :
                    _player.output?.DisplayNotEnoughWallsMessage();
                break;
                case WallPlacementResult.NOT_ON_THE_SAME_LINE :
                    _player.output?.DisplayWallIsNotOnTheSameLineMessage();
                break;
                case WallPlacementResult.TOO_LONG :
                    _player.output?.DisplayWallIsTooLongMessage();
                break;
                case WallPlacementResult.HAVE_PAIR_COORDINATES :
                    _player.output?.DisplayWallTilesHavePairCoordinatesMessage();
                break;
                case WallPlacementResult.DOES_NOT_COVER_TWO_TILES :
                    _player.output?.DisplayWallDoesNotCoverTwoSolidTilesMessage();
                break;
                case WallPlacementResult.INTERCEPTS_WITH_OHER_WALL :
                    _player.output?.DisplayWallInterceptsWithOtherWallMessage();
                break;
            }
        }
    }
}