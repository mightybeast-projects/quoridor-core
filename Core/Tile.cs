using System.Numerics;
using System;
using System.Collections.Generic;

namespace Quoridor.Core
{
    public class Tile
    {
        public bool isSolid 
        { 
            get => _isSolid; 
            set => _isSolid = value;
        }
        public bool isEmpty 
        {
            get => _isEmpty; 
            set => _isEmpty = value;
        }
        public Vector2 position => _position;
        public List<Tile> neighbors => _neighbors;
        public List<Tile> preNeighbors => _preNeighbors;

        private bool _isSolid = true;
        private bool _isEmpty = true;
        private Vector2 _position;
        private List<Tile> _neighbors;
        private List<Tile> _preNeighbors;

        public Tile(Vector2 position)
        {
            _position = position;

            _neighbors = new List<Tile>();
            _preNeighbors = new List<Tile>();
        }
    }
}