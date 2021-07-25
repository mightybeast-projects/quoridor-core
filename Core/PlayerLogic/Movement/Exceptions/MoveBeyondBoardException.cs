using System;

namespace Quoridor.Core.PlayerLogic.Movement.Exceptions
{
    internal class MoveBeyondBoardException : Exception
    {
        public MoveBeyondBoardException()
            : base("Can't move to the given direction. Expected position is beyond board.") {}
    }
}