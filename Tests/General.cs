using System;
using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.GameLogic;

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
        public void CreateGame()
        {
            _game.AddNewPlayerPair();
            _game.Start();

            Assert.AreEqual(2, _game.players.Count);
            Assert.AreEqual(new Vector2(8, 0), _game.players[0].position);
            Assert.AreEqual(new Vector2(8, 16), _game.players[1].position);
            for (int i = 0; i < _game.players[0].goal.Length; i++)
                Assert.AreEqual(_game.board.grid[i * 2, 16].position, _game.players[0].goal[i].position);
            for (int i = 0; i < _game.players[1].goal.Length; i++)
                Assert.AreEqual(_game.board.grid[i * 2, 0].position, _game.players[1].goal[i].position);
            Assert.AreEqual(_game.players[0], _game.currentPlayer);
        }

        [Test]
        public void WrongPlayerPosition()
        {
            SetWrongPlayerPositionAndAssert(new Vector2(0, 1));
            SetWrongPlayerPositionAndAssert(new Vector2(-1, 0));
            SetWrongPlayerPositionAndAssert(new Vector2(0, -1));
            SetWrongPlayerPositionAndAssert(new Vector2(17, 0));
            SetWrongPlayerPositionAndAssert(new Vector2(0, 17));
        }

        private void SetWrongPlayerPositionAndAssert(Vector2 newPosition)
        {
            _firstPlayer.SetPosition(newPosition);

            try 
            { 
                Assert.IsTrue(_board.grid[(int) newPosition.X, (int) newPosition.Y].isEmpty);
            } 
            catch (Exception) {}
            
            Assert.IsFalse(_board.grid[0, 0].isEmpty);
            Assert.AreEqual(new Vector2(0, 0), _firstPlayer.position);
        }
    }
}