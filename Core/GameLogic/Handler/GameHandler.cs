namespace Quoridor.Core.GameLogic.Handler
{
    internal abstract class GameHandler
    {
        protected GameConfig _gameConfig;

        protected GameHandler(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
        }
    }
}