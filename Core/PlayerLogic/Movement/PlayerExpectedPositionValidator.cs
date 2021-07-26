using System.Numerics;
using Quoridor.Core.PlayerLogic.Movement.Exceptions;

namespace Quoridor.Core.PlayerLogic.Movement
{
    internal class PlayerExpectedPositionValidator : ExpectedPositionValidator
    {
        private ExpectedPositionValidatorFacade _facade;

        public PlayerExpectedPositionValidator(ExpectedPositionValidatorFacade facade, Player player) 
            : base(player) 
        {
            _facade = facade;
        }

        internal void CheckForPlayerOnExpectedPosition()
        {
            if (AnotherPlayerIsOnExpectedPosition())
            {
                if (WallIsBehindAnotherPlayer())
                    throw new WallBehindAnotherPlayerException();

                _facade.CalculateExpectedPosition(_currentPosition, _moveVector * 2);

                if (ExpectedPositionIsBeyondTheBoard())
                    throw new MoveBeyondBoardException();
                if (AnotherPlayerIsOnExpectedPosition())
                    throw new JumpOverTwoPlayersException();
            }
        }
    }
}