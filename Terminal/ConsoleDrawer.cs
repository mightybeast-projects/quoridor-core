using System.Collections.Generic;
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
        private List<Player> _players;
        private Player _currentPlayer;
        private IDrawable _drawable;

        public ConsoleDrawer(Board board, List<Player> players)
        {
            _board = board;
            _players = players;
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
                DrawIndexLabel(i);
                
            Console.WriteLine();
        }

        private static void DrawIndexLabel(int i)
        {
            if (i < 10)
                Console.Write(" " + i + " ");
            else
                Console.Write(" " + i);
        }

        private void DrawBoardUnit(int i, int j)
        {
            ChooseDrawable(i, j);

            _drawable.Draw();

            Console.ResetColor();
        }

        private void ChooseDrawable(int i, int j)
        {
            for (int k = 0; k < _players.Count; k++)
            {
                Player player = _players[k];
                _currentPlayer = player;
                if (UnitIsPlayer(i, j))
                {
                    _drawable = new PlayerDrawable(k);
                    return;
                }
            }
            
            if (UnitIsWall(i, j))
                _drawable = new WallDrawable();
            else if (TileIndexesAreDividableByTwo(i, j))
                _drawable = new SolidTileDrawable();
            else
                _drawable = new VoidTileDrawable();
        }

        private bool UnitIsWall(int i, int j)
        {
            Vector2 currentPosition = new Vector2(i, j);
            foreach(Player player in _players)
                foreach(Wall wall in player.placedWalls)
                    if (CurrentPositionIsWall(currentPosition, wall) && !_board.grid[i, j].isEmpty) return true;

            return false;
        }

        private bool UnitIsPlayer(int i, int j)
        {
            return _currentPlayer.position.X == i && _currentPlayer.position.Y == j;
        }

        private bool TileIndexesAreDividableByTwo(int i, int j)
        {
            return i % 2 == 0 && j % 2 == 0;
        }

        private static bool CurrentPositionIsWall(Vector2 currentPosition, Wall wall)
        {
            return wall.startPosition == currentPosition || 
                    wall.middlePosition == currentPosition || 
                    wall.endPosition == currentPosition;
        }
    }
}