using System;

namespace Quoridor.Core.PlayerLogic.WallPlacement.Exceptions
{
    internal class WallInterceptsWithOtherWallException : Exception
    {
        public WallInterceptsWithOtherWallException()
            : base("Wall intercepts with other wall.") {}
    }
}