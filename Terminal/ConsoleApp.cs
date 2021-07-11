using System;
using System.Collections.Generic;
using Quoridor.Core;
using Quoridor.Core.Player;
using Quoridor.Terminal.Input;

namespace Quoridor.Terminal
{
    public class ConsoleApp
    {
        private Board _board;
        private List<Player> _players;
        private ConsoleDrawer _drawer;
        private ConsoleMessageDisplay _messageDisplay;
        private InputHandler _inputHandler;

        public ConsoleApp(Board board, List<Player> players)
        {
            _board = board;
            _players = players;
            _drawer = new ConsoleDrawer(board, _players);
            _messageDisplay = new ConsoleMessageDisplay();
            _inputHandler = new ConsoleMainMenuHandler(_messageDisplay, _players[0]);

            foreach(Player player in _players)
                player.SetOutput(_messageDisplay);
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
            _inputHandler.HandleInput();
        }
    }
}