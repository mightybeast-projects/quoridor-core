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
            _commandList = new List<Action>
            {
                () => _gameConfig.currentPlayer.MoveUp(),
                () => _gameConfig.currentPlayer.MoveDown(),
                () => _gameConfig.currentPlayer.MoveRight(),
                () => _gameConfig.currentPlayer.MoveLeft(),
                () => _gameConfig.currentPlayer.MoveDiagonallyTopRight(),
                () => _gameConfig.currentPlayer.MoveDiagonallyTopLeft(),
                () => _gameConfig.currentPlayer.MoveDiagonallyBottomRight(),
                () => _gameConfig.currentPlayer.MoveDiagonallyBottomLeft()
            };
        }
    }
}