using Quoridor.Core.GameLogic;

namespace Quoridor.Terminal.Input
{
    public class ConsoleMainMenuHandler : InputHandler
    {
        private ConsoleSimpleMovementHandler _simpleMovementHandler;
        private ConsoleWallPlacementHandler _wallPlacementHandler;

        public ConsoleMainMenuHandler(ConsoleMessageDisplay messageDisplay, Game game) : 
                base(game)
        {
            _simpleMovementHandler = 
                new ConsoleSimpleMovementHandler(messageDisplay, game);
            _wallPlacementHandler = new ConsoleWallPlacementHandler(game);

            PrintMenu = () => messageDisplay.PrintConsoleMenu();
        }

        protected override void InitializeCommands()
        {
            base.InitializeCommands();
            _commandList.Add(() => _simpleMovementHandler.HandleInput());
            _commandList.Add(() => _wallPlacementHandler.HandleInput());
        }
    }
}