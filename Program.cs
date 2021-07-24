using Quoridor.Core.GameLogic;
using Quoridor.Terminal;

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
            _game.players[0].SetPosition(8, 2);
            _game.players[1].SetPosition(10, 2);
        }

        private static void StartConsoleApp()
        {
            _consoleApp = new ConsoleApp(_game);
            _consoleApp.Start();
        }
    }
}
