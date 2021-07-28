using System.Collections.Generic;
using System.Numerics;
using Quoridor.Core.GameLogic.Handler;
using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic
{
    public class Game
    {
        public List<Player> players => _gameConfig.players;
        public Board board => _gameConfig.board;
        public Player currentPlayer => _gameConfig.currentPlayer;
        public int currentPlayerIndex => _gameConfig.currentPlayerIndex;

        private PlayerMovementHandler _movementHandler;
        private PlayerWallPlacementHandler _wallPlacementHandler;
        private PlayerConfigurator _configurator;
        private GameConfig _gameConfig;
        private bool _movementSuccessful;
        private bool _wallPlacementSuccessful;
        
        public Game()
        {
            _gameConfig = new GameConfig();
            _movementHandler = new PlayerMovementHandler(_gameConfig);
            _wallPlacementHandler = new PlayerWallPlacementHandler(_gameConfig);
            _configurator = new PlayerConfigurator(_gameConfig);
        }

        public void AddNewPlayerPair()
        {
            if (_gameConfig.players.Count < 4)
            {
                _gameConfig.players.Add(new Player(_gameConfig.board));
                _gameConfig.players.Add(new Player(_gameConfig.board));
            }
        }

        public void Start()
        {
            _configurator.ConfigurePlayers();

            SwitchCurrentPlayer();
        }

        public void MakeCurrentPlayerMove(PlayerMove playerMove)
        {
            _movementSuccessful 
                = _movementHandler.HandlePlayerMove(playerMove);

            SwitchCurrentPlayerIf(_movementSuccessful);
        }

        public void MakeCurrentPlayerPlaceWall(Vector2 start, Vector2 end)
        {
            _wallPlacementSuccessful 
                = _wallPlacementHandler.HandleWallPlacement(start, end);

            SwitchCurrentPlayerIf(_wallPlacementSuccessful);
        }

        public void SetPlayersOutput(IOutput output)
        {
            foreach (Player player in _gameConfig.players)
                player.SetOutput(output);
        }

        private void SwitchCurrentPlayerIf(bool actionSuccessful)
        {
            if(actionSuccessful)
                SwitchCurrentPlayer();
        }

        private void SwitchCurrentPlayer()
        {
            _gameConfig.currentPlayerIndex++;

            if (_gameConfig.currentPlayerIndex > _gameConfig.players.Count - 1)
                _gameConfig.currentPlayerIndex = 0;
            
            _gameConfig.currentPlayer = _gameConfig.players[_gameConfig.currentPlayerIndex];
        }
    }
}