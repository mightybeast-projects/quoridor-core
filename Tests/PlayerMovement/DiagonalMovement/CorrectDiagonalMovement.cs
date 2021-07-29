using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.PlayerLogic.Movement.Exceptions;

namespace Quoridor.Tests.PlayerMovement.DiagonalMovement
{
    [TestFixture]
    public class CorrectDiagonalMovement : Initialization
    {
        [Test]
        public void DoNotMoveIfThereIsWallBehindAnotherPlayer()
        {
            _firstPlayer.SetPosition(8, 0);
            _secondPlayer.SetPosition(8, 2);
            _firstPlayer.PlaceWall(new Vector2(8, 3), new Vector2(10, 3));

            Assert.Throws<WallBehindAnotherPlayerException>(
                () => _firstPlayer.MoveUp()
            );
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
    }
}