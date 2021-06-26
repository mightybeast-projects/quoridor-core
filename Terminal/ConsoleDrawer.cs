using System;
using System.Numerics;
using Quoridor.Core;

namespace Quoridor.Terminal
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

        public void DrawBoard()
        {
            for (int i = _board.grid.GetLength(0) - 1; i >= 0 ; i--){
                for (int j = 0; j < _board.grid.GetLength(1); j++)
                    DrawBoardUnit(j, i);
                Console.WriteLine();
            }
        }

        private void DrawBoardUnit(int i, int j)
        {
            if (UnitIsPlayer(i, j))
                _player.Draw();
            else if (UnitIsWall(i, j))
                _player.placedWalls[0].Draw();
            else
            {
                Tile tile = _board.grid[i, j];
                tile.Draw();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private bool UnitIsWall(int i, int j)
        {
            Vector2 currentPosition = new Vector2(i, j);
            foreach(Wall wall in _player.placedWalls)
                if (CurrentPositionIsWall(currentPosition, wall)) return true;

            return false;
        }

        private static bool CurrentPositionIsWall(Vector2 currentPosition, Wall wall)
        {
            return wall.startPosition == currentPosition || 
                    wall.middlePosition == currentPosition || 
                    wall.endPosition == currentPosition;
        }

        private bool UnitIsPlayer(int i, int j)
        {
            return _player.position.X == i && _player.position.Y == j;
        }
    }
}