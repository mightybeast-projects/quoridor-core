using System;
namespace Quoridor.Core.PlayerLogic.WallPlacement.Exceptions
{
    public class PlayerUsedWallsException : Exception
    {
        public PlayerUsedWallsException() 
            : base("Not enough walls.") {}
    }
}