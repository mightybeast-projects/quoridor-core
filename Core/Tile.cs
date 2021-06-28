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

        private bool _isSolid = true;
        private bool _isEmpty = true;
    }
}