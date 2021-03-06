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

        private PlayerMovementHandler _movementHandler;
        private PlayerWallPlacementHandler _wallPlacementHandler;
        private PlayerConfigurator _configurator;
        private GameConfig _gameConfig;
        
        public Game()
        {
            _gameConfig = new GameConfig();
            _movementHandler = new PlayerMovementHandler(_gameConfig);
            _wallPlacementHandler = new PlayerWallPlacementHandler(_gameConfig);
            _configurator = new PlayerConfigurator(_gameConfig);
        }

        public void AddNewPlayerPair()
        {
            _gameConfig.AddNewPlayers();
        }

        public void Start()
        {
            _configurator.ConfigurePlayers();

            _gameConfig.SwitchCurrentPlayer();
        }

        public void MakeCurrentPlayerMove(PlayerMove playerMove)
        {
            _movementHandler.HandlePlayerMove(playerMove);
        }

        public void MakeCurrentPlayerPlaceWall(Vector2 start, Vector2 end)
        {
            _wallPlacementHandler.HandleWallPlacement(start, end);
        }
    }
}