using System;
using System.Collections.Generic;
using System.Numerics;

namespace Quoridor.Core.GameLogic.Handler
{
    internal class PlayerMovementHandler : GameHandler
    {
        private List<Action> _commandList;

        public PlayerMovementHandler(GameConfig gameConfig) : 
            base(gameConfig)
        {
            InitializeCommands();
        }

        internal void HandlePlayerMove(PlayerMove playerMove)
        {
            Action MovementFunction = _commandList[(int) playerMove];
            MovementFunction();

            _gameConfig.SwitchCurrentPlayer();
        }

        private void InitializeCommands()
        {
            _commandList = new List<Action>();
            _commandList.Add(() => _gameConfig.currentPlayer.MoveUp());
            _commandList.Add(() => _gameConfig.currentPlayer.MoveDown());
            _commandList.Add(() => _gameConfig.currentPlayer.MoveRight());
            _commandList.Add(() => _gameConfig.currentPlayer.MoveLeft());
            _commandList.Add(() => _gameConfig.currentPlayer.MoveDiagonallyTopRight());
            _commandList.Add(() => _gameConfig.currentPlayer.MoveDiagonallyTopLeft());
            _commandList.Add(() => _gameConfig.currentPlayer.MoveDiagonallyBottomRight());
            _commandList.Add(() => _gameConfig.currentPlayer.MoveDiagonallyBottomLeft());
        }
    }
}