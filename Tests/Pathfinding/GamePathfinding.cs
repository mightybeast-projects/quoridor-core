using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.GameLogic;

namespace Quoridor.Tests.Pathfinding
{
    [TestFixture]
    public class GamePathfinding : Initialization
    {
        //[Test]
        public void CheckPathOnFirstMove()
        {
            _players.Add(_firstPlayer);
            _players.Add(_secondPlayer);
            _game = new Game(_board, _players);
            
            Assert.IsTrue(_game.PlayerHavePathToGoal(_firstPlayer));
            Assert.IsTrue(_game.PlayerHavePathToGoal(_secondPlayer));
        }

        //[Test]
        public void CheckPathAfterSeveralMoves()
        {
            _players.Add(_firstPlayer);
            _players.Add(_secondPlayer);
            _game = new Game(_board, _players);

            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_UP);
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DOWN);
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_UP);
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DOWN);

            BuildWallOnIndex(11);

            Assert.IsTrue(_game.PlayerHavePathToGoal(_firstPlayer));
            Assert.IsTrue(_game.PlayerHavePathToGoal(_secondPlayer));
        }

        //[Test]
        public void NoPathForFirstPlayer1()
        {
            _players.Add(_firstPlayer);
            _players.Add(_secondPlayer);
            _game = new Game(_board, _players);

            _game.MakeCurrentPlayerPlaceWall(new Vector2(7, 0), new Vector2(7, 2));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(8, 1), new Vector2(10, 1));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 0), new Vector2(11, 2));

            Assert.IsFalse(_game.PlayerHavePathToGoal(_firstPlayer));
            Assert.IsTrue(_game.PlayerHavePathToGoal(_secondPlayer));
        }

        //[Test]
        public void NoPathForSecondPlayer1()
        {
            _players.Add(_firstPlayer);
            _players.Add(_secondPlayer);
            _game = new Game(_board, _players);

            _game.MakeCurrentPlayerPlaceWall(new Vector2(7, 16), new Vector2(7, 14));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(8, 15), new Vector2(10, 15));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 14), new Vector2(11, 16));

            Assert.IsTrue(_game.PlayerHavePathToGoal(_firstPlayer));
            Assert.IsFalse(_game.PlayerHavePathToGoal(_secondPlayer));
        }

        //[Test]
        public void NoPathForSecondPlayer2()
        {
            _players.Add(_firstPlayer);
            _players.Add(_secondPlayer);
            _game = new Game(_board, _players);

            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_UP);
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DOWN);
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_UP);
            _game.MakeCurrentPlayerMove(PlayerMove.MOVE_DOWN);

            BuildWallOnIndex(11);

            _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 10), new Vector2(11, 12));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 14), new Vector2(11, 16));

            Assert.IsTrue(_game.PlayerHavePathToGoal(_firstPlayer));
            Assert.IsFalse(_game.PlayerHavePathToGoal(_secondPlayer));
        }

        //[Test]
        public void NoPathForFirstPlayerAtTheCorner()
        {
            _players.Add(_firstPlayer);
            _players.Add(_secondPlayer);
            _game = new Game(_board, _players);
            _firstPlayer.SetPosition(0, 0);

            _game.MakeCurrentPlayerPlaceWall(new Vector2(1, 0), new Vector2(1, 2));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(0, 3), new Vector2(2, 3));

            Assert.IsFalse(_game.PlayerHavePathToGoal(_firstPlayer));
            Assert.IsTrue(_game.PlayerHavePathToGoal(_secondPlayer));
        }

        private void BuildWallOnIndex(int index)
        {
            _game.MakeCurrentPlayerPlaceWall(new Vector2(0, index), new Vector2(2, index));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(4, index), new Vector2(6, index));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(8, index), new Vector2(10, index));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(12, index), new Vector2(14, index));
        }
    }
}