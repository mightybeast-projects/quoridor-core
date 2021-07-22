using System;
namespace Quoridor.Core.GameLogic
{
    public class NoPathForOtherPlayerException : Exception
    {
        public NoPathForOtherPlayerException() : 
            base ("There is no path to goal for another player") { }
    }
}