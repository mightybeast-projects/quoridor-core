using System;
using Quoridor.Core.Output;

namespace Quoridor.Terminal
{
    public class ConsoleMessageDisplay : IOutput
    {
        public void PrintConsoleMenu()
        {
            Console.WriteLine("Input command number:");
            Console.WriteLine("1: Move player");
            Console.WriteLine("2: Place wall");
        }

        public void PrintMovePlayerMenu()
        {
            Console.WriteLine("Input command number:");
            Console.WriteLine("1: (↑) Move player up");
            Console.WriteLine("2: (↓) Move player down");
            Console.WriteLine("3: (→) Move player right");
            Console.WriteLine("4: (←) Move player left");
            Console.WriteLine("5: Move diagonally");
        }

        public void PrintDiagonalMovementMenu()
        {
            Console.WriteLine("Input command number:");
            Console.WriteLine("1: (↑ →) Move player up and right");
            Console.WriteLine("2: (↑ ←) Move player up and left");
            Console.WriteLine("3: (↓ →) Move player down and right");
            Console.WriteLine("4: (↓ ←) Move player down and left");
        }

        public void DisplayIncorrectMenuItemMessage()
        {
            DisplayWarningMessage("Incorrect menu index.");
        }

        public void DisplayCantMoveErrorMessage()
        {
            DisplayErrorMessage("Can't move to the given direction.");
        }

        public void DisplayWallIsOnTheWayMessage()
        {
            DisplayWarningMessage("Wall is on the way of movement.");
        }

        public void DisplayWallIsBehindAnotherPlayerMessage()
        {
            DisplayWarningMessage("There is a wall behind another player on the way.");
        }

        public void DisplayCannotMoveDiagonallyMessage()
        {
            DisplayWarningMessage("Cannot move diagonally");
        }

        public void DisplayExceptionMessage(Exception e)
        {
            DisplayErrorMessage(e.Message);
        }

        private void DisplayWarningMessage(String messageToShow)
        {
            SetWarningMessageConsoleColor();
            Console.WriteLine(messageToShow);
            ResetConsoleColor();
        }

        private void DisplayErrorMessage(String messageToShow)
        {
            SetErrorMessageConsoleColor();
            Console.WriteLine(messageToShow);
            ResetConsoleColor();
        }

        private void SetErrorMessageConsoleColor()
        {
            SetMessageConsoleColor(ConsoleColor.DarkRed, ConsoleColor.White);
        }

        private void SetWarningMessageConsoleColor()
        {
            SetMessageConsoleColor(ConsoleColor.DarkYellow, ConsoleColor.White);
        }

        private void SetMessageConsoleColor(
            ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
        }

        private void ResetConsoleColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}