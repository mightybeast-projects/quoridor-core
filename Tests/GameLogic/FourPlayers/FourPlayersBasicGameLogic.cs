using NUnit.Framework;
using Quoridor.Core.GameLogic;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Tests.GameLogic.FourPlayers
{
    [TestFixture]
    public class FourPlayersBasicGameLogic : FourPlayersGameInitialization
    {
        [Test]
        public void SwitchBackToFirstPlayerAfterFourthPlayerMoved()
        {
            Assert.AreEqual(_game.players[0], _game.currentPlayer);

            MoveAndAssertCurrentPlayer(1, PlayerMove.MOVE_UP);
            MoveAndAssertCurrentPlayer(2, PlayerMove.MOVE_DOWN);
            MoveAndAssertCurrentPlayer(3, PlayerMove.MOVE_RIGHT);
            MoveAndAssertCurrentPlayer(0, PlayerMove.MOVE_LEFT);
        }

        [Test]
        public void EveryPlayerHasFiveWalls()
        {
            foreach (Player player in _game.players)
                Assert.AreEqual(5, player.wallCounter);
        }

        private void MoveAndAssertCurrentPlayer(int playerIndex, PlayerMove movement)
        {
            _game.MakeCurrentPlayerMove(movement);
            
            Assert.AreEqual(_game.players[playerIndex], _game.currentPlayer);
        }
    }
}