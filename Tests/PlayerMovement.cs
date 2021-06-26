using System;
using System.Numerics;
using NUnit.Framework;

namespace Quoridor.Tests
{
    [TestFixture]
    public class PlayerMovement : Initialization
    {
        [Test]
        public void MovePlayerOneSolidTileUp()
        {
            _player.SetPosition(8, 0);
            MovePlayerAndAssertPostion(_player.MoveUp, new Vector2(8, 0), new Vector2(8, 2));
        }

        [Test]
        public void MovePlayerOneSolidTileDown()
        {
            _player.SetPosition(8, 2);
            MovePlayerAndAssertPostion(_player.MoveDown, new Vector2(8, 2), new Vector2(8, 0));
        }

        [Test]
        public void MovePlayerOneSolidTileRight()
        {
            _player.SetPosition(8, 0);
            MovePlayerAndAssertPostion(_player.MoveRight, new Vector2(8, 0), new Vector2(10, 0));
        }

        [Test]
        public void MovePlayerOneSolidTileLeft()
        {
            _player.SetPosition(8, 0);
            MovePlayerAndAssertPostion(_player.MoveLeft, new Vector2(8, 0), new Vector2(6, 0));
        }

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

        private void MovePlayerAndAssertPostion(Action movementFunction, Vector2 previousPosition, Vector2 currentPosition)
        {
            movementFunction();
            
            AssertPreviousAndCurrentTilesPosition(previousPosition, currentPosition);
        }

        private void AssertPositionAndTileDidNotChangeAfterMoveOnEdge(Vector2 playerPosition, Action movementFunction)
        {
            _player.SetPosition(playerPosition);
            movementFunction();

            Assert.AreEqual(playerPosition, _player.position);
            Assert.IsTrue(!_board.grid[(int)playerPosition.X, (int)playerPosition.Y].isEmpty);
        }

        private void AssertPreviousAndCurrentTilesPosition(Vector2 previousTilePosition, Vector2 currentTilePosition)
        {
            Assert.AreEqual(currentTilePosition, _player.position);
            Assert.IsTrue(_board.grid[(int)previousTilePosition.X, (int)previousTilePosition.Y].isEmpty);
            Assert.IsTrue(!_board.grid[(int)currentTilePosition.X, (int)currentTilePosition.Y].isEmpty);
        }
    }
}