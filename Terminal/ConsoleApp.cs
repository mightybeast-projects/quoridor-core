using System;
using System.Collections.Generic;
using Quoridor.Core;
using Quoridor.Core.GameLogic;
using Quoridor.Core.PlayerLogic;
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

            foreach(Player player in _game.players)
                player.SetOutput(_messageDisplay);
        }
        
        public void Start()
        {
            while(true) { RunConsoleGame(); }
        }

        private void RunConsoleGame()
        {
            _drawer.DrawBoard();
            
            try { _inputHandler.HandleInput(); }
            catch (FormatException) { _messageDisplay.DisplayIncorrectMenuItemMessage(); }
        }
    }
}