using NUnit.Framework;

namespace Quoridor.Tests.GameLogic.TwoPlayers
{
    [TestFixture]
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