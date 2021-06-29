using System.Numerics;
using NUnit.Framework;
using Quoridor.Core;

namespace Quoridor.Tests.WallPlacement
{
    [TestFixture]
    public class CorrectWallPlacement : Initialization
    {
        [Test]
        public void PlaceCorrectWall()
        {
            PlaceAndAssertCorrectWall(new Vector2(0, 1), new Vector2(2, 1));
        }

        [Test]
        public void PlaceReversedHorizontalWall()
        {
            PlaceAndAssertCorrectWall(new Vector2(2, 1), new Vector2(0, 1));
        }

        [Test]
        public void PlaceReversedVerticalWall()
        {
            PlaceAndAssertCorrectWall(new Vector2(1, 2), new Vector2(1, 0));
        }

        private void PlaceAndAssertCorrectWall(Vector2 startTile, Vector2 endTile)
        {
            _player.PlaceWall(startTile, endTile);

            AssertWallPlacedAndCheckTiles(startTile, endTile);
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