using System.Numerics;
using Quoridor.Core.PlayerLogic.Movement;
using Quoridor.Core.PlayerLogic.WallPlacement;

namespace Quoridor.Core.PlayerLogic
{
    public class Player
    {
        
        public Board board => _board;
        public IOutput output => _output;
        public Tile[] goal => _goal;
        public Wall lastPlacedWall => _wallPlacementController.lastPlacedWall;
        public Vector2 position => _movementController.position;
        public int wallCounter => _wallPlacementController.wallCounter;

        private MovementController _movementController;
        private WallPlacementController _wallPlacementController;
        private Board _board;
        private IOutput _output;
        private Tile[] _goal;

        public Player(Board board)
        {
            _board = board;
            _movementController = new MovementController(this);
            _wallPlacementController = new WallPlacementController(this);
            _goal = new Tile[9];

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

        public void RevertWallPlacement()
        {
            _wallPlacementController.RevertLastPlacedWall();
        }

        public void SetOutput(IOutput output)
        {
            _output = output;
        }
    }
}