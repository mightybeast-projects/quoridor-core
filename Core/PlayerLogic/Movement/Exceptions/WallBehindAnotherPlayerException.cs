using System;
namespace Quoridor.Core.PlayerLogic.Movement.Exceptions
{
    public class WallBehindAnotherPlayerException : Exception
    {
        public WallBehindAnotherPlayerException()
            : base("There is a wall behind another player on the way.") {}
    }
}