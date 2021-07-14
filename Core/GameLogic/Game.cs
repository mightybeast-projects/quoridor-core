using System;
using System.Collections.Generic;
using System.Numerics;
using Quoridor.Core.PlayerLogic;
using Quoridor.Core.GameLogic;

namespace Quoridor.Core.GameLogic
{
    public class Game
    {
        public List<Player> players => _players;
        public Board board => _board;
        public Player currentPlayer => _currentPlayer;
        public int currentPlayerIndex => _currentPlayerIndex;

        private List<Player> _players;
        private Board _board;
        private Player _currentPlayer;
        private int _currentPlayerIndex;

        public Game(Board board, List<Player> players)
        {
            _board = board;
            _players = players;

            _players[0].SetPosition(8, 0);
            _players[1].SetPosition(8, 16);

            _players[0].SetGoal(8, 16);
            _players[1].SetGoal(8, 0);

            _currentPlayer = _players[_currentPlayerIndex];
        }

        public void MakeCurrentPlayerMove(PlayerMove playerMove)
        {
            Vector2 previousPosition = _currentPlayer.position;

            ChooseMove(playerMove);

            if(_currentPlayer.position == previousPosition)
                return;

            SwitchCurrentPlayer();
        }

        public void MakeCurrentPlayerPlaceWall(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            int previousWallCounter = _currentPlayer.wallCounter;

            _currentPlayer.PlaceWall(wallStartPosition, wallEndPosition);

            if(_currentPlayer.wallCounter == previousWallCounter)
                return;

            SwitchCurrentPlayer();
        }

        public void SetPlayersOutput(IOutput output)
        {
            foreach (Player player in _players)
                player.SetOutput(output);
        }

        private void SwitchCurrentPlayer()
        {
            _currentPlayerIndex++;
            if (_currentPlayerIndex > _players.Count - 1) 
                _currentPlayerIndex = 0;
            _currentPlayer = _players[_currentPlayerIndex];
        }

        private void ChooseMove(PlayerMove playerMove)
        {
            switch (playerMove)
            {
                case PlayerMove.MOVE_UP:
                    _currentPlayer.MoveUp();
                    break;
                case PlayerMove.MOVE_DOWN:
                    _currentPlayer.MoveDown();
                    break;
                case PlayerMove.MOVE_RIGHT:
                    _currentPlayer.MoveRight();
                    break;
                case PlayerMove.MOVE_LEFT:
                    _currentPlayer.MoveLeft();
                    break;
                case PlayerMove.MOVE_DIAGONALLY_TOP_RIGHT:
                    _currentPlayer.MoveDiagonallyTopRight();
                    break;
                case PlayerMove.MOVE_DIAGONALLY_TOP_LEFT:
                    _currentPlayer.MoveDiagonallyTopLeft();
                    break;
                case PlayerMove.MOVE_DIAGONALLY_BOTOM_RIGHT:
                    _currentPlayer.MoveDiagonallyBottomRight();
                    break;
                case PlayerMove.MOVE_DIAGONALLY_BOTTOM_LEFT:
                    _currentPlayer.MoveDiagonallyBottomLeft();
                    break;
            }
        }
    }
}