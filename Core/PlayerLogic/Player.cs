using System.Numerics;
using Quoridor.Core.Output;
using Quoridor.Core.PlayerLogic.Movement;
using Quoridor.Core.PlayerLogic.WallPlacement;

namespace Quoridor.Core.PlayerLogic
{
    public class Player
    {
        public Vector2 position => _movementController.position;
        public int wallCounter => _wallPlacementController.wallCounter;
        public Board board => _board;
        public Tile goal => _goal;
        public IOutput output => _output;
        
        private MovementController _movementController;
        private WallPlacementController _wallPlacementController;
        private Board _board;
        private Tile _goal;
        private IOutput _output;

        public Player(Board board)
        {
            _board = board;
            _movementController = new MovementController(this);
            _wallPlacementController = new WallPlacementController(this);

            SetPosition(0, 0);
        }

        public void SetPosition(int x, int y)
        {
            _movementController.SetPosition(x, y);
        }

        public void SetPosition(Vector2 newPosition)
        {
            _movementController.SetPosition(newPosition);
        }

        public void MoveUp()
        {
            _movementController.Move(new Vector2(0, 2));
        }

        public void MoveDown()
        {
            _movementController.Move(new Vector2(0, -2));
        }

        public void MoveRight()
        {
            _movementController.Move(new Vector2(2, 0));
        }

        public void MoveLeft()
        {
            _movementController.Move(new Vector2(-2, 0));
        }

        public void MoveDiagonallyTopRight()
        {
            _movementController.Move(new Vector2(2, 2));
        }

        public void MoveDiagonallyTopLeft()
        {
            _movementController.Move(new Vector2(-2, 2));
        }

        public void MoveDiagonallyBottomRight()
        {
            _movementController.Move(new Vector2(2, -2));
        }

        public void MoveDiagonallyBottomLeft()
        {
            _movementController.Move(new Vector2(-2, -2));
        }

        public void PlaceWall(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _wallPlacementController.PlaceWall(wallStartPosition, wallEndPosition);
        }

        public void SetOutput(IOutput output)
        {
            _output = output;
        }

        public void SetGoal(int x, int y)
        {
            _goal = _board.grid[x, y];
        }
    }
}