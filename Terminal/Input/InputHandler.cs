using System;
using System.Collections.Generic;
using Quoridor.Core.GameLogic;

namespace Quoridor.Terminal.Input
{
    public abstract class InputHandler
    {
        protected Game _game;
        protected Action PrintMenu;
        protected List<Action> _commandList;
        private int _commandIndex;

        protected InputHandler(Game game)
        {
            _game = game;
            _commandList = new List<Action>();
            
        }

        public void HandleInput()
        {
            PrintMenu();
            ReadAndExecuteCommand();
        }

        protected abstract void InitializeCommands();

        private void ReadAndExecuteCommand()
        {
            _commandIndex = Convert.ToInt32(Console.ReadLine());
            _commandList[_commandIndex - 1]();
        }
    }
}