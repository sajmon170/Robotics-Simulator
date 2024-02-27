using System.Collections.Generic;

class World {
    private Dictionary<Vector3, Tile> worldMap = new();
    private Dictionary<Vector2, int> floorMap = new();
    private Tile defaultTile;
    
    public Vector3 CornerSWBottom { get; set; }
    public Vector3 CornerNETop { get; set; }

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
