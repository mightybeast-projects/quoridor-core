using System;
using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.PlayerLogic.Movement.Exceptions;

namespace Quoridor.Tests.PlayerMovement
{
    [TestFixture]
    internal class BoardEdgeMovement : Initialization
    {
        private Vector2 _playerPosition;
        private Action MovementFunction;

        [Test]
        public void MovePlayerOnTopEdgeOneSolidTileUp()
        {
            _playerPosition = new Vector2(8, 16);
            MovementFunction = _firstPlayer.MoveUp;
            
            AssertNothingChangedAfterMoveOnEdge();
        }

        [Test]
        public void MovePlayerOnBottomEdgeOneSolidTileDown()
        {
            _playerPosition = new Vector2(8, 0);
            MovementFunction = _firstPlayer.MoveDown;
            
            AssertNothingChangedAfterMoveOnEdge();
        }

        [Test]
        public void MovePlayerOnRightEdgeOneSolidTileRight()
        {
            _playerPosition = new Vector2(16, 0);
            MovementFunction = _firstPlayer.MoveRight;
            
            AssertNothingChangedAfterMoveOnEdge();
        }

        [Test]
        public void MovePlayerOnLeftEdgeOneSolidTileLeft()
        {
            _playerPosition = new Vector2(0, 0);
            MovementFunction = _firstPlayer.MoveLeft;
            
            AssertNothingChangedAfterMoveOnEdge();
        }

        private void AssertNothingChangedAfterMoveOnEdge()
        {
            _firstPlayer.SetPosition(_playerPosition);
            AssertBeyondBoardException(MovementFunction);

            Assert.AreEqual(_playerPosition, _firstPlayer.position);
            Assert.IsTrue(!_board.grid[(int)_playerPosition.X, (int)_playerPosition.Y].isEmpty);
        }

        private void AssertBeyondBoardException(Action MovementFunction)
        {
            Assert.Throws<MoveBeyondBoardException>(
                () => MovementFunction()
            );
        }
    }
}