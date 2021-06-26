using System;
using System.Numerics;
using Quoridor.Core;

namespace Quoridor.Terminal
{
    public class ConsoleApp : IOutput
    {
        private ConsoleDrawer _drawer;
        private Board _board;
        private Player _player;

        public ConsoleApp(Board board, Player player)
        {
            _board = board;
            _player = player;
            _drawer = new ConsoleDrawer(board, player);
        }
        
        public void Start()
        {
            while(true){
                try { DisplayGameAndHandleInput(); }
                catch (FormatException) { DisplayIncorrectMenuItemMessage(); }
            }
        }

        private void DisplayGameAndHandleInput()
        {
            _drawer.DrawBoard();
            PrintConsoleMenu();
            HandleConsoleInput();
        }

        public void DisplayEdgeMoveErrorMessage()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Can't move to the given direction. Player is at the edge of the board.");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
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
            PrintMovePlayerMenu();
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

            int startPositionX = int.Parse(startPositionString[0].ToString());
            int startPositionY = int.Parse(startPositionString[2].ToString());
            int endPositionX = int.Parse(endPositionString[0].ToString());
            int endPositionY = int.Parse(endPositionString[2].ToString());

            Vector2 wallStartPosition = new Vector2(startPositionX, startPositionY);
            Vector2 wallEndPosition = new Vector2(endPositionX, endPositionY);

            Console.WriteLine(wallStartPosition + " " + wallEndPosition);

            bool wallPlaced = _player.PlaceWall(wallStartPosition, wallEndPosition);

            if(!wallPlaced) DesplayWallPlacementError();
        }

        private void PrintConsoleMenu()
        {
            Console.WriteLine("Input command number:");
            Console.WriteLine("1: Move player");
            Console.WriteLine("2: Place wall");
        }

        private void PrintMovePlayerMenu()
        {
            Console.WriteLine("Input command number:");
            Console.WriteLine("1: Move player up");
            Console.WriteLine("2: Move player down");
            Console.WriteLine("3: Move player right");
            Console.WriteLine("4: Move player left");
        }

        private void DisplayIncorrectMenuItemMessage()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Incorrect menu index.");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DesplayWallPlacementError()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Incorrect wall placement or length.");
            Console.WriteLine("Walls only can be 3 tiles long.");
            Console.WriteLine("You can only place walls which cover two tiles.");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}