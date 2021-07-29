using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.PlayerLogic.Movement.Exceptions;

namespace Quoridor.Tests.PlayerMovement
{
    [TestFixture]
    public class TwoPlayersOnTheWayMovement : Initialization
    {
        [Test]
        public void DoNotJumpOverTwoOtherPlayers()
        {
            _firstPlayer.SetPosition(6, 6);
            _secondPlayer.SetPosition(8, 6);
            _thirdPlayer.SetPosition(10, 6);

            Assert.Throws<JumpOverTwoPlayersException>(
                () =>  _firstPlayer.MoveRight()
            );
            Assert.AreEqual(new Vector2(6, 6), _firstPlayer.position);
        }

        [Test]
        public void DoDiagonalMoveIfThereIsTwoPlayersOnTheWay()
        {
            _firstPlayer.SetPosition(6, 6);
            _secondPlayer.SetPosition(8, 6);
            _thirdPlayer.SetPosition(10, 6);

            _firstPlayer.MoveDiagonallyBottomRight();

            Assert.AreEqual(new Vector2(8, 4), _firstPlayer.position);
        }
    }
}