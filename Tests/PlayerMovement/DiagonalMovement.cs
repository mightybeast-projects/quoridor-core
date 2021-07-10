using System.Numerics;
using NUnit.Framework;

namespace Quoridor.Tests.PlayerMovement
{
    [TestFixture]
    public class DiagonalMovement : Initialization
    {
        [Test]
        public void DoNotMoveIfThereIsWallBehindAnotherPlayer()
        {
            _firstPlayer.SetPosition(8, 0);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 3), new Vector2(10, 3));
            _firstPlayer.MoveUp();

            Assert.AreEqual(new Vector2(8, 0), _firstPlayer.position);
            Assert.IsFalse(_board.grid[8, 0].isEmpty);
            Assert.IsTrue(_board.grid[8, 4].isEmpty);
        }

        [Test]
        public void MovePlayerDiagonallyRightWithoutWallBehind()
        {
            _firstPlayer.SetPosition(8, 0);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.MoveDiagonallyTopRight();

            Assert.AreEqual(new Vector2(8, 0), _firstPlayer.position);
            Assert.IsFalse(_board.grid[8, 0].isEmpty);
            Assert.IsTrue(_board.grid[8, 4].isEmpty);
        }

        [Test]
        public void MovePlayerDiagonallyRightWithWallBehind()
        {
            _firstPlayer.SetPosition(8, 0);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 3), new Vector2(10, 3));
            _firstPlayer.MoveDiagonallyTopRight();

            Assert.AreEqual(new Vector2(10, 2), _firstPlayer.position);
            Assert.IsFalse(_board.grid[10, 2].isEmpty);
            Assert.IsTrue(_board.grid[8, 4].isEmpty);
        }
    }
}