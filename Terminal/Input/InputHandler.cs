using Quoridor.Core.PlayerLogic;

namespace Quoridor.Terminal.Input
{
    public abstract class InputHandler
    {
        protected Player _player;
        protected int _commandIndex;

        public InputHandler(Player player)
        {
            _player = player;
        }

        public abstract void HandleInput();
    }
}