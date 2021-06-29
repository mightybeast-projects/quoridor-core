using System;
using System.Numerics;
using Quoridor.Core.Player;

namespace Quoridor.Terminal.ConsoleInputHandler
{
    public class ConsoleWallPlacementHandler : InputHandler
    {
        public ConsoleWallPlacementHandler(Player player) : base(player) {}

        public override void HandleInput()
        {
            Console.WriteLine("Input wall start position (Example: 0 1)");
            string startPositionString = Console.ReadLine();
            Console.WriteLine("Input wall end position (Example: 2 1)");
            string endPositionString = Console.ReadLine();

            int wallStartPositionX = int.Parse(startPositionString.Split(" ")[0]);
            int wallStartPositionY = int.Parse(startPositionString.Split(" ")[1]);
            int wallEndPositionX = int.Parse(endPositionString.Split(" ")[0]);
            int wallEndPositionY = int.Parse(endPositionString.Split(" ")[1]);

            Vector2 wallStartPosition = new Vector2(wallStartPositionX, wallStartPositionY);
            Vector2 wallEndPosition = new Vector2(wallEndPositionX, wallEndPositionY);

            _player.PlaceWall(wallStartPosition, wallEndPosition);
        }
    }
}