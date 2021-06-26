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
        public void CreateWall()
        {
            _wall = new Wall(new Vector2(1, 1), new Vector2(3, 1));

            Assert.AreEqual(new Vector2(2, 1), _wall.middlePosition);
        }

        [Test]
        public void PlaceWall()
        {
            _player.PlaceWall(new Vector2(1, 1), new Vector2(3, 1));

            Assert.AreEqual(9, _player.wallCounter);
            Assert.AreEqual(1, _player.placedWalls.Count);
            Assert.IsTrue(_board.grid[0, 1].isEmpty);
            Assert.IsFalse(_board.grid[1, 1].isEmpty);
            Assert.IsFalse(_board.grid[2, 1].isEmpty);
            Assert.IsFalse(_board.grid[3, 1].isEmpty);
            Assert.IsTrue(_board.grid[4, 1].isEmpty);
        }

        [Test]
        public void PlaceLongWall()
        {
            _player.PlaceWall(new Vector2(1, 1), new Vector2(4, 1));

            Assert.AreEqual(10, _player.wallCounter);
            Assert.AreEqual(0, _player.placedWalls.Count);
            Assert.IsTrue(_board.grid[0, 1].isEmpty);
            Assert.IsTrue(_board.grid[1, 1].isEmpty);
            Assert.IsTrue(_board.grid[2, 1].isEmpty);
            Assert.IsTrue(_board.grid[3, 1].isEmpty);
            Assert.IsTrue(_board.grid[4, 1].isEmpty);
        }
    }
}