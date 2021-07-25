using System;
namespace Quoridor.Core.PlayerLogic.Movement.Exceptions
{
    internal class WallBehindAnotherPlayerException : Exception
    {
        public WallBehindAnotherPlayerException()
            : base("There is a wall behind another player on the way.") {}
    }
}