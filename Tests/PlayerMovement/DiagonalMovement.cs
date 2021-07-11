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
        public void MovePlayerDiagonallyWithoutWallBehind()
        {
            _firstPlayer.SetPosition(8, 0);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.MoveDiagonallyTopRight();
            _firstPlayer.MoveDiagonallyTopLeft();
            _firstPlayer.MoveDiagonallyBottomRight();
            _firstPlayer.MoveDiagonallyBottomLeft();
            _firstPlayer.MoveDiagonallyTopRight();
            _firstPlayer.MoveDiagonallyTopRight();

            Assert.AreEqual(new Vector2(8, 0), _firstPlayer.position);
            Assert.IsFalse(_board.grid[8, 0].isEmpty);
            Assert.IsTrue(_board.grid[8, 4].isEmpty);
        }

        [Test]
        public void MovePlayerDiagonallyTopRightWithWallBehind1()
        {
            _firstPlayer.SetPosition(8, 0);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 3), new Vector2(10, 3));
            _firstPlayer.MoveDiagonallyTopRight();

            Assert.AreEqual(new Vector2(10, 2), _firstPlayer.position);
        }

        [Test]
        public void MovePlayerDiagonallyTopRightWithWallBehind2()
        {
            _firstPlayer.SetPosition(8, 0);
            _secondPlayer.SetPosition(10, 0);
            _firstPlayer.PlaceWall(new Vector2(11, 0), new Vector2(11, 2));
            _firstPlayer.MoveDiagonallyTopRight();

            Assert.AreEqual(new Vector2(10, 2), _firstPlayer.position);
        }

        [Test]
        public void MovePlayerDiagonallyBottomRightWithWallBehind1()
        {
            _firstPlayer.SetPosition(8, 2);
            _secondPlayer.SetPosition(10, 2);
            _firstPlayer.PlaceWall(new Vector2(11, 0), new Vector2(11, 2));
            _firstPlayer.MoveDiagonallyBottomRight();

            Assert.AreEqual(new Vector2(10, 0), _firstPlayer.position);
        }

        [Test]
        public void MovePlayerDiagonallyBottomRightWithWallBehind2()
        {
            _firstPlayer.SetPosition(8, 4);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 1), new Vector2(10, 1));
            _firstPlayer.MoveDiagonallyBottomRight();

            Assert.AreEqual(new Vector2(10, 2), _firstPlayer.position);
        }

        [Test]
        public void MovePlayerDiagonallyBottomLeftWithWallBehind1()
        {
            _firstPlayer.SetPosition(8, 4);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 1), new Vector2(6, 1));
            _firstPlayer.MoveDiagonallyBottomLeft();

            Assert.AreEqual(new Vector2(6, 2), _firstPlayer.position);
        }

        [Test]
        public void MovePlayerDiagonallyBottomLeftWithWallBehind2()
        {
            _firstPlayer.SetPosition(8, 2);
            _secondPlayer.SetPosition(6, 2);
            _firstPlayer.PlaceWall(new Vector2(5, 0), new Vector2(5, 2));
            _firstPlayer.MoveDiagonallyBottomLeft();

            Assert.AreEqual(new Vector2(6, 0), _firstPlayer.position);
        }

        [Test]
        public void MovePlayerDiagonallyTopLeftWithWallBehind1()
        {
            _firstPlayer.SetPosition(8, 0);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 3), new Vector2(10, 3));
            _firstPlayer.MoveDiagonallyTopLeft();

            Assert.AreEqual(new Vector2(6, 2), _firstPlayer.position);
        }

        [Test]
        public void MovePlayerDiagonallyTopLeftWithWallBehind2()
        {
            _firstPlayer.SetPosition(8, 2);
            _secondPlayer.SetPosition(6, 2);
            _firstPlayer.PlaceWall(new Vector2(5, 0), new Vector2(5, 2));
            _firstPlayer.MoveDiagonallyTopLeft();

            Assert.AreEqual(new Vector2(6, 4), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyTopRightIfThereIsWallOnTheWay1()
        {
            _firstPlayer.SetPosition(8, 0);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 3), new Vector2(6, 3));
            _firstPlayer.PlaceWall(new Vector2(9, 2), new Vector2(9, 4));
            _firstPlayer.MoveDiagonallyTopRight();

            Assert.AreEqual(new Vector2(8, 0), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyTopRightIfThereIsWallOnTheWay2()
        {
            _firstPlayer.SetPosition(8, 2);
            _secondPlayer.SetPosition(10, 2);
            _firstPlayer.PlaceWall(new Vector2(11, 0), new Vector2(11, 2));
            _firstPlayer.PlaceWall(new Vector2(10, 3), new Vector2(12, 3));
            _firstPlayer.MoveDiagonallyTopRight();

            Assert.AreEqual(new Vector2(8, 2), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyTopLeftIfThereIsWallOnTheWay1()
        {
            _firstPlayer.SetPosition(8, 0);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 3), new Vector2(10, 3));
            _firstPlayer.PlaceWall(new Vector2(7, 2), new Vector2(7, 4));
            _firstPlayer.MoveDiagonallyTopLeft();

            Assert.AreEqual(new Vector2(8, 0), _firstPlayer.position);
        }
        
        [Test]
        public void DoNotMovePlayerDiagonallyTopLeftIfThereIsWallOnTheWay2()
        {
            _firstPlayer.SetPosition(8, 2);
            _secondPlayer.SetPosition(6, 2);
            _firstPlayer.PlaceWall(new Vector2(5, 0), new Vector2(5, 2));
            _firstPlayer.PlaceWall(new Vector2(6, 3), new Vector2(4, 3));
            _firstPlayer.MoveDiagonallyTopLeft();

            Assert.AreEqual(new Vector2(8, 2), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyBottomRightIfThereIsWallOnTheWay1()
        {
            _firstPlayer.SetPosition(8, 2);
            _secondPlayer.SetPosition(10, 2);
            _firstPlayer.PlaceWall(new Vector2(10, 1), new Vector2(12, 1));
            _firstPlayer.PlaceWall(new Vector2(11, 2), new Vector2(11, 4));
            _firstPlayer.MoveDiagonallyBottomRight();

            Assert.AreEqual(new Vector2(8, 2), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyBottomRightIfThereIsWallOnTheWay2()
        {
            _firstPlayer.SetPosition(8, 4);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 1), new Vector2(6, 1));
            _firstPlayer.PlaceWall(new Vector2(9, 0), new Vector2(9, 2));
            _firstPlayer.MoveDiagonallyBottomRight();

            Assert.AreEqual(new Vector2(8, 4), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyBottomLeftIfThereIsWallOnTheWay1()
        {
            _firstPlayer.SetPosition(8, 4);
            _secondPlayer.SetPosition(6, 4);
            _firstPlayer.PlaceWall(new Vector2(5, 4), new Vector2(5, 6));
            _firstPlayer.PlaceWall(new Vector2(6, 3), new Vector2(4, 3));
            _firstPlayer.MoveDiagonallyBottomLeft();

            Assert.AreEqual(new Vector2(8, 4), _firstPlayer.position);
        }

        [Test]
        public void DoNotMovePlayerDiagonallyBottomLeftIfThereIsWallOnTheWay2()
        {
            _firstPlayer.SetPosition(8, 4);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 1), new Vector2(10, 1));
            _firstPlayer.PlaceWall(new Vector2(7, 0), new Vector2(7, 2));
            _firstPlayer.MoveDiagonallyBottomLeft();

            Assert.AreEqual(new Vector2(8, 4), _firstPlayer.position);
        }
    }
}