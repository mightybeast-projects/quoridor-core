using System;
using System.Collections.Generic;
using Quoridor.Terminal;
using Quoridor.Core;
using System.Numerics;
using Quoridor.Core.PlayerLogic;
using Quoridor.Core.GameLogic;
using Quoridor.Pathfinding;

namespace Quoridor
{
    class Program
    {
        private static Board _board;
        private static List<Player> _players;
        private static Game _game;
        private static ConsoleApp _consoleApp;

        public static void Main()
        {
            /*InitializeFields();

            GameExample();

            StartConsoleApp();*/
            tmp();
        }

        private static void tmp()
        {
            Board _board = new Board();
            AStar algo = new AStar();
            algo.DoAStar(_board.grid[0, 0], _board.grid[16, 16]);
            Console.WriteLine(_board.grid[0, 0].neighbors.Count);
            Console.WriteLine(algo.path.Count);
            foreach(Tile tile in algo.path)
                Console.WriteLine(tile.position);
            Console.ReadKey();
        }

        private static void InitializeFields()
        {
            _board = new Board();
            _players = new List<Player>();
        }

        private static void GameExample()
        {
            Player firstPlayer = new Player(_board);
            Player secondPlayer = new Player(_board);
            _players.Add(firstPlayer);
            _players.Add(secondPlayer);
            _game = new Game(_board, _players);
        }

        private static void StartConsoleApp()
        {
            _consoleApp = new ConsoleApp(_game);
            _consoleApp.Start();
        }
    }
}
