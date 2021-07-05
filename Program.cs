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
            //FourPlayersExample();

            StartConsoleApp();
        }

        private static void InitializeFields()
        {
            _board = new Board(17, 17);
            _players = new List<Player>();
        }

        private static void FourPlayersExample()
        {
            Player firstPlayer = new Player(_board);
            _players.Add(firstPlayer);
            Player secondPlayer = new Player(_board);
            _players.Add(secondPlayer);
            Player thirdPlayer = new Player(_board);
            _players.Add(thirdPlayer);
            Player fourthPlayer = new Player(_board);
            _players.Add(fourthPlayer);

            firstPlayer.SetPosition(8, 0);
            secondPlayer.SetPosition(8, 16);
            thirdPlayer.SetPosition(0, 8);
            fourthPlayer.SetPosition(16, 8);
        }

        private static void TwoPlayersExample()
        {
            Player firstPlayer = new Player(_board);
            _players.Add(firstPlayer);
            Player secondPlayer = new Player(_board);
            _players.Add(secondPlayer);

            firstPlayer.SetPosition(8, 14);
            secondPlayer.SetPosition(8, 16);
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
