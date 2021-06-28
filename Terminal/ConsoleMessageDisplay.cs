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
            Console.WriteLine("1: Move player up");
            Console.WriteLine("2: Move player down");
            Console.WriteLine("3: Move player right");
            Console.WriteLine("4: Move player left");
        }

        public void DisplayEdgeMoveErrorMessage()
        {
            SetErrorMessageConsoleColor();
            Console.WriteLine("Can't move to the given direction. Player is at the edge of the board.");
            ResetConsoleColor();
        }

        public void DisplayIncorrectMenuItemMessage()
        {
            DisplayWarningMessage("Incorrect menu index.");
        }

        public void DisplayWallIsTooLongMessage()
        {
            DisplayWarningMessage("Wall is too long. Walls can only be 3 tiles long.");
        }

        public void DisplayWallIsNotOnTheSameLine()
        {
            DisplayWarningMessage("Wall is not on the same line. Walls can be placed in horizontal or vertical direction.");
        }

        public void DisplayWallTilesHavePairCoordinates()
        {
            DisplayWarningMessage("Wall covers walkable tile.");
        }

        public void DisplayWallDoesNotCoverTwoSolidTiles()
        {
            DisplayWarningMessage("Wall does not line up with two walkable tiles.");
        }

        public void DisplayWallInterceptsWithOtherWall()
        {
            DisplayWarningMessage("Wall intercepts with other wall.");
        }

        public void DisplayPlacedAllAvailableWallsMessage()
        {
            DisplayWarningMessage("You placed all of your available walls.");
        }

        private void DisplayWarningMessage(String messageToShow)
        {
            SetWarningMessageConsoleColor();
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