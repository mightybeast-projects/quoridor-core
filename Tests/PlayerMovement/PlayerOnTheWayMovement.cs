using System.Numerics;
using NUnit.Framework;

namespace Quoridor.Tests.PlayerMovement
{
    [TestFixture]
    public class PlayerOnTheWayMovement : Initialization
    {
        [Test]
        public void PlayerOnTheWayUp()
        {
            _firstPlayer.SetPosition(8, 8);
            _secondPlayer.SetPosition(8, 10);
            _firstPlayer.MoveUp();

            Assert.IsTrue(_board.grid[8, 8].isEmpty);
            Assert.IsFalse(_board.grid[8, 10].isEmpty);
            Assert.IsFalse(_board.grid[8, 12].isEmpty);
            Assert.AreEqual(new Vector2(8, 12), _firstPlayer.position);
        }

        [Test]
        public void PlayerOnTheWayDown()
        {
            _firstPlayer.SetPosition(8, 10);
            _secondPlayer.SetPosition(8, 8);
            _firstPlayer.MoveDown();

            Assert.IsTrue(_board.grid[8, 10].isEmpty);
            Assert.IsFalse(_board.grid[8, 8].isEmpty);
            Assert.IsFalse(_board.grid[8, 6].isEmpty);
            Assert.AreEqual(new Vector2(8, 6), _firstPlayer.position);
        }

        [Test]
        public void PlayerOnTheWayRight()
        {
            _firstPlayer.SetPosition(8, 8);
            _secondPlayer.SetPosition(10, 8);
            _firstPlayer.MoveRight();

            Assert.IsTrue(_board.grid[8, 8].isEmpty);
            Assert.IsFalse(_board.grid[10, 8].isEmpty);
            Assert.IsFalse(_board.grid[12, 8].isEmpty);
            Assert.AreEqual(new Vector2(12, 8), _firstPlayer.position);
        }

        [Test]
        public void PlayerOnTheWayLeft()
        {
            _firstPlayer.SetPosition(8, 8);
            _secondPlayer.SetPosition(6, 8);
            _firstPlayer.MoveLeft();

            Assert.IsTrue(_board.grid[8, 8].isEmpty);
            Assert.IsFalse(_board.grid[6, 8].isEmpty);
            Assert.IsFalse(_board.grid[4, 8].isEmpty);
            Assert.AreEqual(new Vector2(4, 8), _firstPlayer.position);
        }
    }
}