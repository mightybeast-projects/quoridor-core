using System;

namespace Quoridor.Core
{
    public class Board
    {
        public Tile[,] grid => _grid;

        private int _width;
        private int _height;

        private Tile[,] _grid;

        public Board(int width, int height)
        {
            _width = width;
            _height = height;

            GenerateGrid();
        }

        private void GenerateGrid()
        {
            _grid = new Tile[_width, _height];
            for(int i = 0; i < _grid.GetLength(0); i++)
                for(int j = 0; j < _grid.GetLength(1); j++)
                    GenerateNewTile(i, j);
        }

        private void GenerateNewTile(int i, int j)
        {
            Tile newTile;
            if (TileIndexesAreDividableByTwo(i, j))
                newTile = new SolidTile();
            else
                newTile = new VoidTile();

            _grid[i, j] = newTile;
        }

        private bool TileIndexesAreDividableByTwo(int i, int j)
        {
            return i % 2 == 0 && j % 2 == 0;
        }
    }
}