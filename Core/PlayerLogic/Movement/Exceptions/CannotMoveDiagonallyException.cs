using System;
namespace Quoridor.Core.PlayerLogic.Movement.Exceptions
{
    public class CannotMoveDiagonallyException : Exception
    {
        public CannotMoveDiagonallyException()
            : base("Cannot move diagonally.") {}
    }
}