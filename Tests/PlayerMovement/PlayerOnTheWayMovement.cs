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
    }
}