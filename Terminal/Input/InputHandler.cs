using Quoridor.Core.GameLogic;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Terminal.Input
{
    public abstract class InputHandler
    {
        protected Game _game;
        protected int _commandIndex;

        public InputHandler(Game game)
        {
            _game = game;
        }

        public abstract void HandleInput();
    }
}