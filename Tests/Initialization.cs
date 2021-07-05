using NUnit.Framework;
using Quoridor.Core;
using Quoridor.Core.Player;

namespace Quoridor.Tests
{
    public class Initialization
    {
        protected Tile _tile;
        protected Board _board;
        protected Player _firstPlayer;
        protected Player _secondPlayer;
        protected Wall _wall;

        [SetUp]
        protected void SetUp()
        {
            _tile = new Tile();
            _board = new Board(17, 17);
            _firstPlayer = new Player(_board);
            _secondPlayer = new Player(_board);
        }
    }
}