using System.Numerics;
using NUnit.Framework;

namespace Quoridor.Tests.WallPlacement
{
    [TestFixture]
    public class WrongWallPlacement : Initialization
    {
        [Test]
        public void PlaceLongWall()
        {
            PlaceAndAssertWrongWall(new Vector2(0, 1), new Vector2(4, 1));
        }

        [Test]
        public void PlaceWallInDifferentLines()
        {
            PlaceAndAssertWrongWall(new Vector2(0, 1), new Vector2(2, 4));
        }

        [Test]
        public void PlaceWallWithTileWhichHavePairCoordinates()
        {
            PlaceAndAssertWrongWall(new Vector2(0, 1), new Vector2(0, 3));
        }

        [Test]
        public void PlaceWallWhichDoesNotCoverTwoSolidTiles()
        {
            PlaceAndAssertWrongWall(new Vector2(1, 1), new Vector2(3, 1));
        }

        [Test]
        public void PlaceWallWhichInterceptsWithOtherWall()
        {
            _player.PlaceWall(new Vector2(0, 1), new Vector2(2, 1));
            _player.PlaceWall(new Vector2(1, 0), new Vector2(1, 2));

            Assert.AreEqual(9, _player.wallCounter);
            Assert.AreEqual(1, _player.placedWalls.Count);
            Assert.IsTrue(_board.grid[1, 0].isEmpty);
            Assert.IsTrue(_board.grid[1, 2].isEmpty);
        }

        private void PlaceAndAssertWrongWall(Vector2 startPosition, Vector2 endPosition)
        {
            _player.PlaceWall(startPosition, endPosition);

            Assert.AreEqual(10, _player.wallCounter);
            Assert.AreEqual(0, _player.placedWalls.Count);
            Assert.IsTrue(_board.grid[(int)startPosition.X, (int)startPosition.Y].isEmpty);
            Assert.IsTrue(_board.grid[(int)endPosition.X, (int)endPosition.Y].isEmpty);
        }
    }
}