using System;
using System.Numerics;
using Quoridor.Core;
using Quoridor.Core.Player;
using Quoridor.Terminal.Drawable;

namespace Quoridor.Terminal
{
    public class ConsoleDrawer
    {
        private Board _board;
        private Player _player;
        private IDrawable _drawable;

        public ConsoleDrawer(Board board, Player player)
        {
            _board = board;
            _player = player;
        }

        public void DrawBoard()
        {
            DrawTiles();
            DrawIndexLines();
        }

        private void DrawTiles()
        {
            for (int i = _board.grid.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < _board.grid.GetLength(1); j++)
                    DrawBoardUnit(j, i);
                Console.WriteLine(" " + i);
            }
        }

        private void DrawIndexLines()
        {
            for (int i = 0; i < _board.grid.GetLength(1); i++)
            {
                if (i < 10)
                    Console.Write(" " + i + " ");
                else
                    Console.Write(" " + i);
            }
            Console.WriteLine();
        }

        private void DrawBoardUnit(int i, int j)
        {
            if (UnitIsPlayer(i, j))
                _drawable = new PlayerDrawable();
            else if (UnitIsWall(i, j))
                _drawable = new WallDrawable();
            else
            {
                if(TileIndexesAreDividableByTwo(i, j))
                    _drawable = new SolidTileDrawable();
                else
                    _drawable = new VoidTileDrawable();
            }

            _drawable.Draw();

            Console.ResetColor();
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

        private bool TileIndexesAreDividableByTwo(int i, int j)
        {
            return i % 2 == 0 && j % 2 == 0;
        }
    }
}