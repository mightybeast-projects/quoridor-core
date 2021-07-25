using System;
namespace Quoridor.Core.PlayerLogic.WallPlacement.Exceptions
{
    internal class WallDoesNotCoverSolidTilesException : Exception
    {
        public WallDoesNotCoverSolidTilesException()
            : base("Wall does not line up with two walkable tiles.") {}
    }
}