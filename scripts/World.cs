using System.Collections.Generic;

// - zaimplementować class WaveFunctionCollapse : IGenerator

class World {
    private Dictionary<Vector3, Tile> worldMap = new();
    private Dictionary<Vector2, int> floorMap = new();
    private Tile defaultTile;
    private Vector3 cornerSWBottom;
    private Vector3 cornerNETop;

    public World(Tile defaultTile) {
        this.defaultTile = defaultTile;
    }

    public Tile GetTile(Vector3 position) {
        return worldMap.GetValueOrDefault(position, defaultTile);
    }

    public void SetTile(Vector3 position, Tile tile) {
        worldMap.Add(position, tile);
    }
}
