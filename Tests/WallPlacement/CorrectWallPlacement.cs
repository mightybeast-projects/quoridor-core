using System.Numerics;
using NUnit.Framework;
using Quoridor.Core;

namespace Quoridor.Tests.WallPlacement
{
    [TestFixture]
    public class CorrectWallPlacement : Initialization
    {
        private Vector2 _startTile;
        private Vector2 _endTile;

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
            _startTile = startTile;
            _endTile = endTile;
            _firstPlayer.PlaceWall(startTile, endTile);

            AssertWallPlacedAndTilesAreNotEmpty();
        }

        private void AssertWallPlacedAndTilesAreNotEmpty()
        {
            Assert.AreEqual(9, _firstPlayer.wallCounter);
            Assert.AreEqual(1, _firstPlayer.placedWalls.Count);
            Assert.IsFalse(_board.grid[(int) _startTile.X, (int) _startTile.Y].isEmpty);
            Assert.IsFalse(
                _board.grid[(int) (_startTile.X + _endTile.X) / 2,
                            (int) (_startTile.Y + _endTile.Y) / 2].isEmpty);
            Assert.IsFalse(_board.grid[(int) _endTile.X, (int) _endTile.Y].isEmpty);
        }
    }
}