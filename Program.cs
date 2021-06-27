using Quoridor.Terminal;
using Quoridor.Core;
using System.Numerics;
using Quoridor.Core.Player;

namespace Quoridor
{
    class Program
    {
        public static void Main()
        {
            Board board = new Board(17, 17);
            Player player = new Player(board);
            player.SetPosition(8, 0);
            
            ConsoleApp consoleApp = new ConsoleApp(board, player);
            consoleApp.Start();
        }
    }
}
