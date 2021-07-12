using System;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Terminal.Input
{
    public class ConsoleMainMenuHandler : InputHandler
    {
        private ConsoleSimpleMovementHandler _simpleMovementHandler;
        private ConsoleWallPlacementHandler _wallPlacementHandler;
        private ConsoleMessageDisplay _messageDisplay;
        
        public ConsoleMainMenuHandler(ConsoleMessageDisplay messageDisplay, Player player) : 
                base(player)
        {
            _simpleMovementHandler = 
                new ConsoleSimpleMovementHandler(messageDisplay, _player);
            _wallPlacementHandler = new ConsoleWallPlacementHandler(_player);

            _messageDisplay = messageDisplay;
        }

        public override void HandleInput()
        {
            _messageDisplay.PrintConsoleMenu();
            _commandIndex = Convert.ToInt32(Console.ReadLine());

            if (_commandIndex == 1)
                _simpleMovementHandler.HandleInput();
            if (_commandIndex == 2)
                _wallPlacementHandler.HandleInput();
        }
    }
}