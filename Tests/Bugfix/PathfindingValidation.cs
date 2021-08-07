using System.Numerics;
using NUnit.Framework;
using Quoridor.Core.GameLogic;
using Quoridor.Tests.GameLogic.TwoPlayers;

namespace Quoridor.Tests.Bugfix
{
    [TestFixture]
    internal class PathfindingValidation : TwoPlayersGameInitialization
    {
        [Test]
        public void RevertReverseWallPlacement()
        {
            _game.MakeCurrentPlayerPlaceWall(new Vector2(8, 15), new Vector2(10, 15));
            _game.MakeCurrentPlayerPlaceWall(new Vector2(7, 16), new Vector2(7, 14));

            Assert.Catch<NoPathForPlayerException>(
                () => _game.MakeCurrentPlayerPlaceWall(new Vector2(11, 16), new Vector2(11, 14))
            );

            Assert.AreEqual(2, _game.board.placedWalls.Count);
            Assert.IsTrue(_game.board.grid[11, 16].isEmpty);
            Assert.IsTrue(_game.board.grid[11, 15].isEmpty);
            Assert.IsTrue(_game.board.grid[11, 14].isEmpty);

            _game.MakeCurrentPlayerPlaceWall(new Vector2(12, 15), new Vector2(14, 15));
        }
    }
}