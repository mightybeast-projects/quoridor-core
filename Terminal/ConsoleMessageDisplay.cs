using System;
using Quoridor.Core;

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
        }

        public void DisplayCantMoveErrorMessage()
        {
            DisplayErrorMessage("Can't move to the given direction.");
        }

        public void DisplayIncorrectMenuItemMessage()
        {
            DisplayWarningMessage("Incorrect menu index.");
        }

        public void DisplayWallIsTooLongMessage()
        {
            DisplayWarningMessage("Wall is too long. Walls can only be 3 tiles long.");
        }

        public void DisplayWallIsNotOnTheSameLineMessage()
        {
            DisplayWarningMessage("Wall is not on the same line. Walls can be placed in horizontal or vertical direction.");
        }

        public void DisplayWallTilesHavePairCoordinatesMessage()
        {
            DisplayWarningMessage("Wall covers walkable tile.");
        }

        public void DisplayWallDoesNotCoverTwoSolidTilesMessage()
        {
            DisplayWarningMessage("Wall does not line up with two walkable tiles.");
        }

        public void DisplayWallInterceptsWithOtherWallMessage()
        {
            DisplayWarningMessage("Wall intercepts with other wall.");
        }

        public void DisplayNotEnoughWallsMessage()
        {
            DisplayWarningMessage("Not enough walls.");
        }

        public void DisplayWallIsOnTheWayMessage()
        {
            DisplayWarningMessage("Wall is on the way of movement.");
        }

        public void DisplayWallHasPositionBeyondBoardMessage()
        {
            DisplayWarningMessage("Wall position contains negative coordinate.");
        }

        public void DisplayWallIsBehindSecondPlayerMessage()
        {
            DisplayWarningMessage("There is a wall behind second player.");
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
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void SetWarningMessageConsoleColor()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void ResetConsoleColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}