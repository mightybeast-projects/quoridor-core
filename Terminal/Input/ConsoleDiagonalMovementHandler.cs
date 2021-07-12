using System;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Terminal.Input
{
    public class ConsoleDiagonalMovementHandler : InputHandler
    {
        private ConsoleMessageDisplay _messageDisplay;

        public ConsoleDiagonalMovementHandler(ConsoleMessageDisplay messageDisplay, Player player) : base(player)
        {
            _messageDisplay = messageDisplay;
        }

        public override void HandleInput()
        {
            _messageDisplay.PrintDiagonalMovementMenu();
            _commandIndex = Convert.ToInt32(Console.ReadLine());

            switch (_commandIndex)
            {
                case 1:
                    _player.MoveDiagonallyTopRight();
                    break;
                case 2:
                    _player.MoveDiagonallyTopLeft();
                    break;
                case 3:
                    _player.MoveDiagonallyBottomRight();
                    break;
                case 4:
                    _player.MoveDiagonallyBottomLeft();
                    break;
            }
        }
    }
}