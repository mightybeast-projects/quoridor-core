using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.GameLogic;

namespace Quoridor.Tests.Pathfinding
{
    [TestFixture]
    public class WallPlacementPathfinding: Initialization
    {
        protected override void SetUp()
        {
            base.SetUp();
            _players.Add(_firstPlayer);
            _players.Add(_secondPlayer);
            _game = new Game(_board, _players);
        }

        [Test]
        public void DoNotPlaceWalIfOtherPlayerHaveNoPathToGoal1()
        {
            _game.MakeCurrentPlayerPlaceWall(new Vector2(7, 16), new Vector2(7, 14));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(8, 15), new Vector2(10, 15));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 14), new Vector2(11, 16));

            Assert.AreEqual(9, _firstPlayer.wallCounter);
            Assert.IsTrue(_board.grid[11, 14].isEmpty);
            Assert.IsTrue(_board.grid[11, 15].isEmpty);
            Assert.IsTrue(_board.grid[11, 16].isEmpty);
            Assert.AreEqual(_firstPlayer, _game.currentPlayer);
        }

        [Test]
        public void DoNotPlaceWalIfOtherPlayerHaveNoPathToGoal2()
        {
            _game.MakeCurrentPlayerPlaceWall(new Vector2(7, 0), new Vector2(7, 2));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(8, 1), new Vector2(10, 1));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 0), new Vector2(11, 2));

            Assert.AreEqual(9, _firstPlayer.wallCounter);
            Assert.IsTrue(_board.grid[11, 0].isEmpty);
            Assert.IsTrue(_board.grid[11, 1].isEmpty);
            Assert.IsTrue(_board.grid[11, 2].isEmpty);
            Assert.AreEqual(_firstPlayer, _game.currentPlayer);
        }

        [Test]
        public void DoNotPlaceWalIfOtherPlayerHaveNoPathToGoal3()
        {
            _game.MakeCurrentPlayerPlaceWall(new Vector2(7, 16), new Vector2(7, 14));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(8, 15), new Vector2(10, 15));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 14), new Vector2(11, 16));

            Assert.AreEqual(9, _firstPlayer.wallCounter);
            Assert.IsTrue(_board.grid[11, 14].isEmpty);
            Assert.IsTrue(_board.grid[11, 15].isEmpty);
            Assert.IsTrue(_board.grid[11, 16].isEmpty);
            Assert.AreEqual(_firstPlayer, _game.currentPlayer);
        }

        [Test]
        public void DoNotPlaceWalIfOtherPlayerHaveNoPathToGoal4()
        {
            _firstPlayer.SetPosition(0, 0);

            _game.MakeCurrentPlayerPlaceWall(new Vector2(1, 0), new Vector2(1, 2));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(0, 3), new Vector2(2, 3));

            Assert.AreEqual(10, _secondPlayer.wallCounter);
            Assert.IsTrue(_board.grid[0, 3].isEmpty);
            Assert.IsTrue(_board.grid[1, 3].isEmpty);
            Assert.IsTrue(_board.grid[2, 3].isEmpty);
            Assert.AreEqual(_secondPlayer, _game.currentPlayer);
        }

        [Test]
        public void DoNotPlaceWalIfOtherPlayerHaveNoPathToGoal5()
        {
            MakeSeveralMoves();

            BuildWallOnIndex(11);

            _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 10), new Vector2(11, 12));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 14), new Vector2(11, 16));

            Assert.AreEqual(8, _secondPlayer.wallCounter);
            Assert.IsTrue(_board.grid[11, 14].isEmpty);
            Assert.IsTrue(_board.grid[11, 15].isEmpty);
            Assert.IsTrue(_board.grid[11, 16].isEmpty);
            Assert.AreEqual(_secondPlayer, _game.currentPlayer);
        }

        private void MakeSeveralMoves()
        {
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_UP);
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DOWN);
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_UP);
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DOWN);
        }

        private void BuildWallOnIndex(int index)
        {
            _game.MakeCurrentPlayerPlaceWall(new Vector2(0, index), new Vector2(2, index));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(4, index), new Vector2(6, index));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(8, index), new Vector2(10, index));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(12, index), new Vector2(14, index));
        }
    }
}