using System;
using System.Numerics;
using Quoridor.Core;
using Quoridor.Core.Player;
using Quoridor.Terminal.ConsoleInputHandler;

namespace Quoridor.Terminal
{
    public class ConsoleApp
    {
        
        private Board _board;
        private Player _player;
        private ConsoleDrawer _drawer;
        private ConsoleMessageDisplay _messageDisplay;
        private ConsoleMovementHandler _movementHandler;
        private ConsoleWallPlacementHandler _wallPlacementHandler;

        public ConsoleApp(Board board, Player player)
        {
            _board = board;
            _player = player;
            _drawer = new ConsoleDrawer(board, player);
            _messageDisplay = new ConsoleMessageDisplay();
            _movementHandler = new ConsoleMovementHandler(_player);
            _wallPlacementHandler = new ConsoleWallPlacementHandler(_player);

            _player.SetOutput(_messageDisplay);
            _movementHandler.messageDisplay = _messageDisplay;
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
            HandleConsoleInput();
        }

        private void HandleConsoleInput()
        {
            int commandIndex = Convert.ToInt32(Console.ReadLine());

            if(commandIndex == 1)
                _movementHandler.HandleInput();
            if(commandIndex == 2)
                _wallPlacementHandler.HandleInput();
        }
    }
}