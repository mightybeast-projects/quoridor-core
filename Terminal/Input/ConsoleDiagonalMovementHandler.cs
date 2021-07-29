using Quoridor.Core.GameLogic;

namespace Quoridor.Terminal.Input
{
    public class ConsoleDiagonalMovementHandler : InputHandler
    {
        public ConsoleDiagonalMovementHandler(ConsoleMessageDisplay messageDisplay, Game game) : base(game)
        {
            PrintMenu = messageDisplay.PrintDiagonalMovementMenu;
            InitializeCommands();
        }

        protected sealed override void InitializeCommands()
        {
            _commandList.Add(() => _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DIAGONALLY_TOP_RIGHT));
            _commandList.Add(() => _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DIAGONALLY_TOP_LEFT));
            _commandList.Add(() => _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DIAGONALLY_BOTOM_RIGHT));
            _commandList.Add(() => _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DIAGONALLY_BOTTOM_LEFT));
        }
    }
}