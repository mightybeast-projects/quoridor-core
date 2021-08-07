using System.Numerics;
using System.Collections.Generic;
using Pathfinding;

namespace Quoridor.Core
{
    public class Tile : IPathfindingNode
    {
        public bool isSolid { get; set; }
        public bool isEmpty { get; set; }
        public Vector2 position => _position;
        public List<Tile> preNeighbors => _preNeighbors;
        public List<Tile> neighbors
        { 
            get => _neighbors;
            set => _neighbors = value; 
        }
        public float f { get; set; }
        public float g { get; set; }
        public float h { get; set; }
        public IPathfindingNode parent { get; set; }

        private Vector2 _position;
        private List<Tile> _preNeighbors;
        private List<Tile> _neighbors;

        public Tile(Vector2 position)
        {
            _position = position;
            isSolid = true;
            isEmpty = true;

            _neighbors = new List<Tile>();
            _preNeighbors = new List<Tile>();
        }

        public List<IPathfindingNode> GetPathfindingNeighbours()
        {
            List<IPathfindingNode> tmpNeighbours = new List<IPathfindingNode>();
                for (int i = 0; i < _neighbors.Count; i++)
                    if (_preNeighbors[i].isEmpty)
                        tmpNeighbours.Add(_neighbors[i]);
            return tmpNeighbours;
        }
    }
}