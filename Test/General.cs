using System.Numerics;
using NUnit.Framework;
using Quoridor.Core;

namespace Quoridor.Test
{
    [TestFixture]
    public class General
    {
        private SolidTile _testSolidTile;
        private VoidTile  _testVoidTile;
        private Board _board;
        private Player _player;

        [SetUp]
        public void SetUp()
        {
            _testSolidTile = new SolidTile();
            _testVoidTile = new VoidTile();
            _board = new Board(17, 17);
            _player = new Player(_board);
        }

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
            Assert.AreEqual(new Vector2(0, 0), _player.position);
            _player.SetPosition(0, 8);
            Assert.AreEqual(new Vector2(0, 8), _player.position);
        }
    }
}