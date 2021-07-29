using System;
using System.Collections.Generic;
using System.Numerics;

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
                for (int j = 0; j < _grid.GetLength(1); j += 2)
                    InitializeNeighboursForTileWithIndexes(i, j);
        }

        private void InitializeNeighboursForTileWithIndexes(int i, int j)
        {
            _currentTile = _grid[i, j];

            AddAdjacentTilesToListWithIndex(_currentTile.preNeighbors, 1);
            AddAdjacentTilesToListWithIndex(_currentTile.neighbors, 2);
        }

        private void AddAdjacentTilesToListWithIndex(List<Tile> list, int neighborIndex)
        {
            int i = (int) _currentTile.position.X;
            int j = (int) _currentTile.position.Y;

            AddAdjacentTileToList(list, i, j + neighborIndex);
            AddAdjacentTileToList(list, i + neighborIndex, j);
            AddAdjacentTileToList(list, i, j - neighborIndex);
            AddAdjacentTileToList(list, i - neighborIndex, j);
        }

        private void AddAdjacentTileToList(List<Tile> list, int tileX, int tileY)
        {
            try
            {
                list.Add(_grid[tileX, tileY]);
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