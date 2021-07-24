using System;
using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.GameLogic;

namespace Quoridor.Tests.PlayerMovement
{
    [TestFixture]
    public class PlayerOnTheWayMovement : Initialization
    {
        private Vector2 _firstPlayerPosition;
        private Vector2 _secondPlayerPosition;
        private Vector2 _expectedPosition;
        private Action FirstPlayerMovementFunction;

        [Test]
        public void PlayerOnTheWayUp()
        {
            _firstPlayerPosition = new Vector2(8, 8);
            _secondPlayerPosition = new Vector2(8, 10);
            _expectedPosition = new Vector2(8, 12);
            FirstPlayerMovementFunction = _firstPlayer.MoveUp;

            MoveAndAssertWhilePlayerOnTheWay();
        }

        [Test]
        public void PlayerOnTheWayDown()
        {
            _firstPlayerPosition = new Vector2(8, 10);
            _secondPlayerPosition = new Vector2(8, 8);
            _expectedPosition = new Vector2(8, 6);
            FirstPlayerMovementFunction = _firstPlayer.MoveDown;

            MoveAndAssertWhilePlayerOnTheWay();
        }

        [Test]
        public void PlayerOnTheWayRight()
        {
            _firstPlayerPosition = new Vector2(8, 8);
            _secondPlayerPosition = new Vector2(10, 8);
            _expectedPosition = new Vector2(12, 8);
            FirstPlayerMovementFunction = _firstPlayer.MoveRight;

            MoveAndAssertWhilePlayerOnTheWay();
        }

        [Test]
        public void PlayerOnTheWayLeft()
        {
            _firstPlayerPosition = new Vector2(8, 8);
            _secondPlayerPosition = new Vector2(6, 8);
            _expectedPosition = new Vector2(4, 8);
            FirstPlayerMovementFunction = _firstPlayer.MoveLeft;

            MoveAndAssertWhilePlayerOnTheWay();
        }

        [Test]
        public void PlayerOnTheWayUpAndOnTheEdge()
        {
            _firstPlayerPosition = new Vector2(8, 14);
            _secondPlayerPosition = new Vector2(8, 16);
            FirstPlayerMovementFunction = _firstPlayer.MoveUp;

            MoveAndAssertThatNothingChanged();
        }

        [Test]
        public void PlayerOnTheWayDownAndOnTheEdge()
        {
            _firstPlayerPosition = new Vector2(8, 2);
            _secondPlayerPosition = new Vector2(8, 0);
            FirstPlayerMovementFunction = _firstPlayer.MoveDown;

            MoveAndAssertThatNothingChanged();
        }

        [Test]
        public void PlayerOnTheWayLeftAndOnTheEdge()
        {
            _firstPlayerPosition = new Vector2(2, 0);
            _secondPlayerPosition = new Vector2(0, 0);
            FirstPlayerMovementFunction = _firstPlayer.MoveLeft;

            MoveAndAssertThatNothingChanged();
        }

        private void MoveAndAssertThatNothingChanged()
        {
            ApplyInitializedFields();

            Assert.IsFalse(
                _board.grid[(int)_firstPlayerPosition.X, (int)_firstPlayerPosition.Y]
                .isEmpty);
            Assert.IsFalse(
                _board.grid[(int)_secondPlayerPosition.X, (int)_secondPlayerPosition.Y]
                .isEmpty);
            Assert.AreEqual(
                new Vector2((int)_firstPlayerPosition.X, (int)_firstPlayerPosition.Y),
                _firstPlayer.position);
        }

        private void MoveAndAssertWhilePlayerOnTheWay()
        {
            ApplyInitializedFields();

            Assert.IsTrue(
                _board.grid[(int) _firstPlayerPosition.X, (int) _firstPlayerPosition.Y]
                .isEmpty);
            Assert.IsFalse(
                _board.grid[(int) _secondPlayerPosition.X, (int) _secondPlayerPosition.Y]
                .isEmpty);
            Assert.IsFalse(
                _board.grid[(int) _expectedPosition.X, (int) _expectedPosition.Y]
                .isEmpty);
            Assert.AreEqual(
                new Vector2((int) _expectedPosition.X, (int) _expectedPosition.Y), 
                _firstPlayer.position);
        }

        private void ApplyInitializedFields()
        {
            _firstPlayer.SetPosition(_firstPlayerPosition);
            _secondPlayer.SetPosition(_secondPlayerPosition);
            FirstPlayerMovementFunction();
        }
    }
}