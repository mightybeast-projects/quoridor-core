using System;

namespace Quoridor.Core.PlayerLogic.Movement.Exceptions
{
    internal class WallOnTheWayException : Exception
    {
        public WallOnTheWayException()
            : base("Wall is on the way of movement.") {}
    }
}