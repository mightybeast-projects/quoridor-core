using System;
using System.Numerics;
using NUnit.Framework;

namespace Quoridor.Tests.PlayerMovement
{
    [TestFixture]
    public class BoardEdgeMovement : Initialization
    {
        [Test]
        public void MovePlayerOnTopEdgeOneSolidTileUp()
        {
            AssertPositionAndTileDidNotChangeAfterMoveOnEdge(new Vector2(8, 16), _player.MoveUp);
        }

        [Test]
        public void MovePlayerOnBottomEdgeOneSolidTileDown()
        {
            AssertPositionAndTileDidNotChangeAfterMoveOnEdge(new Vector2(8, 0), _player.MoveDown);
        }

        [Test]
        public void MovePlayerOnRightEdgeOneSolidTileRight()
        {
            AssertPositionAndTileDidNotChangeAfterMoveOnEdge(new Vector2(16, 0), _player.MoveRight);
        }

        [Test]
        public void MovePlayerOnLeftEdgeOneSolidTileLeft()
        {
            AssertPositionAndTileDidNotChangeAfterMoveOnEdge(new Vector2(0, 0), _player.MoveLeft);
        }

        private void AssertPositionAndTileDidNotChangeAfterMoveOnEdge(
            Vector2 playerPosition, Action MovementFunction)
        {
            _player.SetPosition(playerPosition);
            MovementFunction();

            Assert.AreEqual(playerPosition, _player.position);
            Assert.IsTrue(!_board.grid[(int)playerPosition.X, (int)playerPosition.Y].isEmpty);
        }
    }
}