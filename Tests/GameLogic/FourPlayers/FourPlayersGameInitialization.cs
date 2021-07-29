namespace Quoridor.Tests.GameLogic.FourPlayers
{
    internal class FourPlayersGameInitialization : Initialization
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