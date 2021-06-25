using System;
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

        private void DisplayIncorrectMenuItemMessage()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Incorrect menu index.");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void HandleConsoleInput()
        {
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

        private static void PrintConsoleMenu()
        {
            Console.WriteLine("Input command number:");
            Console.WriteLine("1: Move player up");
            Console.WriteLine("2: Move player down");
            Console.WriteLine("3: Move player right");
            Console.WriteLine("4: Move player left");
        }
    }
}