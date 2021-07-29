using Quoridor.Core.GameLogic;

namespace Quoridor
{
    class Program
    {
        public static void Main()
        {
            Game game = new Game();
            game.AddNewPlayerPair();
            game.Start();
        }
    }
}
