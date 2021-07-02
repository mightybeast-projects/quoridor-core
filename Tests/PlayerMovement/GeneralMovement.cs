using System;
using System.Numerics;
using NUnit.Framework;

namespace Quoridor.Tests.PlayerMovement
{
    [TestFixture]
    public class GeneralMovement : Initialization
    {
        private Vector2 _playerStartPosition = new Vector2(8, 2);

        [Test]
        public void MovePlayerOneSolidTileUp()
        {
            MovePlayerAndAssertPostion(_player.MoveUp, new Vector2(8, 4));
        }

        [Test]
        public void MovePlayerOneSolidTileDown()
        {
            MovePlayerAndAssertPostion(_player.MoveDown, new Vector2(8, 0));
        }

        [Test]
        public void MovePlayerOneSolidTileRight()
        {
            MovePlayerAndAssertPostion(_player.MoveRight, new Vector2(10, 2));
        }

        [Test]
        public void MovePlayerOneSolidTileLeft()
        {
            MovePlayerAndAssertPostion(_player.MoveLeft, new Vector2(6, 2));
        }

        private void MovePlayerAndAssertPostion(Action MovementFunction, Vector2 currentPosition)
        {
            _player.SetPosition(_playerStartPosition);
            MovementFunction();

            AssertPreviousAndCurrentTilesPosition(currentPosition);
        }

        private void AssertPreviousAndCurrentTilesPosition(Vector2 currentTilePosition)
        {
            Assert.AreEqual(currentTilePosition, _player.position);
            Assert.IsTrue(_board.grid[(int)_playerStartPosition.X, (int)_playerStartPosition.Y].isEmpty);
            Assert.IsTrue(!_board.grid[(int)currentTilePosition.X, (int)currentTilePosition.Y].isEmpty);
        }
    }
}