using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic.Handler
{
    internal abstract class GameHandler
    {
        internal Player currentPlayer
        {
            get => _currentPlayer;
            set => _currentPlayer = value;
        }

        protected Player _currentPlayer;
    }
}