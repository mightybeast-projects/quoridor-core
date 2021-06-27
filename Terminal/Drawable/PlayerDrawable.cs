using System;

namespace Quoridor.Terminal.Drawable
{
    public class PlayerDrawable : IDrawable
    {
        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" P ");
        }
    }
}