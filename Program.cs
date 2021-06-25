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
            player.SetPosition(8, 0);
            IOutput consoleApp = new ConsoleApp(board, player);
            player.SetOutput(consoleApp);
            consoleApp.Start();
        }
    }
}
