using System;

namespace Quoridor.Terminal
{
    public class ConsoleApp : IOutput
    {
        private ConsoleDrawer _drawer;

        public ConsoleApp(ConsoleDrawer drawer)
        {
            _drawer = drawer;
        }

        public void Start()
        {
            _drawer.DrawAllObjects();
        }
    }
}