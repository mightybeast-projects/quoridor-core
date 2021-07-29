using System;
using Quoridor.Core.GameLogic;
using Quoridor.Terminal.Input;

namespace Quoridor.Terminal
{
    public class ConsoleApp
    {
        private Game _game;
        private ConsoleDrawer _drawer;
        private ConsoleMessageDisplay _messageDisplay;
        private InputHandler _inputHandler;

        public ConsoleApp(Game game)
        {
            _game = game;
            _drawer = new ConsoleDrawer(game);
            _messageDisplay = new ConsoleMessageDisplay(game);
            _inputHandler = new ConsoleMainMenuHandler(_messageDisplay, _game);
        }
        
        public void Start()
        {
            while (true) { RunConsoleGame(); }
        }

        private void RunConsoleGame()
        {
            _drawer.DrawBoard();
            
            try { _inputHandler.HandleInput(); }
            catch (ArgumentOutOfRangeException) { _messageDisplay.DisplayIncorrectMenuItemMessage(); }
            catch (Exception e) { _messageDisplay.DisplayExceptionMessage(e); }
        }
    }
}