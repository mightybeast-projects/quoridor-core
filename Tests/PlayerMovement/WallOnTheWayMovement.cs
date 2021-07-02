using System;
using System.Numerics;
using NUnit.Framework;

namespace Quoridor.Tests.PlayerMovement
{
    [TestFixture]
    public class WallOnTheWayMovement : Initialization
    {
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
    }
}