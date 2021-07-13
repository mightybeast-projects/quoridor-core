using System;
namespace Quoridor.Core.PlayerLogic.WallPlacement.Exceptions
{
    public class WallTilesHavePairCoordinatesException : Exception
    {
        public WallTilesHavePairCoordinatesException()
            : base("Wall covers walkable tile.") {}
    }
}