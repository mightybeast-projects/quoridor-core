using System.Numerics;
using NUnit.Framework;

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
            _startTile = new Vector2(0, 1);
            _endTile = new Vector2(2, 1);

            PlaceAndAssertCorrectWall();
        }

        [Test]
        public void PlaceReversedHorizontalWall()
        {
            _startTile = new Vector2(2, 1);
            _endTile = new Vector2(0, 1);
            
            PlaceAndAssertCorrectWall();
        }

        [Test]
        public void PlaceReversedVerticalWall()
        {
            _startTile = new Vector2(1, 2);
            _endTile = new Vector2(1, 0);
            
            PlaceAndAssertCorrectWall();
        }

        private void PlaceAndAssertCorrectWall()
        {
            _firstPlayer.PlaceWall(_startTile, _endTile);

            AssertWallPlacedAndTilesAreNotEmpty();
        }

        private void AssertWallPlacedAndTilesAreNotEmpty()
        {
            Assert.AreEqual(9, _firstPlayer.wallCounter);
            Assert.AreEqual(1, _firstPlayer.board.placedWalls.Count);
            Assert.IsFalse(_board.grid[(int) _startTile.X, (int) _startTile.Y].isEmpty);
            Assert.IsFalse(_board.grid[
                            (int) (_startTile.X + _endTile.X) / 2,
                            (int) (_startTile.Y + _endTile.Y) / 2].isEmpty);
            Assert.IsFalse(_board.grid[(int) _endTile.X, (int) _endTile.Y].isEmpty);
        }
    }
}