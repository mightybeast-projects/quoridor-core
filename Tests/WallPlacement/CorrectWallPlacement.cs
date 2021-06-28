using System.Numerics;
using NUnit.Framework;
using Quoridor.Core;

namespace Quoridor.Tests.WallPlacement
{
    [TestFixture]
    public class CorrectWallPlacement : Initialization
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
        public void CreateReversedHorizontalWall()
        {
            _wall = new Wall(new Vector2(1, 2), new Vector2(1, 0));

            Assert.AreEqual(new Vector2(1, 1), _wall.middlePosition);
        }

        [Test]
        public void CreateReversedVerticalWall()
        {
            _wall = new Wall(new Vector2(1, 2), new Vector2(1, 0));

            Assert.AreEqual(new Vector2(1, 1), _wall.middlePosition);
        }

        [Test]
        public void PlaceCorrectWall()
        {
            _player.PlaceWall(new Vector2(0, 1), new Vector2(2, 1));

            AssertWallPlacedAndCheckTiles(new Vector2(0, 1), new Vector2(2, 1));
        }

        [Test]
        public void PlaceReversedHorizontalWall()
        {
            _player.PlaceWall(new Vector2(2, 1), new Vector2(0, 1));

            AssertWallPlacedAndCheckTiles(new Vector2(2, 1), new Vector2(0, 1));
        }

        [Test]
        public void PlaceReversedVerticalWall()
        {
            _player.PlaceWall(new Vector2(1, 2), new Vector2(1, 0));

            Assert.AreEqual(9, _player.wallCounter);
            Assert.AreEqual(1, _player.placedWalls.Count);
            Assert.IsFalse(_board.grid[1, 0].isEmpty);
            Assert.IsFalse(_board.grid[1, 1].isEmpty);
            Assert.IsFalse(_board.grid[1, 2].isEmpty);
        }

        private void AssertWallPlacedAndCheckTiles(Vector2 startTile, Vector2 endTile)
        {
            Assert.AreEqual(9, _player.wallCounter);
            Assert.AreEqual(1, _player.placedWalls.Count);
            Assert.IsFalse(_board.grid[(int) startTile.X, (int) startTile.Y].isEmpty);
            Assert.IsFalse(
                _board.grid[(int) (startTile.X + endTile.X) / 2,
                            (int) (startTile.Y + endTile.Y) / 2].isEmpty);
            Assert.IsFalse(_board.grid[(int) endTile.X, (int) endTile.Y].isEmpty);
        }
    }
}