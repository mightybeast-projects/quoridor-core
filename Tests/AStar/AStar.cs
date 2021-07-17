using System.Numerics;
using NUnit.Framework;
using Quoridor.Core;

namespace Quoridor.Tests.AStar
{
    [TestFixture]
    public class AStar : Initialization
    {
        [Test]
        public void CheckNeighbors()
        {
            Tile tile24 = _board.grid[2, 4];
            Tile tile23 = _board.grid[2, 3];
            Tile tile42 = _board.grid[4, 2];
            Tile tile32 = _board.grid[3, 2];
            Tile tile20 = _board.grid[2, 0];
            Tile tile21 = _board.grid[2, 1];
            Tile tile02 = _board.grid[0, 2];
            Tile tile12 = _board.grid[1, 2];

            Tile tile22 = _board.grid[2, 2];

            Tile tile01 = _board.grid[0, 1];
            Tile tile10 = _board.grid[1, 0];

            Tile tile00 = _board.grid[0, 0];

            Tile tile1516 = _board.grid[15, 16];
            Tile tile1416 = _board.grid[14, 16];
            Tile tile1615 = _board.grid[16, 15];
            Tile tile1614 = _board.grid[16, 14];

            Tile tile1616 = _board.grid[16, 16];

            Assert.AreEqual(4, tile22.preNeighbors.Count);
            Assert.AreEqual(4, tile22.neighbors.Count);
            
            Assert.AreEqual(tile23.position, tile22.preNeighbors[0].position);
            Assert.AreEqual(tile24.position, tile22.neighbors[0].position);
            Assert.AreEqual(tile32.position, tile22.preNeighbors[1].position);
            Assert.AreEqual(tile42.position, tile22.neighbors[1].position);
            Assert.AreEqual(tile21.position, tile22.preNeighbors[2].position);
            Assert.AreEqual(tile20.position, tile22.neighbors[2].position);
            Assert.AreEqual(tile12.position, tile22.preNeighbors[3].position);
            Assert.AreEqual(tile02.position, tile22.neighbors[3].position);

            Assert.AreEqual(2, tile00.preNeighbors.Count);
            Assert.AreEqual(2, tile00.neighbors.Count);

            Assert.AreEqual(tile01.position, tile00.preNeighbors[0].position);
            Assert.AreEqual(tile02.position, tile00.neighbors[0].position);
            Assert.AreEqual(tile10.position, tile00.preNeighbors[1].position);
            Assert.AreEqual(tile20.position, tile00.neighbors[1].position);

            Assert.AreEqual(2, tile1616.preNeighbors.Count);
            Assert.AreEqual(2, tile1616.neighbors.Count);

            Assert.AreEqual(tile1615.position, tile1616.preNeighbors[0].position);
            Assert.AreEqual(tile1614.position, tile1616.neighbors[0].position);
            Assert.AreEqual(tile1516.position, tile1616.preNeighbors[1].position);
            Assert.AreEqual(tile1416.position, tile1616.neighbors[1].position);
        }
    }
}