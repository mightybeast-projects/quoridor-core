using System;
namespace Quoridor.Core.GameLogic
{
    public class NoPathForPlayerException : Exception
    {
        public NoPathForPlayerException() : 
            base ("There is no path to goal for one of the players") { }
    }
}