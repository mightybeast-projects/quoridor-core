using System;
namespace Quoridor.Core.PlayerLogic.WallPlacement.Exceptions
{
    internal class WallIsNotOnTheSameLineException : Exception
    {
        public WallIsNotOnTheSameLineException()
            : base("Wall is not on the same line. Walls can be placed in horizontal or vertical direction.") {}
    }
}