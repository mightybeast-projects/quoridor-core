using System;
using Quoridor.ConsoleApp;
using Quoridor.Main;

namespace Quoridor
{
    class Program
    {
        public static void Main(string[] args)
        {
            Board board = new Board(17, 17);
            Player player = new Player(board);
            ConsoleDrawer consoleDrawer = new ConsoleDrawer(board, player);
            IOutput consoleApp = new ConsoleApp.ConsoleApp(consoleDrawer);
            consoleApp.Start();
        }
    }
}
