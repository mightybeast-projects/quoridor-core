using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.GameLogic;
using Quoridor.Core.PlayerLogic.Movement.Exceptions;
using Quoridor.Core.PlayerLogic.WallPlacement.Exceptions;

namespace Quoridor.Tests.GameLogic.TwoPlayers
{
    [TestFixture]
    internal class TwoPlayersBasicGameLogic : TwoPlayersGameInitialization
    {
        [Test]
        public void SwitchCurrentPlayerAfterCorrectMove()
        {
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_UP);

            Assert.AreEqual(new Vector2(8, 2), _game.players[0].position);
            Assert.AreEqual(_game.players[1], _game.currentPlayer);
        }

        [Test]
        public void SwitchBackToFirstPlayerAfterSecondPlayerMoved()
        {
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_UP);

            Assert.AreEqual(new Vector2(8, 2), _game.players[0].position);

            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DOWN);

            Assert.AreEqual(new Vector2(8, 14), _game.players[1].position);
            Assert.AreEqual(_game.players[0], _game.currentPlayer);
        }

        [Test]
        public void DoNotSwitchPlayerAfterWrongMove()
        {
            Assert.Throws<MoveBeyondBoardException>( () =>
                _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DOWN)
            );
            Assert.AreEqual(new Vector2(8, 0), _game.players[0].position);
            Assert.AreEqual(_game.players[0], _game.currentPlayer);
        }

        [Test]
        public void SwitchCurrentPlayerAfterCorrectWallPlacement()
        {
            _game.MakeCurrentPlayerPlaceWall(new Vector2(0, 1), new Vector2(2, 1));

            Assert.AreEqual(9, _game.players[0].wallCounter);
            Assert.AreEqual(_game.players[1], _game.currentPlayer);
        }

        [Test]
        public void DoNotSwitchPlayerAfterWrongWallPlacement()
        {
            Assert.Throws<WallIsBeyondBoardException>( () =>
                _game.MakeCurrentPlayerPlaceWall(new Vector2(-1, 1), new Vector2(2, 1))
            );

            Assert.AreEqual(10, _game.players[0].wallCounter);
            Assert.AreEqual(_game.players[0], _game.currentPlayer);
        }

        [Test]
        public void DoNotAddMoreThanFourPlayers()
        {
            _game.AddNewPlayerPair();
            _game.AddNewPlayerPair();

            Assert.AreEqual(4, _game.players.Count);
        }
    }
}