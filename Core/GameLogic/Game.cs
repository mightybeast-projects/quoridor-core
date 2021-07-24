using System.Collections.Generic;
using System.Numerics;
using Quoridor.Core.GameLogic.Handler;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic
{
    public class Game
    {
        public List<Player> players => _players;
        public Board board => _board;
        public Player currentPlayer => _currentPlayer;
        public int currentPlayerIndex => _currentPlayerIndex;

        private PlayerMovementHandler _movementHandler;
        private PlayerWallPlacementHandler _wallPlacementHandler;
        private PlayerConfigurator _configurator;
        private List<Player> _players;
        private Board _board;
        private Player _currentPlayer;
        private int _currentPlayerIndex = -1;

        public Game()
        {
            _board = new Board();
            _players = new List<Player>();
            _movementHandler = new PlayerMovementHandler();
            _wallPlacementHandler = new PlayerWallPlacementHandler(_players);
            _configurator = new PlayerConfigurator(_board, _players);
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
            _configurator.ConfigurePlayers();

            SwitchCurrentPlayer();
        }

        public void MakeCurrentPlayerMove(PlayerMove playerMove)
        {
            bool movementSuccessful 
                = _movementHandler.HandlePlayerMove(playerMove);

            if(movementSuccessful)
                SwitchCurrentPlayer();
        }

        public void MakeCurrentPlayerPlaceWall(Vector2 start, Vector2 end)
        {
            bool wallPlacementSuccessful 
                = _wallPlacementHandler.HandleWallPlacement(start, end);

            if(wallPlacementSuccessful)
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
            _movementHandler.currentPlayer = _currentPlayer;
            _wallPlacementHandler.currentPlayer = _currentPlayer;
        }
    }
}