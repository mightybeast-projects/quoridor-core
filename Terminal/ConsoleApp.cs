using System;
using Quoridor.Core;
using Quoridor.Core.Player;
using Quoridor.Terminal.Input;

namespace Quoridor.Terminal
{
    public class ConsoleApp
    {
        private Board _board;
        private Player _player;
        private ConsoleDrawer _drawer;
        private ConsoleMessageDisplay _messageDisplay;
        private InputHandler _inputHandler;

        public ConsoleApp(Board board, Player player)
        {
            _board = board;
            _player = player;
            _drawer = new ConsoleDrawer(board, player);
            _messageDisplay = new ConsoleMessageDisplay();
            _inputHandler = new ConsoleMainMenuHandler(_messageDisplay, _player);

            _player.SetOutput(_messageDisplay);
        }
        
        public void Start()
        {
            while(true)
            {
                try { RunConsoleGame(); }
                catch (FormatException) { _messageDisplay.DisplayIncorrectMenuItemMessage(); }
            }
        }

        private void RunConsoleGame()
        {
            _drawer.DrawBoard();
            _messageDisplay.PrintConsoleMenu();
            _inputHandler.HandleInput();
        }
    }
}