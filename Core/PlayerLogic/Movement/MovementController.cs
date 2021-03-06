using System.Numerics;
using Quoridor.Core.PlayerLogic.Movement.Validator;

namespace Quoridor.Core.PlayerLogic.Movement
{
    internal class MovementController
    {
        internal Vector2 position => _position;

        private Player _player;
        private Vector2 _newPosition;
        private Vector2 _position;
        private Vector2 _moveVector;
        private ExpectedPositionValidatorFacade _positionValidator;

        public MovementController(Player player)
        {
            _player = player;
            _positionValidator = new ExpectedPositionValidatorFacade(_player);
        }

        internal void SetPosition(int x, int y)
        {
            _newPosition = new Vector2(x, y);
            SetNewPosition();
        }

        internal void SetPosition(Vector2 newPosition)
        {
            _newPosition = newPosition;
            SetNewPosition();
        }

        internal void Move(Vector2 moveVector)
        {
            _moveVector = moveVector;
            
            _positionValidator.CalculateExpectedPosition(_position, _moveVector);

            _positionValidator.CheckExpectedPositionRequirements();

            SetPosition(_positionValidator.expectedPosition);
        }

        private void SetNewPosition()
        {
            if (NewPositionIsNotASolidTile() || NewPositionIsBeyondBoard())
                return;
            ChangeCurrentPositionTileEmptyStatus(true);
            _position = _newPosition;
            ChangeCurrentPositionTileEmptyStatus(false);
        }

        private void ChangeCurrentPositionTileEmptyStatus(bool isEmpty)
        {
            int playerPositionX = (int)_player.position.X;
            int playerPositionY = (int)_player.position.Y;
            _player.board.grid[playerPositionX, playerPositionY].isEmpty = isEmpty;
        }

        private bool NewPositionIsNotASolidTile()
        {
            return _newPosition.X % 2 != 0 || _newPosition.Y % 2 != 0;
        }

        private bool NewPositionIsBeyondBoard()
        {
            return _newPosition.X > 16 || _newPosition.Y > 16 ||
                    _newPosition.X < 0 || _newPosition.Y < 0;
        }
    }
}