using Quoridor.Tests;

namespace Quoridor.Core.GameLogic
{
    public class TwoPlayersGameInitialization : Initialization
    {
        protected override void SetUp()
        {
            base.SetUp();
            _game.AddNewPlayerPair();
            _game.Start();
        }
    }
}