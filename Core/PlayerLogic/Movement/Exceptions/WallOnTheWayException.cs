using System;

namespace Quoridor.Core.PlayerLogic.Movement.Exceptions
{
    public class WallOnTheWayException : Exception
    {
        public WallOnTheWayException()
            : base("Wall is on the way of movement.") {}
    }
}