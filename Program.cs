using System.Collections.Generic;
using Quoridor.Terminal;
using Quoridor.Core;
using System.Numerics;
using Quoridor.Core.Player;

namespace Quoridor
{
    class Program
    {
        private static Board _board;
        private static List<Player> _players;
        private static ConsoleApp _consoleApp;

        public static void Main()
        {
            InitializeFields();

            //SinglePlayerExample();
            TwoPlayersExample();

            StartConsoleApp();
        }

        private static void InitializeFields()
        {
            _board = new Board(17, 17);
            _players = new List<Player>();
        }

        private static void TwoPlayersExample()
        {
            Player firstPlayer = new Player(_board);
            _players.Add(firstPlayer);
            Player secondPlayer = new Player(_board);
            _players.Add(secondPlayer);
            firstPlayer.SetPosition(8, 0);
            secondPlayer.SetPosition(8, 4);
        }

        private static void SinglePlayerExample()
        {
            Player player = new Player(_board);
            _players.Add(player);
            player.SetPosition(8, 0);
        }

        private static void StartConsoleApp()
        {
            _consoleApp = new ConsoleApp(_board, _players);
            _consoleApp.Start();
        }
    }
}
