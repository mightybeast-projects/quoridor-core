using System;
using System.Numerics;
using NUnit.Framework;
using Quoridor.Core;
using Quoridor.Core.GameLogic;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Tests.GameLogic.TwoPlayers
{
    [TestFixture]
    internal class TwoPlayersWallPlacementPathfinding : TwoPlayersGameInitialization
    {
        private Wall _lastPlacedWall;

        [Test]
        public void DoNotPlaceWalIfOtherPlayerHaveNoPathToGoal1()
        {
            _game.MakeCurrentPlayerPlaceWall(new Vector2(7, 16), new Vector2(7, 14));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(8, 15), new Vector2(10, 15));

            AssertNoPathForGoalException(
                () => _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 14), new Vector2(11, 16))
            );
            AssertLastPlacedWallCurrentPlayerAndWallCounter(_game.players[0], 9);
        }

        [Test]
        public void DoNotPlaceWalIfOtherPlayerHaveNoPathToGoal2()
        {
            _game.MakeCurrentPlayerPlaceWall(new Vector2(7, 0), new Vector2(7, 2));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(8, 1), new Vector2(10, 1));

            AssertNoPathForGoalException(
                () => _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 0), new Vector2(11, 2))
            );
            AssertLastPlacedWallCurrentPlayerAndWallCounter(_game.players[0], 9);
        }

        [Test]
        public void DoNotPlaceWalIfOtherPlayerHaveNoPathToGoal3()
        {
            _game.players[0].SetPosition(0, 0);

            _game.MakeCurrentPlayerPlaceWall(new Vector2(1, 0), new Vector2(1, 2));
            
            AssertNoPathForGoalException(
                () => _game.MakeCurrentPlayerPlaceWall(new Vector2(0, 3), new Vector2(2, 3))
            );
            AssertLastPlacedWallCurrentPlayerAndWallCounter(_game.players[1], 10);
        }

        [Test]
        public void DoNotPlaceWalIfOtherPlayerHaveNoPathToGoal4()
        {
            MakePlayersMoveToCenter();

            BuildWallOnIndex(11);

            _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 10), new Vector2(11, 12));
            
            AssertNoPathForGoalException(
                () => _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 14), new Vector2(11, 16))
            );
            AssertLastPlacedWallCurrentPlayerAndWallCounter(_game.players[1], 8);
        }

        private void MakePlayersMoveToCenter()
        {
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_UP);
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DOWN);
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_UP);
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DOWN);
        }

        private void BuildWallOnIndex(int index)
        {
            _game.MakeCurrentPlayerPlaceWall(new Vector2(0, index), new Vector2(2, index));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(4, index), new Vector2(6, index));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(8, index), new Vector2(10, index));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(12, index), new Vector2(14, index));
        }

        private void AssertLastPlacedWallCurrentPlayerAndWallCounter(Player player, int counter)
        {
            AssertLastPlacedWall();
            Assert.AreEqual(counter, player.wallCounter);
            Assert.AreEqual(player, _game.currentPlayer);
        }

        private void AssertLastPlacedWall()
        {
            _lastPlacedWall = _game.currentPlayer.lastPlacedWall;
            int startPositionX = (int)_lastPlacedWall.startPosition.X;
            int startPositionY = (int)_lastPlacedWall.startPosition.Y;
            int middlePositionX = (int)_lastPlacedWall.middlePosition.X;
            int middlePositionY = (int)_lastPlacedWall.middlePosition.Y;
            int endPositionX = (int)_lastPlacedWall.endPosition.X;
            int endPositionY = (int)_lastPlacedWall.endPosition.Y;

            Assert.IsTrue(_game.board.grid[startPositionX, startPositionY].isEmpty);
            Assert.IsTrue(_game.board.grid[middlePositionX, middlePositionY].isEmpty);
            Assert.IsTrue(_game.board.grid[endPositionX, endPositionY].isEmpty);
        }

        private void AssertNoPathForGoalException(Action MovementFunction)
        {
            Assert.Throws<NoPathForPlayerException>(
                () => MovementFunction()
            );
        }
    }
}