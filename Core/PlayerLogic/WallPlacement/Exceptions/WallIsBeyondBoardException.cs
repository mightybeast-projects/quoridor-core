using System;
namespace Quoridor.Core.PlayerLogic.WallPlacement.Exceptions
{
    public class WallIsBeyondBoardException : Exception
    {
        public WallIsBeyondBoardException() : base("Wall position is beyond board."){}
    }
}