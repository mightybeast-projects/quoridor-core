using System;
using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.PlayerLogic.WallPlacement.Exceptions;

namespace Quoridor.Tests.WallPlacement
{
    [TestFixture]
    internal class WrongWallPlacement : Initialization
    {
        private Vector2 _wallStartPosition;
        private Vector2 _wallEndPosition;
        
        [Test]
        public void PlaceLongWall()
        {
            _wallStartPosition = new Vector2(0, 1);
            _wallEndPosition = new Vector2(4, 1);

            PlaceAndAssertWrongWallWithException<WallIsTooLongException>();
        }

        [Test]
        public void PlaceWallWithTilesInTheSameSpots()
        {
            _wallStartPosition = new Vector2(0, 1);
            _wallEndPosition = new Vector2(0, 1);
            
            PlaceAndAssertWrongWallWithException<WallDoesNotCoverSolidTilesException>();
        }

        [Test]
        public void PlaceWallInDifferentLines()
        {
            _wallStartPosition = new Vector2(0, 1);
            _wallEndPosition = new Vector2(2, 4);

            PlaceAndAssertWrongWallWithException<WallIsNotOnTheSameLineException>();
        }

        [Test]
        public void PlaceWallWithTileWhichHavePairCoordinates()
        {
            _wallStartPosition = new Vector2(0, 1);
            _wallEndPosition = new Vector2(0, 3);

            PlaceAndAssertWrongWallWithException<WallTilesHavePairCoordinatesException>();
        }

        [Test]
        public void PlaceWallWhichDoesNotCoverTwoSolidTiles()
        {
            _wallStartPosition = new Vector2(1, 1);
            _wallEndPosition = new Vector2(3, 1);

            PlaceAndAssertWrongWallWithException<WallDoesNotCoverSolidTilesException>();
        }

        [Test]
        public void PlaceWallWithPositionBeyondBoard()
        {
            _wallStartPosition = new Vector2(-2, 0);
            _wallEndPosition = new Vector2(0, 0);

            PlaceAndAssertWrongWallWithException<WallIsBeyondBoardException>();

            _wallStartPosition = new Vector2(0, 17);
            _wallEndPosition = new Vector2(0, 19);

            PlaceAndAssertWrongWallWithException<WallIsBeyondBoardException>();
        }

        [Test]
        public void PlaceWallWhichInterceptsWithOtherWall()
        {
            _firstPlayer.PlaceWall(new Vector2(0, 1), new Vector2(2, 1));
            _wallStartPosition = new Vector2(1, 0);
            _wallEndPosition = new Vector2(1, 2);

            Assert.Throws<WallInterceptsWithOtherWallException>(
                () => _firstPlayer.PlaceWall(_wallStartPosition, _wallEndPosition)
            );
            Assert.AreEqual(9, _firstPlayer.wallCounter);
            Assert.AreEqual(1, _board.placedWalls.Count);
        }

        private void PlaceAndAssertWrongWallWithException<T>() 
            where T : Exception
        {
            Assert.Throws<T>(
                () => _firstPlayer.PlaceWall(_wallStartPosition, _wallEndPosition)
            );

            Assert.AreEqual(10, _firstPlayer.wallCounter);
            Assert.AreEqual(0, _board.placedWalls.Count);
            try
            {
                Assert.IsTrue(_board.grid[(int)_wallStartPosition.X, (int)_wallStartPosition.Y].isEmpty);
                Assert.IsTrue(_board.grid[(int)_wallEndPosition.X, (int)_wallEndPosition.Y].isEmpty);
            }
            catch (Exception) {}
        }
    }
}