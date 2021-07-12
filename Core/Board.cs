using System;
using System.Collections.Generic;

namespace Quoridor.Core
{
    public class Board
    {
        public Tile[,] grid => _grid;
        public List<Wall> placedWalls => _placedWalls;
        
        private Tile[,] _grid;
        private List<Wall> _placedWalls;

        public Board()
        {
            _placedWalls = new List<Wall>();
            
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            _grid = new Tile[17, 17];
            for(int i = 0; i < _grid.GetLength(0); i++)
                for(int j = 0; j < _grid.GetLength(1); j++)
                    GenerateNewTile(i, j);
        }

        private void GenerateNewTile(int i, int j)
        {
            Tile newTile = new Tile();
            newTile.isSolid = TileIndexesAreDividableByTwo(i, j);

            _grid[i, j] = newTile;
        }

        private bool TileIndexesAreDividableByTwo(int i, int j)
        {
            return i % 2 == 0 && j % 2 == 0;
        }
    }
}