using Quoridor.Core.PlayerLogic;

namespace Quoridor.Core.GameLogic.Handler
{
    internal class PlayerConfigurator : GameHandler
    {
        private Player _playerToConfig;
        private int _playerIndex;
        private int _startingPositionCoordinate;
        private int _goalPositionCoordinate;

        internal PlayerConfigurator(GameConfig gameConfig) : 
            base(gameConfig) { }

        internal void ConfigurePlayers()
        {
            SetPlayersWallCounter();

            for (int i = 0; i < _gameConfig.players.Count; i++)
                ConfigurePlayer(i);
        }

        private void ConfigurePlayer(int playerIndex)
        {
            _playerIndex = playerIndex;
            _playerToConfig = _gameConfig.players[playerIndex];

            ChoosePlayerStartingPositionCoordinate();
            ChoosePlayerGoalPositionCoordinate();

            SetPlayerPosition();
            SetPlayerGoal();
        }

        private void ChoosePlayerGoalPositionCoordinate()
        {
            if (_playerIndex == 0 || _playerIndex == 2)
                _goalPositionCoordinate = 16;
            else
                _goalPositionCoordinate = 0;
        }

        private void ChoosePlayerStartingPositionCoordinate()
        {
            if (_playerIndex == 0 || _playerIndex == 2)
                _startingPositionCoordinate = 0;
            else
                _startingPositionCoordinate = 16;
        }

        private void SetPlayerGoal()
        {
            if (_playerIndex == 0 || _playerIndex == 1)
                for (int x = 0; x < _playerToConfig.goal.Length; x++)
                    _playerToConfig.goal[x] = _gameConfig.board.grid[x * 2, _goalPositionCoordinate];
            else
                for (int y = 0; y < _playerToConfig.goal.Length; y++)
                    _playerToConfig.goal[y] = _gameConfig.board.grid[_goalPositionCoordinate, y * 2];
        }

        private void SetPlayerPosition()
        {
            if (_playerIndex < 2)
                _playerToConfig.SetPosition(8, _startingPositionCoordinate);
            else
                _playerToConfig.SetPosition(_startingPositionCoordinate, 8);
        }

        private void SetPlayersWallCounter()
        {
            foreach (Player player in _gameConfig.players)
                player.SetStartingWallCounter(20 / _gameConfig.players.Count);
        }
    }
}