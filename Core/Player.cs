using System;
using System.Collections.Generic;
using System.Numerics;

namespace Quoridor.Core
{
    public class Player
    {
        public int wallCounter { 
            get => _wallCounter;  
            set { _wallCounter = value; } 
        }
        public Board board => _board;
        public Vector2 position => _position;
        public List<Wall> placedWalls => _placedWalls;

        private Board _board;
        private Vector2 _position;
        private IOutput _output;
        private int _wallCounter = 10;
        private List<Wall> _placedWalls;

        public Player(Board board)
        {
            _board = board;
            _placedWalls = new List<Wall>();

            SetPosition(0, 0);
        }

        public void SetPosition(int x, int y)
        {
            ChangeCurrentPositionTileEmptyStatus(true);
            _position = new Vector2(x, y);
            ChangeCurrentPositionTileEmptyStatus(false);
        }
        public void SetPosition(Vector2 newPosition)
        {
            ChangeCurrentPositionTileEmptyStatus(true);
            _position = newPosition;
            ChangeCurrentPositionTileEmptyStatus(false);
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
            Move(new Vector2(0, 2));
        }

        public void MoveDown()
        {
            Move(new Vector2(0, -2));
        }

        public void MoveRight()
        {
            Move(new Vector2(2, 0));
        }
        
        public void MoveLeft()
        {
            Move(new Vector2(-2, 0));
        }

        public void PlaceWall(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            if (WallIsTooLong(wallStartPosition, wallEndPosition)) return;

            _wallCounter--;

            Wall newWall = new Wall(wallStartPosition, wallEndPosition);
            _placedWalls.Add(newWall);

            int wallStartPositionX = (int)wallStartPosition.X;
            int wallStartPositionY = (int)wallStartPosition.Y;
            int wallEndPositionX = (int)wallEndPosition.X;
            int wallEndPositionY = (int)wallEndPosition.Y;

            for (int i = wallStartPositionX; i <= wallEndPositionX; i++)
            {
                for (int j = wallStartPositionY; j <= wallEndPositionY; j++)
                {
                    Tile tile = _board.grid[i, j];
                    tile.isEmpty = false;
                }
            }
        }

        private void Move(Vector2 moveVector)
        {
            try { MakeMove(moveVector); }
            catch (Exception) { RevertMove(moveVector); }
        }

        private void RevertMove(Vector2 moveVector)
        {
            if (_output != null)
                _output.DisplayEdgeMoveErrorMessage();
            _position -= moveVector;
            ChangeCurrentPositionTileEmptyStatus(false);
        }

        private void MakeMove(Vector2 moveVector)
        {
            ChangeCurrentPositionTileEmptyStatus(true);
            _position += moveVector;
            ChangeCurrentPositionTileEmptyStatus(false);
        }

        private void ChangeCurrentPositionTileEmptyStatus(bool isEmpty)
        {
            _board.grid[(int)_position.X, (int)_position.Y].isEmpty = isEmpty;
        }

        private static bool WallIsTooLong(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            return wallEndPosition.X - wallStartPosition.X > 2 || 
                    wallEndPosition.Y - wallStartPosition.Y > 2;
        }
    }
}