using Quoridor.Terminal;
using Quoridor.Core;

namespace Quoridor
{
    class Program
    {
        public static void Main()
        {
            Board board = new Board(17, 17);
            Player player = new Player(board);
            ConsoleDrawer consoleDrawer = new ConsoleDrawer(board, player);
            IOutput consoleApp = new ConsoleApp(consoleDrawer);
            consoleApp.Start();
        }
    }
}
