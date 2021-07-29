using System;
using System.Numerics;
using NUnit.Framework;

namespace Quoridor.Tests.PlayerMovement
{
    [TestFixture]
    internal class GeneralMovement : Initialization
    {
        private Action MovementFunction;
        private Vector2 _playerStartPosition;
        private Vector2 _expectedPosition;

        protected override void SetUp()
        {
            base.SetUp();
            _playerStartPosition = new Vector2(8, 2);
        }

        [Test]
        public void MovePlayerOneSolidTileUp()
        {
            MovementFunction = _firstPlayer.MoveUp;
            _expectedPosition = new Vector2(8, 4);

            MovePlayerAndAssertPostion();
        }

        [Test]
        public void MovePlayerOneSolidTileDown()
        {
            MovementFunction = _firstPlayer.MoveDown;
            _expectedPosition = new Vector2(8, 0);

            MovePlayerAndAssertPostion();
        }

        [Test]
        public void MovePlayerOneSolidTileRight()
        {
            MovementFunction = _firstPlayer.MoveRight;
            _expectedPosition = new Vector2(10, 2);

            MovePlayerAndAssertPostion();
        }

        [Test]
        public void MovePlayerOneSolidTileLeft()
        {
            MovementFunction = _firstPlayer.MoveLeft;
            _expectedPosition = new Vector2(6, 2);

            MovePlayerAndAssertPostion();
        }

        private void MovePlayerAndAssertPostion()
        {
            _firstPlayer.SetPosition(_playerStartPosition);
            MovementFunction();

            AssertPreviousAndCurrentTilesPosition();
        }

        private void AssertPreviousAndCurrentTilesPosition()
        {
            Assert.AreEqual(_expectedPosition, _firstPlayer.position);
            Assert.IsTrue(_board.grid[(int)_playerStartPosition.X, (int)_playerStartPosition.Y].isEmpty);
            Assert.IsFalse(_board.grid[(int)_expectedPosition.X, (int)_expectedPosition.Y].isEmpty);
        }
    }
}