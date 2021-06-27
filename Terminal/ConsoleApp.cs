using System;
using System.Numerics;
using Quoridor.Core;
using Quoridor.Core.Player;

namespace Quoridor.Terminal
{
    public class ConsoleApp
    {
        private ConsoleDrawer _drawer;
        private Board _board;
        private Player _player;

        private ConsoleMessageDisplay _messageDisplay;

        public ConsoleApp(Board board, Player player)
        {
            _board = board;
            _player = player;
            _drawer = new ConsoleDrawer(board, player);
            _messageDisplay = new ConsoleMessageDisplay();

            _player.SetOutput(_messageDisplay);
        }
        
        public void Start()
        {
            while(true){
                try { DisplayGameAndHandleInput(); }
                catch (FormatException) { _messageDisplay.DisplayIncorrectMenuItemMessage(); }
            }
        }

        private void DisplayGameAndHandleInput()
        {
            _drawer.DrawBoard();
            _messageDisplay.PrintConsoleMenu();
            HandleConsoleInput();
        }

        private void HandleConsoleInput()
        {
            int commandIndex = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(commandIndex);

            if(commandIndex == 1)
                NavigateMovementMenu();
            else
                NavigateWallPlacementMenu();
        }

        private void NavigateMovementMenu()
        {
            _messageDisplay.PrintMovePlayerMenu();

            int commandIndex = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(commandIndex);
            switch (commandIndex)
            {
                case 1:
                    _player.MoveUp();
                    break;
                case 2:
                    _player.MoveDown();
                    break;
                case 3:
                    _player.MoveRight();
                    break;
                case 4:
                    _player.MoveLeft();
                    break;
            }            
        }

        private void NavigateWallPlacementMenu()
        {
            Console.WriteLine("Input wall start position (Example: 0 1)");
            string startPositionString = Console.ReadLine();
            Console.WriteLine("Input wall end position (Example: 2 1)");
            string endPositionString = Console.ReadLine();

            int startPositionX = int.Parse(startPositionString.Split(" ")[0]);
            int startPositionY = int.Parse(startPositionString.Split(" ")[1]);
            int endPositionX = int.Parse(endPositionString.Split(" ")[0]);
            int endPositionY = int.Parse(endPositionString.Split(" ")[1]);

            Vector2 wallStartPosition = new Vector2(startPositionX, startPositionY);
            Vector2 wallEndPosition = new Vector2(endPositionX, endPositionY);

            Console.WriteLine(wallStartPosition + " " + wallEndPosition);

            _player.PlaceWall(wallStartPosition, wallEndPosition);
        }
    }
}