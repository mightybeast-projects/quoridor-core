using System;

namespace Quoridor.Core
{
    public abstract class Tile
    {
        public bool isSolid => _solid;
        public bool isEmpty {
            get => _isEmpty; 
            set
            {
                _isEmpty = value;
            }
        }
        protected bool _solid;
        protected string _symbol;
        private bool _isEmpty = true;
    }
}