using System.Numerics;
using NUnit.Framework;
using Quoridor.Tests;

namespace Quoridor.Tests
{
    [TestFixture]
    public class General : Initialization
    {
        [Test]
        public void CreateSolidTile()
        {
            Assert.IsTrue(_testSolidTile.isSolid);
        }

        [Test]
        public void CreateVoidTile()
        {
            Assert.IsFalse(_testVoidTile.isSolid);
        }

        [Test]
        public void FirstTileIsSolid()
        {
            Assert.IsTrue(_board.grid[0, 0].isSolid);
        }

        [Test]
        public void SecondTileIsNotSolid()
        {
            Assert.IsFalse(_board.grid[0, 1].isSolid);
        }
        
        [Test]
        public void CreateBoard()
        {
            Assert.IsNotNull(_board);
            Assert.IsNotNull(_board.grid);
            Assert.AreEqual(17, _board.grid.GetLength(0));
            Assert.AreEqual(17, _board.grid.GetLength(1));
            Assert.IsNotNull(_board.grid[0,0]);
            Assert.IsNotNull(_board.grid[16,16]);
        }

        [Test]
        public void CreatePlayer()
        {
            Assert.IsNotNull(_player.board);
            Assert.IsTrue(!_board.grid[0, 0].isEmpty);
            Assert.AreEqual(new Vector2(0, 0), _player.position);

            _player.SetPosition(8, 0);

            Assert.IsTrue(_board.grid[0, 0].isEmpty);
            Assert.IsTrue(!_board.grid[8, 0].isEmpty);
            Assert.AreEqual(new Vector2(8, 0), _player.position);
        }
    }
}