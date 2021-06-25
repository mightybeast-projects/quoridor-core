namespace Quoridor.Core
{
    public class SolidTile: Tile
    {
        public SolidTile()
        {
            _solid = true;
            _symbol = "1";
        }
    }
}