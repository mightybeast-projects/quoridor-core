using System;
namespace Quoridor.Core.GameLogic
{
    internal class NoPathForPlayerException : Exception
    {
        public NoPathForPlayerException() : 
            base ("There is no path to goal for one of the players") { }
    }
}