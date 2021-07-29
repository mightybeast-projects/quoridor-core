using System.Numerics;
using NUnit.Framework;
using Quoridor.Core;

namespace Quoridor.Tests.WallPlacement
{
    [TestFixture]
    internal class WallCreation : Initialization
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
    }
}