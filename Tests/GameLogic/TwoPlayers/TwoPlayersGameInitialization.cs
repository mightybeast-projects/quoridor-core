namespace Quoridor.Tests.GameLogic.TwoPlayers
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