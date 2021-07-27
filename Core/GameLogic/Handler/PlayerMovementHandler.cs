using System;
using System.Collections.Generic;
using System.Numerics;

namespace Quoridor.Core.GameLogic.Handler
{
    internal class PlayerMovementHandler : GameHandler
    {
        private Vector2 _previousPosition;
        private List<Action> _commandList;

        public PlayerMovementHandler()
        {
            InitializeCommands();
        }

        internal bool HandlePlayerMove(PlayerMove playerMove)
        {
            _previousPosition = _currentPlayer.position;

            _commandList[(int)playerMove]();

            if (PlayerMadeWrongMove())
                return false;
            else
                return true;
        }

        private void InitializeCommands()
        {
            _commandList = new List<Action>();
            _commandList.Add(() => _currentPlayer.MoveUp());
            _commandList.Add(() => _currentPlayer.MoveDown());
            _commandList.Add(() => _currentPlayer.MoveRight());
            _commandList.Add(() => _currentPlayer.MoveLeft());
            _commandList.Add(() => _currentPlayer.MoveDiagonallyTopRight());
            _commandList.Add(() => _currentPlayer.MoveDiagonallyTopLeft());
            _commandList.Add(() => _currentPlayer.MoveDiagonallyBottomRight());
            _commandList.Add(() => _currentPlayer.MoveDiagonallyBottomLeft());
        }

        private bool PlayerMadeWrongMove()
        {
            return _currentPlayer.position == _previousPosition;
        }
    }
}