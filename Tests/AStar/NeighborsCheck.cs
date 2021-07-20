using System;
using System.Collections.Generic;
using NUnit.Framework;
using Quoridor.Core;

namespace Quoridor.Tests.AStar
{
    [TestFixture]
    public class NeighborsCheck : Initialization
    {
        private List<Tile> _preNeighbors;
        private List<Tile> _neighbors;
        private Tile _tileToCheck;
        private int _tileX;
        private int _tileY;
        private int _arrayCountToCheck;

        [Test]
        public void CheckNeighbors()
        {
            CheckSimpleTile(_board.grid[8, 8]);

            CheckEdgeTile(_board.grid[8, 0]);
            CheckEdgeTile(_board.grid[8, 16]);

            CheckCornerTile(_board.grid[0, 0]);
            CheckCornerTile(_board.grid[16, 16]);
        }

        private void CheckSimpleTile(Tile tile)
        {
            _tileToCheck = tile;
            _arrayCountToCheck = 4;
            CheckTile();
        }

        private void CheckEdgeTile(Tile tile)
        {
            _tileToCheck = tile;
            _arrayCountToCheck = 3;
            CheckTile();
        }

        private void CheckCornerTile(Tile tile)
        {
            _tileToCheck = tile;
            _arrayCountToCheck = 2;
            CheckTile();
        }

        private void CheckTile()
        {
            InitializeFields();
            AssertTileArrayCount();
            CheckTileNeighbors();
        }

        private void InitializeFields()
        {
            _preNeighbors = new List<Tile>();
            _neighbors = new List<Tile>();
            _tileX = (int) _tileToCheck.position.X;
            _tileY = (int) _tileToCheck.position.Y;
        }

        private void CheckTileNeighbors()
        {
            AddAdjacentTilesToListWithIndex(_preNeighbors, 1);
            AddAdjacentTilesToListWithIndex(_neighbors, 2);
            AssertAllNeighbors();
        }

        private void AssertAllNeighbors()
        {
            for (int i = 0; i < _tileToCheck.preNeighbors.Count; i++)
            {
                Assert.AreEqual(_preNeighbors[i].position, _tileToCheck.preNeighbors[i].position);
                Assert.AreEqual(_neighbors[i].position, _tileToCheck.neighbors[i].position);
            }
        }

        private void AddAdjacentTilesToListWithIndex(List<Tile> list, int neighborIndex)
        {
            TryToAddAjacentTileTo(list, _tileX, _tileY + neighborIndex);
            TryToAddAjacentTileTo(list, _tileX + neighborIndex, _tileY);
            TryToAddAjacentTileTo(list, _tileX, _tileY - neighborIndex);
            TryToAddAjacentTileTo(list, _tileX - neighborIndex, _tileY);
        }

        private void TryToAddAjacentTileTo(List<Tile> list, int x, int y)
        {
            try { list.Add(_board.grid[x, y]); } 
            catch (IndexOutOfRangeException) {}
        }

        private void AssertTileArrayCount()
        {
            Assert.AreEqual(_arrayCountToCheck, _tileToCheck.preNeighbors.Count);
            Assert.AreEqual(_arrayCountToCheck, _tileToCheck.neighbors.Count);
        }
    }
}