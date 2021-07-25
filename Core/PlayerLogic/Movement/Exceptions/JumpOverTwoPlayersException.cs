using System;

namespace Quoridor.Core.PlayerLogic.Movement.Exceptions
{
    internal class JumpOverTwoPlayersException : Exception
    {
        public JumpOverTwoPlayersException() 
            : base("Cannot jump over two players.") { }
    }
}