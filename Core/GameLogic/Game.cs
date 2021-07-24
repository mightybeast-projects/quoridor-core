using System.Collections.Generic;
using System.Numerics;
using Quoridor.Core.PlayerLogic;

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
        private PathValidator _pathValidator;
        private Vector2 _previousPosition;
        private int _previousWallCounter;
        private int _currentPlayerIndex;

        public Game()
        {
            _board = new Board();
            _players = new List<Player>();
            _pathValidator = new PathValidator();
        }

        public void AddNewPlayerPair()
        {
            if (_players.Count < 4)
            {
                _players.Add(new Player(_board));
                _players.Add(new Player(_board));
            }
        }

        public void Start()
        {
            SetPlayerPositions();
            SetPlayerGoals();

            _currentPlayer = _players[_currentPlayerIndex];
        }

        public void MakeCurrentPlayerMove(PlayerMove playerMove)
        {
            _previousPosition = _currentPlayer.position;

            ChooseMove(playerMove);

            if (PlayerMadeWrongMove())
                return;

            SwitchCurrentPlayer();
        }

        public void MakeCurrentPlayerPlaceWall(Vector2 wallStartPosition, Vector2 wallEndPosition)
        {
            _previousWallCounter = _currentPlayer.wallCounter;

            _currentPlayer.PlaceWall(wallStartPosition, wallEndPosition);

            if (PlayerPlacedWrongWall())
                return;
            if (OneOfThePlayersDoNotHavePathToGoal())
            {
                _currentPlayer.RevertWallPlacement();
                _currentPlayer.output?.DisplayExceptionMessage(new NoPathForPlayerException());
                return;
            }

            SwitchCurrentPlayer();
        }

        public void SetPlayersOutput(IOutput output)
        {
            foreach (Player player in _players)
                player.SetOutput(output);
        }

        public bool OneOfThePlayersDoNotHavePathToGoal()
        {
            foreach (Player player in _players)
                if (!PlayerHavePathToGoal(player)) return true;

            return false;
        }

        private bool PlayerHavePathToGoal(Player player)
        {
            _pathValidator.SetPlayer(player);
            return _pathValidator.CheckPathToGoal();
        }

        private void SetPlayerPositions()
        {
            Player player;
            int startingPosition;

            for (int i = 0; i < _players.Count; i++)
            {
                player = _players[i];
                startingPosition = 0;

                if (i == 0 || i == 2)
                    startingPosition = 0;
                else
                    startingPosition = 16;

                if (i < 2)
                    player.SetPosition(8, startingPosition);
                else
                    player.SetPosition(startingPosition, 8);
            }
        }

        private void SetPlayerGoals()
        {
            int goalIndex = -1;

            for (int i = 0; i < _players.Count; i++)
            {
                Player player = _players[i];
                if (i == 0 || i == 2)
                    goalIndex = 16;
                else
                    goalIndex = 0;

                if (i == 0 || i == 1)
                    for (int x = 0; x < player.goal.Length; x++)
                        player.goal[x] = _board.grid[x * 2, goalIndex];
                else
                    for (int y = 0; y < player.goal.Length; y++)
                        player.goal[y] = _board.grid[goalIndex, y * 2];
            }
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

        private bool PlayerMadeWrongMove()
        {
            return _currentPlayer.position == _previousPosition;
        }

        private bool PlayerPlacedWrongWall()
        {
            return _currentPlayer.wallCounter == _previousWallCounter;
        }
    }
}