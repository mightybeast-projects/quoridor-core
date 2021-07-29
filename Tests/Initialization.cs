using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using Quoridor.Core;
using Quoridor.Core.GameLogic;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Tests
{
    internal class Initialization
    {
        protected Tile _tile;
        protected Board _board;
        protected Wall _wall;
        protected Player _firstPlayer;
        protected Player _secondPlayer;
        protected Player _thirdPlayer;
        protected Game _game;
        protected List<Player> _players;

        [SetUp]
        protected virtual void SetUp()
        {
            _tile = new Tile(new Vector2(0, 0));
            _board = new Board();
            _firstPlayer = new Player(_board);
            _secondPlayer = new Player(_board);
            _thirdPlayer = new Player(_board);
            _players = new List<Player>();

            _game = new Game();
        }
    }
}