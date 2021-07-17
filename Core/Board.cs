using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.VisualStudio.TestPlatform.Common.Filtering;

namespace Quoridor.Core
{
    public class Board
    {
        public Tile[,] grid => _grid;
        public List<Wall> placedWalls => _placedWalls;
        
        private Tile[,] _grid;
        private List<Wall> _placedWalls;

        private Tile _currentTile;

        public Board()
        {
            _placedWalls = new List<Wall>();
            
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            _grid = new Tile[17, 17];

            for (int i = 0; i < _grid.GetLength(0); i++)
                for (int j = 0; j < _grid.GetLength(1); j++)
                    GenerateNewTile(i, j);

            for (int i = 0; i < _grid.GetLength(0); i += 2)
            {
                for (int j = 0; j < _grid.GetLength(1); j += 2)
                {
                    _currentTile = _grid[i, j];

                    AddPreNeighborTile(i, j + 1);
                    AddNeighborTile(i, j + 2);

                    AddPreNeighborTile(i + 1, j);
                    AddNeighborTile(i + 2, j);

                    AddPreNeighborTile(i, j - 1);
                    AddNeighborTile(i, j - 2);

                    AddPreNeighborTile(i - 1, j);
                    AddNeighborTile(i - 2, j);
                }
            }
        }

        private void AddPreNeighborTile(int tileX, int tileY)
        {
            try
            {
                _currentTile.preNeighbors.Add(_grid[tileX, tileY]);
            }
            catch (IndexOutOfRangeException) {}
        }

        private void AddNeighborTile(int tileX, int tileY)
        {
            try
            {
                _currentTile.neighbors.Add(_grid[tileX, tileY]);
            }
            catch (IndexOutOfRangeException) {}
        }

        private void GenerateNewTile(int i, int j)
        {
            Tile newTile = new Tile(new Vector2(i, j));
            newTile.isSolid = TileIndexesAreDividableByTwo(i, j);

            _grid[i, j] = newTile;
        }

        private bool TileIndexesAreDividableByTwo(int i, int j)
        {
            return i % 2 == 0 && j % 2 == 0;
        }
    }
}