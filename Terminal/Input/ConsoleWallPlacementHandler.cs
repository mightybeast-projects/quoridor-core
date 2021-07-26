using System;
using System.Numerics;
using Quoridor.Core.GameLogic;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Terminal.Input
{
    public class ConsoleWallPlacementHandler
    {
        private string _startPositionString;
        private string _endPositionString;

        private Vector2 _wallStartPosition = Vector2.Zero;
        private Vector2 _wallEndPosition = Vector2.Zero;
        private Game _game;

        public ConsoleWallPlacementHandler(Game game)
        {
            _game = game;
        }

        public void HandleInput()
        {
            ReadInput();
            ParseInput();

            _game.MakeCurrentPlayerPlaceWall(_wallStartPosition, _wallEndPosition);
        }

        private void ReadInput()
        {
            Console.WriteLine("Input wall start position (Example: 0 1)");
            _startPositionString = Console.ReadLine();
            Console.WriteLine("Input wall end position (Example: 2 1)");
            _endPositionString = Console.ReadLine();
        }

        private void ParseInput()
        {
            _wallStartPosition.X = int.Parse(_startPositionString.Split(" ")[0]);
            _wallStartPosition.Y = int.Parse(_startPositionString.Split(" ")[1]);
            _wallEndPosition.X = int.Parse(_endPositionString.Split(" ")[0]);
            _wallEndPosition.Y = int.Parse(_endPositionString.Split(" ")[1]);
        }
    }
}