using System;
namespace Quoridor.Core.PlayerLogic.WallPlacement.Exceptions
{
    internal class WallTilesHavePairCoordinatesException : Exception
    {
        public WallTilesHavePairCoordinatesException()
            : base("Wall covers walkable tile.") {}
    }
}