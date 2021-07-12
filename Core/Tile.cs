using System.Numerics;
using System;

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

        private bool _isSolid = true;
        private bool _isEmpty = true;
        private Vector2 _position;

        public Tile(Vector2 position)
        {
            _position = position;
        }
    }
}