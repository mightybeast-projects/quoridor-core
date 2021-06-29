using System;
using Quoridor.Core.Player;

namespace Quoridor.Terminal.Input
{
    public class ConsoleMovementHandler : InputHandler
    {
        public ConsoleMessageDisplay messageDisplay 
        { 
            get => _messageDisplay;
            internal set => _messageDisplay = value; 
        }

        private ConsoleMessageDisplay _messageDisplay;

        public ConsoleMovementHandler(Player player) : base(player) {}

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
            }
        }
    }
}