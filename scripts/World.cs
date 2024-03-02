using System.Collections.Generic;
using System;

class World {
    private Dictionary<Vector3, Tile> worldMap = new();
    private Dictionary<Vector2, int> floorMap = new();
    private readonly Tile defaultTile;
    
    public Vector3 CornerSWBottom { get; private set; }
    public Vector3 CornerNETop { get; private set; }

    public World(Tile defaultTile) {
        this.defaultTile = defaultTile;
    }

    public World(World world) {
        this.worldMap = new(world.worldMap);
        this.floorMap = new(world.floorMap);
        this.defaultTile = new(world.defaultTile);

        // These statements are safe because Vector3 is a record struct,
        // which gets copied automatically on assignment by the compiler.
        this.CornerSWBottom = world.CornerSWBottom;
        this.CornerNETop = world.CornerNETop;
    }

    public Tile GetTile(Vector3 position) {
        return worldMap.GetValueOrDefault(position, defaultTile);
    }

    public void SetTile(Vector3 position, Tile tile) {
        worldMap.Add(position, tile);
        CornerSWBottom = new Vector3() {
            X = Math.Min(position.X, CornerSWBottom.X),
            Y = Math.Min(position.Y, CornerSWBottom.Y),
            Z = Math.Min(position.Z, CornerSWBottom.Z)
        };
        CornerNETop = new Vector3() {
            X = Math.Max(position.X, CornerNETop.X),
            Y = Math.Max(position.Y, CornerNETop.Y),
            Z = Math.Max(position.Z, CornerNETop.Z)
        };
    }
}
