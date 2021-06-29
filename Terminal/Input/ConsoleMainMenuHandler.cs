using System;
using Quoridor.Core.Player;

namespace Quoridor.Terminal.Input
{
    public class ConsoleMainMenuHandler : InputHandler
    {
        public ConsoleMessageDisplay messageDisplay
        {
            get => _messageDisplay;
            internal set => _messageDisplay = value;
        }

        private ConsoleMovementHandler _movementHandler;
        private ConsoleWallPlacementHandler _wallPlacementHandler;

        private ConsoleMessageDisplay _messageDisplay;
        public ConsoleMainMenuHandler(ConsoleMessageDisplay messageDisplay, Player player) : base(player)
        {
            _movementHandler = new ConsoleMovementHandler(_player);
            _wallPlacementHandler = new ConsoleWallPlacementHandler(_player);

            _movementHandler.messageDisplay = messageDisplay;
        }

        public override void HandleInput()
        {
            _commandIndex = Convert.ToInt32(Console.ReadLine());

            if (_commandIndex == 1)
                _movementHandler.HandleInput();
            if (_commandIndex == 2)
                _wallPlacementHandler.HandleInput();
        }
    }
}