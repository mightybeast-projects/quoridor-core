using System;
using Quoridor.Core.GameLogic;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Terminal.Input
{
    public class ConsoleSimpleMovementHandler : InputHandler
    {
        private ConsoleDiagonalMovementHandler _diagonalMovementHandler;
        private ConsoleMessageDisplay _messageDisplay;

        public ConsoleSimpleMovementHandler(ConsoleMessageDisplay messageDisplay, Game game) :
                base(game) 
        {
            _diagonalMovementHandler = new ConsoleDiagonalMovementHandler(messageDisplay, game);
            _messageDisplay = messageDisplay;
        }

        public override void HandleInput()
        {
            _messageDisplay.PrintMovePlayerMenu();
            _commandIndex = Convert.ToInt32(Console.ReadLine());

            switch (_commandIndex)
            {
                case 1:
                    _game.MakeCurrentPlayerMove(PlayerMove.MOVE_UP);
                    break;
                case 2:
                    _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DOWN);
                    break;
                case 3:
                    _game.MakeCurrentPlayerMove(PlayerMove.MOVE_RIGHT);
                    break;
                case 4:
                    _game.MakeCurrentPlayerMove(PlayerMove.MOVE_LEFT);
                    break;
                case 5:
                    _diagonalMovementHandler.HandleInput();
                    break;
            }
        }
    }
}