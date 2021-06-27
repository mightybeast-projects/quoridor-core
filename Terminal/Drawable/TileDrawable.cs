using System;

namespace Quoridor.Terminal.Drawable
{
    public abstract class TileDrawable : IDrawable
    {
        protected string _symbol;

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(_symbol);
        }
    }
}