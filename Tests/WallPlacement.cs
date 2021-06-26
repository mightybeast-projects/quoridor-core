using System.Numerics;
using NUnit.Framework;
using Quoridor.Core;
using Quoridor.Tests;

namespace Quoridor.Tests
{
    [TestFixture]
    public class WallPlacement : Initialization
    {
        [Test]
        public void CreateHorizontalWall()
        {
            _wall = new Wall(new Vector2(0, 1), new Vector2(2, 1));

            Assert.AreEqual(new Vector2(1, 1), _wall.middlePosition);
        }

        [Test]
        public void CreateVerticalWall()
        {
            _wall = new Wall(new Vector2(1, 0), new Vector2(1, 2));

            Assert.AreEqual(new Vector2(1, 1), _wall.middlePosition);
        }

        [Test]
        public void PlaceCorrectWall()
        {
            _player.PlaceWall(new Vector2(0, 1), new Vector2(2, 1));

            Assert.AreEqual(9, _player.wallCounter);
            Assert.AreEqual(1, _player.placedWalls.Count);
            Assert.IsFalse(_board.grid[0, 1].isEmpty);
            Assert.IsFalse(_board.grid[1, 1].isEmpty);
            Assert.IsFalse(_board.grid[2, 1].isEmpty);
            Assert.IsTrue(_board.grid[3, 1].isEmpty);
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
        public void PlaceLongWall()
        {
            PlaceAndAssertWrongWall(new Vector2(0, 1), new Vector2(4, 1));
        }

        private void PlaceAndAssertWrongWall(Vector2 startPosition, Vector2 endPosition)
        {
            _player.PlaceWall(startPosition, endPosition);

            Assert.AreEqual(10, _player.wallCounter);
            Assert.AreEqual(0, _player.placedWalls.Count);
            Assert.IsTrue(_board.grid[(int) startPosition.X, (int) startPosition.Y].isEmpty);
            Assert.IsTrue(_board.grid[(int) endPosition.X, (int) endPosition.Y].isEmpty);
        }
    }
}