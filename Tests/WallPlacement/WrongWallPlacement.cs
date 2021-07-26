using System;
using System.Numerics;
using NUnit.Framework;

namespace Quoridor.Tests.WallPlacement
{
    [TestFixture]
    public class WrongWallPlacement : Initialization
    {
        private Vector2 _wallStartPosition;
        private Vector2 _wallEndPosition;
        
        [Test]
        public void PlaceLongWall()
        {
            _wallStartPosition = new Vector2(0, 1);
            _wallEndPosition = new Vector2(4, 1);

            PlaceAndAssertWrongWall();
        }

        [Test]
        public void PlaceWallInDifferentLines()
        {
            _wallStartPosition = new Vector2(0, 1);
            _wallEndPosition = new Vector2(2, 4);

            PlaceAndAssertWrongWall();
        }

        [Test]
        public void PlaceWallWithTileWhichHavePairCoordinates()
        {
            _wallStartPosition = new Vector2(0, 1);
            _wallEndPosition = new Vector2(0, 3);

            PlaceAndAssertWrongWall();
        }

        [Test]
        public void PlaceWallWhichDoesNotCoverTwoSolidTiles()
        {
            _wallStartPosition = new Vector2(1, 1);
            _wallEndPosition = new Vector2(3, 1);

            PlaceAndAssertWrongWall();
        }

        [Test]
        public void PlaceWallWithPositionBeyondBoard()
        {
            _wallStartPosition = new Vector2(-2, 0);
            _wallEndPosition = new Vector2(0, 0);

            PlaceAndAssertWrongWall();

            _wallStartPosition = new Vector2(0, 17);
            _wallEndPosition = new Vector2(0, 19);

            PlaceAndAssertWrongWall();
        }

        [Test]
        public void PlaceWallWhichInterceptsWithOtherWall()
        {
            _firstPlayer.PlaceWall(new Vector2(0, 1), new Vector2(2, 1));
            _firstPlayer.PlaceWall(new Vector2(1, 0), new Vector2(1, 2));

            Assert.AreEqual(9, _firstPlayer.wallCounter);
            Assert.AreEqual(1, _firstPlayer.board.placedWalls.Count);
            Assert.IsTrue(_board.grid[1, 0].isEmpty);
            Assert.IsTrue(_board.grid[1, 2].isEmpty);
        }

        private void PlaceAndAssertWrongWall()
        {
            _firstPlayer.PlaceWall(_wallStartPosition, _wallEndPosition);

            Assert.AreEqual(10, _firstPlayer.wallCounter);
            Assert.AreEqual(0, _firstPlayer.board.placedWalls.Count);
            try
            {
                Assert.IsTrue(_board.grid[(int)_wallStartPosition.X, (int)_wallStartPosition.Y].isEmpty);
                Assert.IsTrue(_board.grid[(int)_wallEndPosition.X, (int)_wallEndPosition.Y].isEmpty);
            }
            catch (Exception) {}
        }
    }
}