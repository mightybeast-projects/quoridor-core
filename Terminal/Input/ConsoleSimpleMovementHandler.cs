using Quoridor.Core.GameLogic;

namespace Quoridor.Terminal.Input
{
    public class ConsoleSimpleMovementHandler : InputHandler
    {
        private ConsoleDiagonalMovementHandler _diagonalMovementHandler;

        public ConsoleSimpleMovementHandler(ConsoleMessageDisplay messageDisplay, Game game) :
                base(game) 
        {
            _diagonalMovementHandler = new ConsoleDiagonalMovementHandler(messageDisplay, game);

            PrintMenu = messageDisplay.PrintMovePlayerMenu;
            InitializeCommands();
        }

        protected sealed override void InitializeCommands()
        {
            _commandList.Add(() => _game.MakeCurrentPlayerMove(PlayerMove.MOVE_UP));
            _commandList.Add(() => _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DOWN));
            _commandList.Add(() => _game.MakeCurrentPlayerMove(PlayerMove.MOVE_RIGHT));
            _commandList.Add(() => _game.MakeCurrentPlayerMove(PlayerMove.MOVE_LEFT));
            _commandList.Add(() => _diagonalMovementHandler.HandleInput());
        }
    }
}