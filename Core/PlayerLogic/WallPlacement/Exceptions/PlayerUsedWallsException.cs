using System;

namespace Quoridor.Core.PlayerLogic.WallPlacement.Exceptions
{
    internal class PlayerUsedWallsException : Exception
    {
        public PlayerUsedWallsException() 
            : base("Not enough walls.") {}
    }
}