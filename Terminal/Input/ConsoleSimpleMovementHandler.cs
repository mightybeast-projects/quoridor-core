using System;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Terminal.Input
{
    public class ConsoleSimpleMovementHandler : InputHandler
    {
        private ConsoleDiagonalMovementHandler _diagonalMovementHandler;
        private ConsoleMessageDisplay _messageDisplay;

        public ConsoleSimpleMovementHandler(ConsoleMessageDisplay messageDisplay, Player player) :
                base(player) 
        {
            _diagonalMovementHandler = new ConsoleDiagonalMovementHandler(messageDisplay, player);
            _messageDisplay = messageDisplay;
        }

        public override void HandleInput()
        {
            _messageDisplay.PrintMovePlayerMenu();
            _commandIndex = Convert.ToInt32(Console.ReadLine());

            switch (_commandIndex)
            {
                case 1:
                    _player.MoveUp();
                    break;
                case 2:
                    _player.MoveDown();
                    break;
                case 3:
                    _player.MoveRight();
                    break;
                case 4:
                    _player.MoveLeft();
                    break;
                case 5:
                    _diagonalMovementHandler.HandleInput();
                    break;
            }
        }
    }
}