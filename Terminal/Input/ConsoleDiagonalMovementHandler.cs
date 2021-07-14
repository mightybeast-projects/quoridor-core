using System;
using Quoridor.Core.GameLogic;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Terminal.Input
{
    public class ConsoleDiagonalMovementHandler : InputHandler
    {
        private ConsoleMessageDisplay _messageDisplay;

        public ConsoleDiagonalMovementHandler(ConsoleMessageDisplay messageDisplay, Game game) : base(game)
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
                    _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DIAGONALLY_TOP_RIGHT);
                    break;
                case 2:
                    _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DIAGONALLY_TOP_LEFT);
                    break;
                case 3:
                    _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DIAGONALLY_BOTOM_RIGHT);
                    break;
                case 4:
                    _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DIAGONALLY_BOTTOM_LEFT);
                    break;
            }
        }
    }
}