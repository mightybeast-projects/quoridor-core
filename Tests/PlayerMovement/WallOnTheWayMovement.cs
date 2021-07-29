using System;
using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.PlayerLogic.Movement.Exceptions;

namespace Quoridor.Tests.PlayerMovement
{
    [TestFixture]
    internal class WallOnTheWayMovement : Initialization
    {
        private Vector2 _wallStartPosition;
        private Vector2 _wallEndPosition;
        private Action MovementFunction;
        
        [Test]
        public void DoNotMovePlayerUpWithWallOnTheWay()
        {
            _wallStartPosition = new Vector2(8, 3);
            _wallEndPosition = new Vector2(10, 3);
            MovementFunction = _firstPlayer.MoveUp;

            AssertPlayerDidNotMoveWithWallOnTheWay();
        }

        [Test]
        public void DoNotMovePlayerDownWithWallOnTheWay()
        {
            _wallStartPosition = new Vector2(8, 1);
            _wallEndPosition = new Vector2(10, 1);
            MovementFunction = _firstPlayer.MoveDown;

            AssertPlayerDidNotMoveWithWallOnTheWay();
        }

        [Test]
        public void DoNotMovePlayerRightWithWallOnTheWay()
        {
            _wallStartPosition = new Vector2(9, 0);
            _wallEndPosition = new Vector2(9, 2);
            MovementFunction = _firstPlayer.MoveRight;

            AssertPlayerDidNotMoveWithWallOnTheWay();
        }

        [Test]
        public void DoNotMovePlayerLeftWithWallOnTheWay()
        {
            _wallStartPosition = new Vector2(7, 0);
            _wallEndPosition = new Vector2(7, 2);
            MovementFunction = _firstPlayer.MoveLeft;

            AssertPlayerDidNotMoveWithWallOnTheWay();
        }
        
        private void AssertPlayerDidNotMoveWithWallOnTheWay()
        {
            _firstPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(_wallStartPosition, _wallEndPosition);

            AssertWallOnTheWayException(
                () => MovementFunction()
            );
            Assert.AreEqual(new Vector2(8, 2), _firstPlayer.position);
            Assert.IsFalse(_board.grid[8, 2].isEmpty);
        }

        private void AssertWallOnTheWayException(Action MovementFunction)
        {
            Assert.Throws<WallOnTheWayException>(
                () => MovementFunction()
            );
        }
    }
}