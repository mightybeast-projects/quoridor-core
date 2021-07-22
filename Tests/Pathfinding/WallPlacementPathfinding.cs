using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.GameLogic;

namespace Quoridor.Tests.Pathfinding
{
    [TestFixture]
    public class WallPlacementPathfinding: Initialization
    {
        [Test]
        public void DoNotPlaceWalIfOtherPlayerHaveNoPathToGoal()
        {
            _players.Add(_firstPlayer);
            _players.Add(_secondPlayer);
            _game = new Game(_board, _players);

            _game.MakeCurrentPlayerPlaceWall(new Vector2(7, 16), new Vector2(7, 14));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(8, 15), new Vector2(10, 15));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 14), new Vector2(11, 16));

            Assert.AreEqual(9, _firstPlayer.wallCounter);
            Assert.IsTrue(_board.grid[11, 14].isEmpty);
            Assert.IsTrue(_board.grid[11, 15].isEmpty);
            Assert.IsTrue(_board.grid[11, 16].isEmpty);
            Assert.AreEqual(_firstPlayer, _game.currentPlayer);
        }
    }
}