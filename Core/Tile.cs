using System;

namespace Quoridor.Main
{
    public abstract class Tile
    {
        public bool isSolid => _solid;

        protected bool _solid;
        protected string _symbol;

        public void Draw()
        {
            Console.Write(_symbol);
        }
    }
}