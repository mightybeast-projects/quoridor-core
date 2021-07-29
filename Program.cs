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
        }

        private static void StartConsoleApp()
        {
            _consoleApp = new ConsoleApp(_game);
            _consoleApp.Start();
        }
    }
}
