using System.Numerics;
using NUnit.Framework;
using Pathfinding;
using Quoridor.Core;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Tests.Pathfinding
{
    [TestFixture]
    public class AStarPathfinding : Initialization
    {
        private Player _player;
        private AStar _algo;
        private Tile _start;
        private Tile _goal;

        protected override void SetUp()
        {
            base.SetUp();
            _algo = new AStar(_board);
            _goal = _board.grid[8, 16];
        }

        [Test]
        public void ThereIsPathToGoalInEmptyBoard()
        {
            _start = _board.grid[8, 0];

            _algo.DoAStar(_start, _goal);

            Assert.IsTrue(_algo.path.Count > 0);
        }

        [Test]
        public void ThereIsNoPathToGoal1()
        {
            AddPlayerToTheBoard();
            
            _player.PlaceWall(new Vector2(7, 0), new Vector2(7, 2));
            _player.PlaceWall(new Vector2(8, 3), new Vector2(10, 3));
            _player.PlaceWall(new Vector2(11, 0), new Vector2(11, 2));

            ExecuteAlgorithmAndAssertNoPath();
        }

        [Test]
        public void ThereIsNoPathToGoal2()
        {
            AddPlayerToTheBoard();
            
            _player.PlaceWall(new Vector2(7, 16), new Vector2(7, 14));
            _player.PlaceWall(new Vector2(8, 13), new Vector2(10, 13));
            _player.PlaceWall(new Vector2(9, 14), new Vector2(9, 16));

            ExecuteAlgorithmAndAssertNoPath();
        }

        private void AddPlayerToTheBoard()
        {
            _player = new Player(_board);
            _player.SetPosition(8, 0);
            _start = _board.grid[(int) _player.position.X, (int) _player.position.Y];
        }

        private void ExecuteAlgorithmAndAssertNoPath()
        {
            _algo.DoAStar(_start, _goal);

            Assert.IsTrue(_algo.path.Count == 0);
        }
    }
}