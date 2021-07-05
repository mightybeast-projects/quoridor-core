using System.Numerics;
using NUnit.Framework;

namespace Quoridor.Tests
{
    [TestFixture]
    public class General : Initialization
    {
        [Test]
        public void CreateTile()
        {
            Assert.IsTrue(_tile.isSolid);
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
            Assert.IsNotNull(_board.grid[0, 0]);
            Assert.IsNotNull(_board.grid[16, 16]);
        }

        [Test]
        public void CreatePlayer()
        {
            Assert.IsNotNull(_firstPlayer.board);
            Assert.IsTrue(!_board.grid[0, 0].isEmpty);
            Assert.AreEqual(new Vector2(0, 0), _firstPlayer.position);

            _firstPlayer.SetPosition(8, 0);

            Assert.IsTrue(_board.grid[0, 0].isEmpty);
            Assert.IsTrue(!_board.grid[8, 0].isEmpty);
            Assert.AreEqual(new Vector2(8, 0), _firstPlayer.position);
        }

        [Test]
        public void SetWrongPlayerPosition()
        {
            _firstPlayer.SetPosition(0, 1);

            Assert.IsTrue(_board.grid[0, 1].isEmpty);
            Assert.IsFalse(_board.grid[0, 0].isEmpty);
            Assert.AreEqual(new Vector2(0, 0), _firstPlayer.position);
        }
    }
}