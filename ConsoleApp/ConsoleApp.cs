using System;
using Quoridor.Main;

namespace Quoridor.ConsoleApp
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