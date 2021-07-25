using System;

namespace Quoridor.Core.PlayerLogic.WallPlacement.Exceptions
{
    internal class WallIsTooLongException : Exception
    {
        public WallIsTooLongException() : base("Wall is too long") {}
    }
}