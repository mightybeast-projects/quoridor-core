using System;
using System.Collections.Generic;
using System.Numerics;

namespace Quoridor.Core.Player
{
    public class Player
    {
        public Vector2 position
        {
            get => _position;
            internal set { _position = value; }
        }
        public Board board => _board;
        public IOutput output => _output;
        public List<Wall> placedWalls => _wallPlacementController.placedWalls;
        public int wallCounter => _wallPlacementController.wallCounter;

        private Vector2 _position;
        private Board _board;
        private IOutput _output;

        private MovementController _movementController;
        private WallPlacementController _wallPlacementController;

        public Player(Board board)
        {
            _board = board;
            _movementController = new MovementController(this);
            _wallPlacementController = new WallPlacementController(this);

            SetPosition(0, 0);
        }

        public void SetPosition(int x, int y)
        {
            _movementController.ChangeCurrentPositionTileEmptyStatus(true);
            _position = new Vector2(x, y);
            _movementController.ChangeCurrentPositionTileEmptyStatus(false);
        }

        public void SetPosition(Vector2 newPosition)
        {
            _movementController.ChangeCurrentPositionTileEmptyStatus(true);
            _position = newPosition;
            _movementController.ChangeCurrentPositionTileEmptyStatus(false);
        }

        public void SetOutput(IOutput output)
        {
            _output = output;
        }

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" P ");
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

        public void PlaceWall(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _wallPlacementController.PlaceWall(wallStartPosition, wallEndPosition);
        }
    }
}