using System;
using Quoridor.Core;

namespace Quoridor.ConsoleApp
{
    public class ConsoleDrawer
    {
        private Board _board;
        private Player _player;

        public ConsoleDrawer(Board board, Player player)
        {
            _board = board;
            _player = player;
        }

        public void DrawAllObjects()
        {
            for (int i = 0; i < _board.grid.GetLength(0); i++)
            {
                for (int j = 0; j < _board.grid.GetLength(1); j++)
                {
                    Tile tile = _board.grid[i, j];
                    tile.Draw();
                }
                Console.WriteLine();
            }
        }
    }
}