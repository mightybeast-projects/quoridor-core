using System;
using System.Numerics;

namespace Quoridor.Main
{
    public class Player
    {
        public Board board => _board;
        public Vector2 position => _position;

        private Board _board;
        private Vector2 _position;

        public Player(Board board)
        {
            _board = board;
            SetPosition(0, 0);
        }

        internal void SetPosition(int x, int y)
        {
            _position = new Vector2(x, y);
        }
    }
}