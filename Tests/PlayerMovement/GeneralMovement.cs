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
            MovePlayerAndAssertPostion(_firstPlayer.MoveUp, new Vector2(8, 4));
        }

        [Test]
        public void MovePlayerOneSolidTileDown()
        {
            MovePlayerAndAssertPostion(_firstPlayer.MoveDown, new Vector2(8, 0));
        }

        [Test]
        public void MovePlayerOneSolidTileRight()
        {
            MovePlayerAndAssertPostion(_firstPlayer.MoveRight, new Vector2(10, 2));
        }

        [Test]
        public void MovePlayerOneSolidTileLeft()
        {
            MovePlayerAndAssertPostion(_firstPlayer.MoveLeft, new Vector2(6, 2));
        }

        private void MovePlayerAndAssertPostion(Action MovementFunction, Vector2 currentPosition)
        {
            _firstPlayer.SetPosition(_playerStartPosition);
            MovementFunction();

            AssertPreviousAndCurrentTilesPosition(currentPosition);
        }

        private void AssertPreviousAndCurrentTilesPosition(Vector2 currentTilePosition)
        {
            Assert.AreEqual(currentTilePosition, _firstPlayer.position);
            Assert.IsTrue(_board.grid[(int)_playerStartPosition.X, (int)_playerStartPosition.Y].isEmpty);
            Assert.IsTrue(!_board.grid[(int)currentTilePosition.X, (int)currentTilePosition.Y].isEmpty);
        }
    }
}