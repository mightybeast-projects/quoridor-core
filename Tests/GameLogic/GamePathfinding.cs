using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.GameLogic;
using Quoridor.Tests.GameLogic.TwoPlayers;

namespace Quoridor.Tests.GameLogic
{
    [TestFixture]
    public class GamePathfinding : TwoPlayersGameInitialization
    {
        [Test]
        public void CheckPathOnFirstMove()
        {
            Assert.IsFalse(_game.OneOfThePlayersDoNotHavePathToGoal());
        }

        [Test]
        public void CheckPathAfterSeveralMoves()
        {
            MakePlayersMoveToCenter();

            _game.MakeCurrentPlayerPlaceWall(new Vector2(0, 11), new Vector2(2, 11));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(4, 11), new Vector2(6, 11));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(8, 11), new Vector2(10, 11));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(12, 11), new Vector2(14, 11));

            Assert.IsFalse(_game.OneOfThePlayersDoNotHavePathToGoal());
        }

        private void MakePlayersMoveToCenter()
        {
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_UP);
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DOWN);
        }
    }
}