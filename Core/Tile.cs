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
        public List<Tile> preNeighbors => _preNeighbors;
        public List<Tile> neighbors
        { 
            get => _neighbors;
            set => _neighbors = value; 
        }
        public float f { get => _f; set => _f = value; }
        public float g { get => _g; set => _g = value; }
        public float h { get => _h; set => _h = value; }
        public Tile parent { get => _parent; set => _parent = value; }

        private bool _isSolid = true;
        private bool _isEmpty = true;
        private Vector2 _position;
        private List<Tile> _preNeighbors;
        private List<Tile> _neighbors;
        private float _f;
        private float _g;
        private float _h;
        private Tile _parent;

        public Tile(Vector2 position)
        {
            _position = position;

            _neighbors = new List<Tile>();
            _preNeighbors = new List<Tile>();
        }

        public List<Tile> GetNeighbours()
        {
            List<Tile> tmpNeighbours = new List<Tile>();
                for (int i = 0; i < _neighbors.Count; i++)
                    if (_preNeighbors[i].isEmpty)
                        tmpNeighbours.Add(_neighbors[i]);
            return tmpNeighbours;
        }
    }
}