using System;
using System.Collections.Generic;
using System.Linq;

class Tileset {
    private Dictionary<int, TileType> tiles;
    private static Random random = new();
    
    // This should be called Add()
    public void Register(int id, TileType tile) {
        tiles.Add(id, tile);
    }

    public TileType Get(int id) {
        return tiles[id];
    }

    // This needs to be tested
    public TileType GetRandomType() {
        return tiles.ElementAt(random.Next(0, tiles.Count)).Value;
    }

    public Tile MakeRandomTile() {
        return new Tile(GetRandomType(), Utility.RandomChoice<Direction>());
    }
}
