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

        [Test]
        public void MovePlayerUpWithWallOnTheWay()
        {
            AssertPlayerDidNotMoveWithWallOnTheWay(
                _player.MoveUp, new Vector2(8, 3), new Vector2(10, 3));
        }

        [Test]
        public void MovePlayerDownWithWallOnTheWay()
        {
            AssertPlayerDidNotMoveWithWallOnTheWay(
                _player.MoveDown, new Vector2(8, 1), new Vector2(10, 1));
        }

        [Test]
        public void MovePlayerRightWithWallOnTheWay()
        {
            AssertPlayerDidNotMoveWithWallOnTheWay(
                _player.MoveRight, new Vector2(9, 0), new Vector2(9, 2));
        }
        [Test]
        public void MovePlayerLeftWithWallOnTheWay()
        {
            AssertPlayerDidNotMoveWithWallOnTheWay(
                _player.MoveLeft, new Vector2(7, 0), new Vector2(7, 2));
        }

        private void AssertPlayerDidNotMoveWithWallOnTheWay(
            Action MovementFunction, Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _player.SetPosition(8, 2);
            _player.PlaceWall(wallStartPosition, wallEndPosition);
            MovementFunction();

            Assert.AreEqual(new Vector2(8, 2), _player.position);
            Assert.IsTrue(!_board.grid[8, 2].isEmpty);
        }

        private void MovePlayerAndAssertPostion(
            Action MovementFunction, Vector2 previousPosition, Vector2 currentPosition)
        {
            MovementFunction();
            
            AssertPreviousAndCurrentTilesPosition(previousPosition, currentPosition);
        }

        private void AssertPositionAndTileDidNotChangeAfterMoveOnEdge(
            Vector2 playerPosition, Action MovementFunction)
        {
            _player.SetPosition(playerPosition);
            MovementFunction();

            Assert.AreEqual(playerPosition, _player.position);
            Assert.IsTrue(!_board.grid[(int)playerPosition.X, (int)playerPosition.Y].isEmpty);
        }

        private void AssertPreviousAndCurrentTilesPosition(
            Vector2 previousTilePosition, Vector2 currentTilePosition)
        {
            Assert.AreEqual(currentTilePosition, _player.position);
            Assert.IsTrue(_board.grid[(int)previousTilePosition.X, (int)previousTilePosition.Y].isEmpty);
            Assert.IsTrue(!_board.grid[(int)currentTilePosition.X, (int)currentTilePosition.Y].isEmpty);
        }
    }
}