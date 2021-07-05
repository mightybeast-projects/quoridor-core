using System;

namespace Quoridor.Terminal.Drawable
{
    public class PlayerDrawable : IDrawable
    {
        private ConsoleColor _playerColor;

        public PlayerDrawable(int playerIndex)
        {
            switch(playerIndex)
            {
                case 0:
                    _playerColor = ConsoleColor.DarkRed;
                break;
                case 1:
                    _playerColor = ConsoleColor.DarkBlue;
                break;
            }
        }

        public void Draw()
        {
            Console.BackgroundColor = _playerColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" P ");
        }
    }
}