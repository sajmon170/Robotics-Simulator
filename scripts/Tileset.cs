using System;
using System.Collections.Generic;
using System.Linq;

class Tileset {
    private Dictionary<int, TileType> tiles;
    private static Random rand = new();
    
    // This should be called Add()
    public void Register(int id, TileType tile) {
        tiles.Add(id, tile);
    }

    public TileType Get(int id) {
        return tiles[id];
    }

    // This needs to be tested
    public TileType GetRandom() {
        return tiles.ElementAt(rand.Next(0, tiles.Count)).Value;
    }
}
