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
            AssertPositionAndTileDidNotChangeAfterMoveOnEdge(new Vector2(8, 16), _firstPlayer.MoveUp);
        }

        [Test]
        public void MovePlayerOnBottomEdgeOneSolidTileDown()
        {
            AssertPositionAndTileDidNotChangeAfterMoveOnEdge(new Vector2(8, 0), _firstPlayer.MoveDown);
        }

        [Test]
        public void MovePlayerOnRightEdgeOneSolidTileRight()
        {
            AssertPositionAndTileDidNotChangeAfterMoveOnEdge(new Vector2(16, 0), _firstPlayer.MoveRight);
        }

        [Test]
        public void MovePlayerOnLeftEdgeOneSolidTileLeft()
        {
            AssertPositionAndTileDidNotChangeAfterMoveOnEdge(new Vector2(0, 0), _firstPlayer.MoveLeft);
        }

        private void AssertPositionAndTileDidNotChangeAfterMoveOnEdge(
            Vector2 playerPosition, Action MovementFunction)
        {
            _firstPlayer.SetPosition(playerPosition);
            MovementFunction();

            Assert.AreEqual(playerPosition, _firstPlayer.position);
            Assert.IsTrue(!_board.grid[(int)playerPosition.X, (int)playerPosition.Y].isEmpty);
        }
    }
}