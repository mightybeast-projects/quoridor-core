using System;
namespace Quoridor.Core.PlayerLogic.WallPlacement.Exceptions
{
    public class WallInterceptsWithOtherWallException : Exception
    {
        public WallInterceptsWithOtherWallException()
            : base("Wall intercepts with other wall.") {}
    }
}