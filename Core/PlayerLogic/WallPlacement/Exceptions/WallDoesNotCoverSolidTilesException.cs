using System;
namespace Quoridor.Core.PlayerLogic.WallPlacement.Exceptions
{
    public class WallDoesNotCoverSolidTilesException : Exception
    {
        public WallDoesNotCoverSolidTilesException()
            : base("Wall does not line up with two walkable tiles.") {}
    }
}