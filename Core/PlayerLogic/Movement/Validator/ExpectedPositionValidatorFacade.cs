using System.Numerics;

namespace Quoridor.Core.PlayerLogic.Movement.Validator
{
    internal class ExpectedPositionValidatorFacade : ExpectedPositionValidator
    {
        public Vector2 expectedPosition => _expectedPosition;

        private DiagonalExpectedPositionValidator _diagonalValidator;
        private BasicExpectedPositionValidator _basicValidator;
        private PlayerExpectedPositionValidator _playerValidator;

        public ExpectedPositionValidatorFacade(Player player) : base(player)
        {
            _diagonalValidator = new DiagonalExpectedPositionValidator(player);
            _basicValidator = new BasicExpectedPositionValidator(player);
            _playerValidator = new PlayerExpectedPositionValidator(this, player);
        }

        internal override void CalculateExpectedPosition(Vector2 currentPosition, Vector2 moveVector)
        {
            base.CalculateExpectedPosition(currentPosition, moveVector);
            _diagonalValidator.CalculateExpectedPosition(currentPosition, moveVector);
            _basicValidator.CalculateExpectedPosition(currentPosition, moveVector);
            _playerValidator.CalculateExpectedPosition(currentPosition, moveVector);
        }

        internal void CheckExpectedPositionRequirements()
        {
            _basicValidator.CheckBasicExpectedPosition();

            _diagonalValidator.CheckDiagonalExpectedPosition();

            _playerValidator.CheckForPlayerOnExpectedPosition();
        }
    }
}