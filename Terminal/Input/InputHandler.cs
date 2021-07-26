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

        public InputHandler(Game game)
        {
            _game = game;
            InitializeCommands();
        }

        public void HandleInput()
        {
            PrintMenu();
            ReadAndExecuteCommand();
        }

        protected virtual void InitializeCommands()
        {
            _commandList = new List<Action>();
        }

        private void ReadAndExecuteCommand()
        {
            _commandIndex = Convert.ToInt32(Console.ReadLine());
            _commandList[_commandIndex - 1]();
        }
    }
}