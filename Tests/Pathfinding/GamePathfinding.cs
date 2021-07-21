using NUnit.Framework;
using Quoridor.Core.GameLogic;

namespace Quoridor.Tests.Pathfinding
{
    [TestFixture]
    public class GamePathfinding : Initialization
    {
        [Test]
        public void CheckPathOnFirstMove()
        {
            _players.Add(_firstPlayer);
            _players.Add(_secondPlayer);
            _game = new Game(_board, _players);
            
            Assert.IsTrue(_game.PlayerHavePathToGoal(_players[0]));
            Assert.IsTrue(_game.PlayerHavePathToGoal(_players[1]));
        }
    }
}