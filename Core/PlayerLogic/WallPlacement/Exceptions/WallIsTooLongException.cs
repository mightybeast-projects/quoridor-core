using System;

namespace Quoridor.Core.PlayerLogic.WallPlacement.Exceptions
{
    public class WallIsTooLongException : Exception
    {
        public WallIsTooLongException() : base("Wall is too long") {}
    }
}