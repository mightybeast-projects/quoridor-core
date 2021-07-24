using System;
using System.Collections.Generic;
using Quoridor.Terminal;
using Quoridor.Core;
using System.Numerics;
using Quoridor.Core.PlayerLogic;
using Quoridor.Core.GameLogic;
using Pathfinding;

namespace Quoridor
{
    class Program
    {
        private static Game _game;
        private static ConsoleApp _consoleApp;

        public static void Main()
        {
            GameExample();

            StartConsoleApp();
        }
        
        private static void GameExample()
        {
            _game = new Game();
            _game.AddNewPlayerPair();
            _game.Start();
        }

        private static void StartConsoleApp()
        {
            _consoleApp = new ConsoleApp(_game);
            _consoleApp.Start();
        }
    }
}
