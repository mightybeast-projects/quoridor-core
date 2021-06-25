using System;
using System.Numerics;

namespace Quoridor.Core
{
    public class Player
    {
        public Board board => _board;
        public Vector2 position => _position;

        private Board _board;
        private Vector2 _position;
        private IOutput _output;

        public Player(Board board)
        {
            _board = board;
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

        private void Move(Vector2 moveVector)
        {
            try
            {
                ChangeCurrentPositionTileEmptyStatus(true);
                _position += moveVector;
                ChangeCurrentPositionTileEmptyStatus(false);
            }
            catch(Exception)
            {
                if(_output != null)
                    _output.DisplayEdgeMoveErrorMessage();
                _position -= moveVector;
                ChangeCurrentPositionTileEmptyStatus(false);
            }
        }

        private void ChangeCurrentPositionTileEmptyStatus(bool isEmpty)
        {
            _board.grid[(int)_position.X, (int)_position.Y].isEmpty = isEmpty;
        }
    }
}