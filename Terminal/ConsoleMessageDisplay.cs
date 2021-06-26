using System;

namespace Quoridor.Terminal
{
    public class ConsoleMessageDisplay
    {
        public void DisplayEdgeMoveErrorMessage()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Can't move to the given direction. Player is at the edge of the board.");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintConsoleMenu()
        {
            Console.WriteLine("Input command number:");
            Console.WriteLine("1: Move player");
            Console.WriteLine("2: Place wall");
        }

        public void PrintMovePlayerMenu()
        {
            Console.WriteLine("Input command number:");
            Console.WriteLine("1: Move player up");
            Console.WriteLine("2: Move player down");
            Console.WriteLine("3: Move player right");
            Console.WriteLine("4: Move player left");
        }

        public void DisplayIncorrectMenuItemMessage()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Incorrect menu index.");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DesplayWallPlacementError()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Wall did not met all requirements.");
            Console.WriteLine("Wall only can be 3 tiles long.");
            Console.WriteLine("Wall can be placed in horizontal or vertical direction.");
            Console.WriteLine("Wall can't cover tile with paired indexes.");
            Console.WriteLine("Wall must cover two solid tiles.");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}