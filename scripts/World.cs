using System.Collections.Generic;
using System;

class World {
    private Dictionary<Vector3, Tile> worldMap = new();
    private Dictionary<Vector2, int> floorMap = new();
    private Tile defaultTile;
    
    public Vector3 CornerSWBottom { get; }
    public Vector3 CornerNETop { get; }

    public World(Tile defaultTile) {
        this.defaultTile = defaultTile;
    }

    public Tile GetTile(Vector3 position) {
        return worldMap.GetValueOrDefault(position, defaultTile);
    }

    public void SetTile(Vector3 position, Tile tile) {
        worldMap.Add(position, tile);
        CornerSWBottom = new Vector3() {
            Math.Min(position.X, CornerSWBottom.X),
            Math.Min(position.Y, CornerSWBottom.Y),
            Math.Min(position.Z, CornerSWBottom.Z)
        };
        CornerNETop = new Vector3() {
            Math.Max(position.X, CornerNETop.X),
            Math.Max(position.Y, CornerNETop.Y),
            Math.Max(position.Z, CornerNETop.Z)
        };
    }
}
