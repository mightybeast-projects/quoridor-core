using NUnit.Framework;
using Quoridor.Core;
using Quoridor.Core.Player;

namespace Quoridor.Tests
{
    public class Initialization
    {
        protected SolidTile _testSolidTile;
        protected VoidTile  _testVoidTile;
        protected Board _board;
        protected Player _player;
        protected Wall _wall;

        [SetUp]
        protected void SetUp()
        {
            _testSolidTile = new SolidTile();
            _testVoidTile = new VoidTile();
            _board = new Board(17, 17);
            _player = new Player(_board);
        }
    }
}