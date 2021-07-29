using System;
using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.PlayerLogic.Movement.Exceptions;

namespace Quoridor.Tests.PlayerMovement.DiagonalMovement
{
    [TestFixture]
    internal class WrongDiagonalMovement : Initialization
    {
        [Test]
        public void MovePlayerDiagonallyWithoutWallBehind()
        {
            _firstPlayer.SetPosition(8, 0);
            _secondPlayer.SetPosition(8, 2);

            AssertCannotMoveDiagonallyException(
                () => {
                _firstPlayer.MoveDiagonallyTopRight();
                _firstPlayer.MoveDiagonallyTopLeft();
                _firstPlayer.MoveDiagonallyBottomRight();
                _firstPlayer.MoveDiagonallyBottomLeft();
                _firstPlayer.MoveDiagonallyTopRight();
                _firstPlayer.MoveDiagonallyTopRight();
                }
            );
            Assert.AreEqual(new Vector2(8, 0), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyTopRightIfThereIsWallOnTheWay1()
        {
            _firstPlayer.SetPosition(8, 0);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 3), new Vector2(6, 3));
            _firstPlayer.PlaceWall(new Vector2(9, 2), new Vector2(9, 4));

            AssertCannotMoveDiagonallyException(
                () => _firstPlayer.MoveDiagonallyTopRight());
            Assert.AreEqual(new Vector2(8, 0), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyTopRightIfThereIsWallOnTheWay2()
        {
            _firstPlayer.SetPosition(8, 2);
            _secondPlayer.SetPosition(10, 2);
            _firstPlayer.PlaceWall(new Vector2(11, 0), new Vector2(11, 2));
            _firstPlayer.PlaceWall(new Vector2(10, 3), new Vector2(12, 3));

            AssertCannotMoveDiagonallyException(
                () => _firstPlayer.MoveDiagonallyTopRight());
            Assert.AreEqual(new Vector2(8, 2), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyTopLeftIfThereIsWallOnTheWay1()
        {
            _firstPlayer.SetPosition(8, 0);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 3), new Vector2(10, 3));
            _firstPlayer.PlaceWall(new Vector2(7, 2), new Vector2(7, 4));

            AssertCannotMoveDiagonallyException(
                () => _firstPlayer.MoveDiagonallyTopLeft());
            Assert.AreEqual(new Vector2(8, 0), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyTopLeftIfThereIsWallOnTheWay2()
        {
            _firstPlayer.SetPosition(8, 2);
            _secondPlayer.SetPosition(6, 2);
            _firstPlayer.PlaceWall(new Vector2(5, 0), new Vector2(5, 2));
            _firstPlayer.PlaceWall(new Vector2(6, 3), new Vector2(4, 3));

            AssertCannotMoveDiagonallyException(
                () => _firstPlayer.MoveDiagonallyTopLeft());
            Assert.AreEqual(new Vector2(8, 2), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyBottomRightIfThereIsWallOnTheWay1()
        {
            _firstPlayer.SetPosition(8, 2);
            _secondPlayer.SetPosition(10, 2);
            _firstPlayer.PlaceWall(new Vector2(10, 1), new Vector2(12, 1));
            _firstPlayer.PlaceWall(new Vector2(11, 2), new Vector2(11, 4));

            AssertCannotMoveDiagonallyException(
                () => _firstPlayer.MoveDiagonallyBottomRight());
            Assert.AreEqual(new Vector2(8, 2), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyBottomRightIfThereIsWallOnTheWay2()
        {
            _firstPlayer.SetPosition(8, 4);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 1), new Vector2(6, 1));
            _firstPlayer.PlaceWall(new Vector2(9, 0), new Vector2(9, 2));

            AssertCannotMoveDiagonallyException(
                () => _firstPlayer.MoveDiagonallyBottomRight()
            );
            Assert.AreEqual(new Vector2(8, 4), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyBottomLeftIfThereIsWallOnTheWay1()
        {
            _firstPlayer.SetPosition(8, 4);
            _secondPlayer.SetPosition(6, 4);
            _firstPlayer.PlaceWall(new Vector2(5, 4), new Vector2(5, 6));
            _firstPlayer.PlaceWall(new Vector2(6, 3), new Vector2(4, 3));

            AssertCannotMoveDiagonallyException(
                () => _firstPlayer.MoveDiagonallyBottomLeft()
            );
            Assert.AreEqual(new Vector2(8, 4), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyBottomLeftIfThereIsWallOnTheWay2()
        {
            _firstPlayer.SetPosition(8, 4);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 1), new Vector2(10, 1));
            _firstPlayer.PlaceWall(new Vector2(7, 0), new Vector2(7, 2));

            AssertCannotMoveDiagonallyException(
                () => _firstPlayer.MoveDiagonallyBottomLeft()
            );
            Assert.AreEqual(new Vector2(8, 4), _firstPlayer.position);
        }

        private void AssertCannotMoveDiagonallyException(Action MovementFunction)
        {
            Assert.Throws<CannotMoveDiagonallyException>(
                () => MovementFunction()
            );
        }
    }
}