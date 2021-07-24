using System;

namespace Quoridor.Core.PlayerLogic.Movement.Exceptions
{
    public class JumpOverTwoPlayersException : Exception
    {
        public JumpOverTwoPlayersException() 
            : base("Cannot jump over two players.") { }
    }
}