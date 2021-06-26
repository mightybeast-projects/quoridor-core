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

        private int _wallStartPositionX;
        private int _wallStartPositionY;
        private int _wallEndPositionX;
        private int _wallEndPositionY;

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

        public bool PlaceWall(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _wallStartPositionX = (int)wallStartPosition.X;
            _wallStartPositionY = (int)wallStartPosition.Y;
            _wallEndPositionX = (int)wallEndPosition.X;
            _wallEndPositionY = (int)wallEndPosition.Y;

            if (WallIsTooLong(wallStartPosition, wallEndPosition)) return false;
            if (WallIsNotOnTheSameLine(wallStartPosition, wallEndPosition)) return false;
            if (WallTilesHavePairCoordinates()) return false;

            _wallCounter--;

            Wall newWall = new Wall(wallStartPosition, wallEndPosition);
            _placedWalls.Add(newWall);

            for (int i = _wallStartPositionX; i <= _wallEndPositionX; i++)
            {
                for (int j = _wallStartPositionY; j <= _wallEndPositionY; j++)
                {
                    Tile tile = _board.grid[i, j];
                    tile.isEmpty = false;
                }
            }

            return true;
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

        private bool WallIsTooLong(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            return wallEndPosition.X - wallStartPosition.X > 2 || 
                    wallEndPosition.Y - wallStartPosition.Y > 2;
        }

        private bool WallIsNotOnTheSameLine(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            return wallStartPosition.X != wallEndPosition.X && 
                    wallStartPosition.Y != wallEndPosition.Y;
        }

        private bool WallTilesHavePairCoordinates()
        {
            int middlePositionX = (_wallEndPositionX + _wallStartPositionX) / 2;
            int middlePositionY = (_wallEndPositionY + _wallStartPositionY) / 2;

            if((_wallStartPositionX % 2 == 0 && _wallStartPositionY % 2 == 0)) return true;
            if((middlePositionX % 2 == 0 && middlePositionY % 2 == 0)) return true;

            return false;
        }
    }
}