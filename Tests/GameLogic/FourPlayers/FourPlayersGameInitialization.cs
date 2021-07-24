using NUnit.Framework;

namespace Quoridor.Tests.GameLogic.FourPlayers
{
    public class FourPlayersGameInitialization : Initialization
    {
        protected override void SetUp()
        {
            base.SetUp();
            _game.AddNewPlayerPair();
            _game.AddNewPlayerPair();
            _game.Start();
        }
    }
}