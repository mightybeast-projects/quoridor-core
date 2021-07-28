using System;
using System.Collections.Generic;
using System.Numerics;

namespace Quoridor.Core.GameLogic.Handler
{
    internal class PlayerMovementHandler : GameHandler
    {
        private Vector2 _previousPosition;
        private List<Action> _commandList;

        public PlayerMovementHandler(GameConfig gameConfig) : 
            base(gameConfig)
        {
            InitializeCommands();
        }

        internal void HandlePlayerMove(PlayerMove playerMove)
        {
            _previousPosition = _gameConfig.currentPlayer.position;

            Action MovementFunction = _commandList[(int) playerMove];
            MovementFunction();

            if (!PlayerMadeWrongMove())
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

        private bool PlayerMadeWrongMove()
        {
            return _gameConfig.currentPlayer.position == _previousPosition;
        }
    }
}