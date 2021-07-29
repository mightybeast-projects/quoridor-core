using System;

namespace Quoridor.Core.PlayerLogic.WallPlacement.Exceptions
{
    internal class WallIsBeyondBoardException : Exception
    {
        public WallIsBeyondBoardException() : base("Wall position is beyond board.") {}
    }
}