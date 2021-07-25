using System;
namespace Quoridor.Core.PlayerLogic.Movement.Exceptions
{
    internal class CannotMoveDiagonallyException : Exception
    {
        public CannotMoveDiagonallyException()
            : base("Cannot move diagonally.") {}
    }
}